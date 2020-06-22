﻿using BibliotecaCore.Utilities.SettingsManager.Contract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaCore.Utilities.SettingsManager
{
    public class ConfigurationSettings : IConfigurationSettings
    {
        private readonly IConfiguration _configuration;

        public ConfigurationSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Issuer()
        {
            return _configuration["AuthentificationSettings:Issuer"];
        }

        public string Audience()
        {
            return _configuration["AuthentificationSettings:Audience"];
        }

        /// <summary>
        /// Contraseña de autenticacion del jwt se debe validar que la contraseña tenga la suficiente dificultad o dara error.
        /// </summary>
        /// <returns></returns>
        public string SigninKey()
        {
            return _configuration["AuthentificationSettings:SigninKey"];
        }
    }
}
