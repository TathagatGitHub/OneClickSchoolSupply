using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using OneClickSchoolSupply.Models;
namespace OneClickSchoolSupply.Models
{
    public class KitItem
    {
        [Key]
        public int ItemID { get; set; }

        [Required, StringLength(100), Display(Name = "Item Name")]
        public string ItemName { get; set; }
        [Required, Display(Name = "Item Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double ItemPrice { get; set; }
        public int? KitId { get; set; }
        public virtual SchoolKit SchoolKit { get; set; }
    }
}