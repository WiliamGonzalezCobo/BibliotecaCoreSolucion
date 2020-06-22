using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaCore.Utilities.SettingsManager.Contract
{
    public interface IConfigurationSettings
    {
        string Issuer();

        string Audience();

        string SigninKey();
    }
}
