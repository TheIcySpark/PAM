using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PAM.Data;
using PAM.Models;

namespace PAM.Controllers
{
    public class ViewBagImageController : Controller
    {
        private readonly PAMContext _context;

        public ViewBagImageController(PAMContext context)
        {
            _context = context;
        }

        public string SetViewBagImage(System.Security.Claims.ClaimsPrincipal u)
        {
            if (u.Identity.IsAuthenticated)
            {
                string googleId = u.Claims
                    .Where(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
                    .Select(c => c.Value)
                    .FirstOrDefault();
                var user = _context.User.FirstOrDefault(m => m.GoogleUserID == googleId);
                if (user.Photo == null) return "";
                var base64 = Convert.ToBase64String(user.Photo);
                var imgsrc = string.Format("data:image/jpg;base64,{0}", base64);
                return imgsrc;
            }
            return "";
        }
    }
}
