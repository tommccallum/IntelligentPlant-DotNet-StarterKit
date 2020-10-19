using Microsoft.AspNetCore.Mvc;

namespace MyNewApp.Web.Models {
    public class LoginViewModel {

        public bool IsPersistent { get; set; }

        [HiddenInput]
        public string RedirectUrl { get; set; }

    }
}
