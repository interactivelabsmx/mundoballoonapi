using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Web;

namespace MundoBalloonApi.graphql
{
    
    public static class ServicesAuthenticationStartup
    {
        
        /// <summary>
        /// Get the key storage directory based on the current environment.
        /// </summary>
        private static string GetKeyStorageDirectoryBasedOnEnvironment()
        {
            string? homePath = Environment.GetEnvironmentVariable("HOME");
            string appPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string? localAppDataPath = Environment.GetEnvironmentVariable("LOCALAPPDATA");
            string? userProfilePath = Environment.GetEnvironmentVariable("USERPROFILE");

            // For Azure
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WEBSITE_INSTANCE_ID")))
            {
                if (!string.IsNullOrEmpty(homePath))
                    return GetKeyStorageDirectoryFromBasePath(homePath);
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && !string.IsNullOrEmpty(appPath))
                return GetKeyStorageDirectoryFromBasePath(appPath);

            if (localAppDataPath != null)
                return GetKeyStorageDirectoryFromBasePath(localAppDataPath);

            if (userProfilePath != null)
                return GetKeyStorageDirectoryFromBasePath(Path.Combine(userProfilePath, "AppData", "Local"));

            if (homePath != null)
            {
                return Path.Combine(homePath, ".aspnet", "DataProtection-Keys");
            }

            if (string.IsNullOrEmpty(appPath))
                return "";

            return GetKeyStorageDirectoryFromBasePath(appPath);
        }
        
        private static string GetKeyStorageDirectoryFromBasePath(string basePath)
            => Path.Combine(basePath, "ASP.NET", "DataProtection-Keys");

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var path = GetKeyStorageDirectoryBasedOnEnvironment();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "mbuid.AuthUser";
                    options.Cookie.HttpOnly = false;
                });
        }
    }
}