using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Social_Network.Core.Interfaces.IRepositories;
using Social_Network.Resources;
using Social_Network.Web.Models.Base;

namespace Social_Network.Web.Models.Account
{
    public class RegisterModel : BaseModel, IValidatableObject
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            IUsersRepository usersRepository = DependencyResolver.Current.GetService<IUsersRepository>();

            if (String.IsNullOrWhiteSpace(this.Login))
            {
                yield return new ValidationResult(AccountResources.Error_EmptyTextField, new[] { "Login" });
            }
            else if (!usersRepository.IsLoginFree(this.Login))
            {
                yield return new ValidationResult(AccountResources.Error_LoginAlreadyExists, new[] { "Login" });
            }

            if (String.IsNullOrWhiteSpace(this.Password) && String.IsNullOrWhiteSpace(this.ConfirmPassword))
            {
                if (!this.Password.Equals(this.ConfirmPassword))
                {
                    yield return new ValidationResult(AccountResources.Error_BadConfirmPassword, new[] { "ConfirmPassword" });
                }
            }
            else
            {
                if (String.IsNullOrWhiteSpace(this.Password))
                {
                    yield return new ValidationResult(AccountResources.Error_EmptyTextField, new[] { "Password" });
                }

                if (String.IsNullOrWhiteSpace(this.ConfirmPassword))
                {
                    yield return new ValidationResult(AccountResources.Error_EmptyTextField, new[] { "ConfirmPassword" });
                }
            }
        }
    }
}