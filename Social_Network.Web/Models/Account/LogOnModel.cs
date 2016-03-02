using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Social_Network.Core.Interfaces.IRepositories;
using Social_Network.Web.Models.Base;
using Social_Network.Resources;


namespace Social_Network.Web.Models.Account
{
    public class LogOnModel:BaseModel, IValidatableObject
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (String.IsNullOrWhiteSpace(this.Login))
            {
                yield return new ValidationResult(AccountResources.Error_EmptyTextField, new[] {"Login"} );
            }

            if (String.IsNullOrWhiteSpace(this.Password))
            {
                yield return  new ValidationResult(AccountResources.Error_EmptyTextField, new []{"Password"});
            }

            if (!DependencyResolver.Current.GetService<IUsersRepository>().CheckUser(this.Login, this.Password))
            {
                yield return new ValidationResult(AccountResources.Error_IncorrectLoginOrPassword);
            }
        }
    }
}