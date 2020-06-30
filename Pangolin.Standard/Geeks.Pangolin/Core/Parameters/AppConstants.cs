using System;
using System.IO;
using System.Reflection;

namespace Geeks.Pangolin.Core.Parameters
{
    public class AppConstants
    {
        #region [Property]

        public static TimeSpan DefaultTimeOut = TimeSpan.FromSeconds(4);

        public static TimeSpan DefaultCommandTimeOut = TimeSpan.FromMinutes(5);

        public static int ChromeServicePort = 9516;

        public static int IEServicePort = 9517;

        public static int FirefoxServicePort = 9518;

        public static string DllPath = Assembly.GetExecutingAssembly().Location;

        public static string ProjectPath = Directory.GetParent(AppContext.BaseDirectory).FullName;

        public static System.Drawing.Size BrowserSize = new System.Drawing.Size() { Width = 1920, Height = 1080 };

        #endregion
    }
}
