using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAM.Models
{
    public class IMDBItemsList
    {
        public int IMDBItemsListID { get; set; }
        public virtual List<IMDBItem> ItemsList { get; set; }

    }
}
