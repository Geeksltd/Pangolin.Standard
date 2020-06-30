using Geeks.Pangolin.Core.Helper.ClipboardManager;
using Geeks.Pangolin.Core.Helper.FileProvider;

namespace Geeks.Pangolin.Core.Helper.Context
{
    public class Context
    {
        public Config Config { get; set; } = new Config();
        public IFileFullPathProvider FileFullPathProvider { get; set; }
        public IClipboardManager ClipboardManager { get; set; }
    }
}
