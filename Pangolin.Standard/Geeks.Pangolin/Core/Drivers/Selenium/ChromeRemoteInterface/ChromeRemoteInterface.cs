using System.Collections.Generic;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Geeks.Pangolin.Core.Drivers.Selenium.ChromeRemoteInterface
{
    public class ChromeRemoteInterface
    {
        #region [Property]

        private readonly RemoteWebDriver driver;

        #endregion

        #region [Constructor]

        public ChromeRemoteInterface(RemoteWebDriver driver)
        {
            this.driver = driver;
            InitializeSendCommand();
        }

        #endregion

        #region [Public Method]

        public void TryEnableFileDownloading(string downloadPath)
        {
            TrySendCommand("Page.setDownloadBehavior", new Dictionary<string, object>()
            {
                ["behavior"] = "allow",
                ["downloadPath"] = downloadPath
            });
        }

        #endregion

        #region [Private Method]

        private void InitializeSendCommand() => WebDriverCommandExecutor.TryAddCommand(driver, "sendCommand", new CommandInfo(CommandInfo.PostCommand, $"/session/{driver.SessionId}/chromium/send_command_and_get_result"));

        private Response TrySendCommand(string cmd, object parameters = null)
        {
            try
            {
                return SendCommand(cmd, parameters);
            }
            catch (TargetInvocationException)
            {
                return null;
            }
        }

        private Response SendCommand(string cmd, object parameters = null)
        {
            var commandParams = new Dictionary<string, object> { { "cmd", cmd }, { "params", parameters ?? new object() } };
            var response = WebDriverCommandExecutor.Execute(driver, "sendCommand", commandParams);
            if (response.Status != WebDriverResult.Success)
                throw new System.Exception(response.Value.ToString());
            return response;
        }

        #endregion
    }
}