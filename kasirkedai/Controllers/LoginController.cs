using kasirkedai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace kasirkedai.Controllers
{
    internal class LoginController
    {
        private UserRepository userRepo;

        public LoginController()
        {
            userRepo = new UserRepository();
        }

        public bool AuthenticateUser(string username, string password)
        {
            return userRepo.ValidateUser(username, password);
        }
    }
}
