using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PAM.Data;
using PAM.Models;
using System.Web.Helpers;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using static System.Net.Mime.MediaTypeNames;

namespace PAM.Controllers
{
    public class UsersController : Controller
    {
        private readonly PAMContext _context;

        public UsersController(PAMContext context)
        {
            _context = context;
        }

        public void SetViewBagImage()
        {
            if (User.Identity.IsAuthenticated)
            {
                string googleId = User.Claims
                    .Where(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
                    .Select(c => c.Value)
                    .FirstOrDefault();
                var user = _context.User.FirstOrDefault(m => m.GoogleUserID == googleId);
                if (user.Photo == null) return;
                var base64 = Convert.ToBase64String(user.Photo);
                var imgsrc = string.Format("data:image/jpg;base64,{0}", base64);
                ViewBag.imgsrc = imgsrc;
            }
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                string currentUserGoogleIdentifier = User.Claims
                    .Where(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
                    .Select(c => c.Value)
                    .FirstOrDefault();

                string googleIdentifier = _context.User
                    .Where(user => user.GoogleUserID == currentUserGoogleIdentifier)
                    .Select(user => user.GoogleUserID)
                    .FirstOrDefault();

                if (googleIdentifier == null)
                {
                    string userName = User.Claims
                        .Where(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")
                        .Select(c => c.Value)
                        .FirstOrDefault();
                    _context.Add(new User
                    {
                        GoogleUserID = currentUserGoogleIdentifier,
                        UserName = userName,
                        Photo = null
                    });
                    await _context.SaveChangesAsync();
                }
            }
            SetViewBagImage();
            return View(await _context.User.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> EditProfile(string? googleId)
        {
            SetViewBagImage();
            if(googleId == null)
            {
                return NotFound();
            }
            string googleCurrentUserId = User.Claims
                .Where(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
                .Select(c => c.Value)
                .FirstOrDefault();
            if(googleCurrentUserId != googleId)
            {
                Redirect("/Account/Denied");
            }
            var user = await _context.User
                .FirstOrDefaultAsync(m => m.GoogleUserID == googleId);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }


        [HttpPost][Authorize]
        public async Task<IActionResult> EditProfile(IFormFile photo, string userName)
        {
            SetViewBagImage();
            string googleId = User.Claims
                .Where(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
                .Select(c => c.Value)
                .FirstOrDefault();
            var user = await _context.User
                .FirstOrDefaultAsync(m => m.GoogleUserID == googleId);
            if(user == null)
            {
                return NotFound();
            }
            user.UserName = userName;
            using(var target = new MemoryStream())
            {
                if(photo != null)
                {
                    photo.CopyTo(target);
                    user.Photo = target.ToArray();
                }
            }
            _context.SaveChanges();
            return View(user);
        }


        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            SetViewBagImage();
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            SetViewBagImage();
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,GoogleUserID,UserName,Photo")] User user)
        {
            SetViewBagImage();
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            SetViewBagImage();
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,GoogleUserID,UserName,Photo")] User user)
        {
            SetViewBagImage();
            if (id != user.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            SetViewBagImage();
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            SetViewBagImage();
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            SetViewBagImage();
            return _context.User.Any(e => e.UserID == id);
        }
    }
}
