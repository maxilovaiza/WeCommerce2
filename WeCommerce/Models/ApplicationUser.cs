using Microsoft.AspNetCore.Identity;
using System;

namespace WeCommerce.Models
{
    public class ApplicationUser : IdentityUser
    {
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Localidad { get; set; }
        public String Calle { get; set; }
    }
}
