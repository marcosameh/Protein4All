using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Models
{
    public partial class ProductCategory
    {
        [NotMapped]

        public IFormFile PhotoFile { get; set; }
    }
}
