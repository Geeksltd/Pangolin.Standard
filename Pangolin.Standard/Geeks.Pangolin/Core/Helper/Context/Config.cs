using System;
using System.IO;

namespace Geeks.Pangolin.Core.Helper.Context
{
    public class Config
    {
        public TimeSpan Timeout { get; set; } = 10.Seconds();
        public TimeSpan WaitUntilTimeout { get; set; } = 10.Seconds();
        public DirectoryInfo DownloadFolder { get; set; }
        public bool UseJavascriptSet { get; set; }
    }
}
