namespace Geeks.Pangolin.Core.Helper.ClipboardManager
{
    public interface IClipboardManager
    {
        void SetText(string key, string value);
        string GetText(string key);
    }
}
