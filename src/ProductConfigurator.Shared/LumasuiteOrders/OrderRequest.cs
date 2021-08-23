using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductConfigurator.Shared
{
    public class OrderRequest
    {
        [Required]
        [MaxLength(120, ErrorMessage = "Name can not be longer than {0}")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100, ErrorMessage = "Email can not be longer than {0}")]
        public string Email { get; set; }

        public string Body { get; set; }
    }
}
