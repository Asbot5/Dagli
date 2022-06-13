using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dagli.Models;

namespace Dagli.Interfaces
{
    public interface ILoginService
    {
        public void AddUser(Login user);
        bool CheckPassword(string userName, string password);
        public List<Login> GetLogins();

        public Login GetLogin(string email);
    }
}
