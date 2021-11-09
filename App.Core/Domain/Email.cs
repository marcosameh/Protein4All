using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Domain
{
    public class Email
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(12)]
        public string  PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string email { get;set; }
        public string Message { get; set; }

        public string ProductUrl { get; set; }
        
    }
}
