using System.Collections.Generic;

namespace Geeks.Pangolin.Core.Helper.ClipboardManager
{
    public class ClipboardManager : IClipboardManager
    {
        #region [Property]

        private Dictionary<string, string> Clipboard { get; set; }

        #endregion

        #region [Constructor]

        public ClipboardManager()
        {
            Clipboard = new Dictionary<string, string>();
        }

        #endregion

        #region [Public Method]

        public void SetText(string key, string value) => Clipboard[key] = value;

        public string GetText(string key) => Clipboard.ContainsKey(key) ? Clipboard[key] : throw new System.Exception($"There is no key {key} in Clipboard");

        #endregion

        #region [Private Method]

        #endregion
    }
}
