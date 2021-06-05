using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using WeCommerce.Data;
using WeCommerce.Models;

namespace WeCommerce.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context)
        {
            
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Numero de Telefono")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Nombre")]
            public string Nombre { get; set; }

            [Display(Name = "Apellido")]
            public string Apellido { get; set; }

            [Display(Name = "Localidad")]
            public string Localidad { get; set; }

            [Display(Name = "Calle")]
            public string Calle { get; set; }

        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Nombre =user.Nombre,
                Apellido = user.Apellido,
                Localidad = user.Localidad,
                Calle = user.Calle

            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }
            var Nombre = user.Nombre;
            if (Input.Nombre != Nombre)
            {
                user.Nombre = Input.Nombre;
                await _userManager.UpdateAsync(user);
            }
            var Apellido = user.Apellido;
            if (Input.Apellido != Apellido)
            {
                user.Apellido = Input.Apellido;
                await _userManager.UpdateAsync(user);
            }
            var Localidad = user.Localidad;
            if (Input.Localidad != Localidad)
            {
                user.Localidad = Input.Localidad;
                await _userManager.UpdateAsync(user);
            }
            var Calle = user.Calle;
            if (Input.Calle != Calle)
            {
                user.Calle = Input.Calle;
                await _userManager.UpdateAsync(user);
            }
            var updateuser = new ApplicationUser {Nombre = Input.Nombre};
            await _userManager.UpdateAsync(updateuser);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
