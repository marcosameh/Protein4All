using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ViewModels
{
     public class ProductVM
    {
         public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed ,Enter Like This product-name")]
        public string Url { get; set; }
        public int CategoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(90)]
        public string SubTitle { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }
         [Required]
        public string Photo { get; set; }
        public IFormFile PhotoFile { get; set; }

    }
}
