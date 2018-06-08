using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using OneClickSchoolSupply.Models;
namespace OneClickSchoolSupply.Models
{
    public class SchoolKit
    {
        [Key]
        public int KitId { get; set; }
        [Required, StringLength(100), Display(Name = "Name")]
        public string Name { get; set; }
         [Required, StringLength(200), Display(Name = "School Name")]
        public string SchoolName { get; set; }
        public String Grade { get; set; }
         [Required, StringLength(200), Display(Name = "District Name")]
        public string SchoolDistrict { get; set; }
         [Required, Display(Name = "Kit Price")]
         [DisplayFormat(DataFormatString = "{0:C}")]
        public double KitPrice { get; set; }
        public virtual ICollection<KitItem> KitItems { get; set; }
    }

   
}