namespace Geeks.Pangolin.Core.Exception
{
    public class NoSuchBrowserException : System.Exception
    {
        public NoSuchBrowserException(string browserName) : base("No such browser: " + browserName)
        {
        }
    }
}
