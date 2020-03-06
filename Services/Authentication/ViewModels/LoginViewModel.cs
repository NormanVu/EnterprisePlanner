using Authentication.ViewModels.Validations;
using FluentValidation.Attributes;

namespace Authentication.ViewModels
{
    [Validator(typeof(LoginViewModelValidator))]
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
