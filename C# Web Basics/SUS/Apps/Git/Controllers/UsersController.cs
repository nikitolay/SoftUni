using Git.Services;
using Git.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Git.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            return View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            var userId = usersService.GetUserId(input.Username, input.Password);
            if (userId == null)
            {
                return Error("Invalid username or password");
            }

            SignIn(userId);
            return Redirect("/Repositories/All");
        }

        public HttpResponse Register()
        {
            return View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {

            if (string.IsNullOrEmpty(input.Username) || input.Username.Length < 5 || input.Username.Length > 20)
            {
                return Error("Invalid username");
            }

            if (string.IsNullOrEmpty(input.Email) || !new EmailAddressAttribute().IsValid(input.Email))
            {
                return Error("Invalid email");
            }

            if (string.IsNullOrEmpty(input.Password) || input.Password.Length < 6 || input.Password.Length > 20)
            {
                return Error("Invalid password");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return Error("Passwords do not match");
            }

            if (!usersService.IsUsernameAvailable(input.Username))
            {
                return Error("Username already taken.");
            }

            if (!usersService.IsEmailAvailable(input.Email))
            {
                return Error("Email already taken.");
            }

            usersService.CreateUser(input.Username, input.Email, input.Password);
            return Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            SignOut();
            return Redirect("/");
        }
    }
}
