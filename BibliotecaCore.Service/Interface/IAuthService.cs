using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaCore.Service.Interface
{
    public interface IAuthService
    {
        bool ValidateLogin(string user, string pass);

        string GenerateToken(DateTime date, string user, TimeSpan validDate);
    }
}
