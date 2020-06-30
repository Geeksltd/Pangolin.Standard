using System.Reflection;

namespace Geeks.Pangolin.Core.Drivers.Selenium.ChromeRemoteInterface
{
    internal static class ReflectionHelper
    {
        #region [Property]

        #endregion

        #region [Constructor]

        #endregion

        #region [Public Method]

        public static T GetProperty<T>(object obj, string property) => (T)obj.GetType().GetProperty(property, BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(obj);

        #endregion

        #region [Private Method]

        #endregion
    }
}