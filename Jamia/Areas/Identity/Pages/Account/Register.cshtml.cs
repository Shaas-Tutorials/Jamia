using Jamia.Data;
using Jamia.Infrastructure;
using Jamia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Jamia.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _context = context;
            Roles = _roleManager.Roles.ToList().Select(role => new RadioModel<string> { Id = role.Id, Text = role.Name });
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Display(Name = "Create New Institute")]
            public bool CreateInstitute { get; set; }

            [Required]
            public string Institute { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            public string Role { get; set; }
        }

        public IEnumerable<RadioModel<string>> Roles { get; set; }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            var institute = _context.Institute.Where(x => x.Name == Input.Institute).FirstOrDefault();
            if (Input.CreateInstitute && institute != null)
            {
                ModelState.AddModelError(string.Empty, "Institute Name Should be Unique");
                return Page();
            }
            else if (!Input.CreateInstitute && institute == null)
            {
                ModelState.AddModelError(string.Empty, $"Institute {Input.Institute} Not Find, Please inter Valid Institute Name.");
                return Page();
            }
            Input.Role = Input.CreateInstitute ? RoleNames.SuperAdmin : Input.Role;
            returnUrl = returnUrl ?? Url.Action(ActionNames.Index, ControlerNames.Home, new { area = Input.Role == RoleNames.SuperAdmin ? Input.Role : "" });
            if (ModelState.IsValid)
            {
                var instituteID = institute is null ? Guid.NewGuid() : institute.ID;
                if (Input.CreateInstitute)
                {
                    instituteID = Guid.NewGuid();
                    await _context.Institute.AddAsync(new Institute { ID = instituteID, Name = Input.Institute });
                    await _context.SaveChangesAsync();
                }
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email, InstituteID = instituteID, Status = Input.Role == RoleNames.SuperAdmin ? Status.Approved : Status.Submitted };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                    result = await _userManager.AddToRoleAsync(user, Input.Role);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
