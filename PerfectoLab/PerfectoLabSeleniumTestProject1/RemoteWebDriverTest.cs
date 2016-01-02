using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;


namespace PerfectoLabSeleniumTestProject1
{
    /// <summary>
    /// Summary description for MobileRemoteTest
    /// </summary>
    [TestClass]
    public class RemoteWebDriverTest
    {
        private RemoteWebDriverExtended driver;

        [TestInitialize]
        public void PerfectoOpenConnection()
        {
            var browserName = "mobileOS";
            var host = ConfigurationManager.AppSettings.Get("myHost");

            DesiredCapabilities capabilities = new DesiredCapabilities(browserName, string.Empty, new Platform(PlatformType.Any));
            capabilities.SetCapability("user", ConfigurationManager.AppSettings.Get("myUser"));

            //TODO: Provide your password
            capabilities.SetCapability("password", ConfigurationManager.AppSettings.Get("myPassword"));

            //TODO: Provide your device ID
            capabilities.SetCapability("deviceName", ConfigurationManager.AppSettings.Get("myDevice"));

            capabilities.SetPerfectoLabExecutionId(host);

            var url = new Uri(string.Format("https://{0}/nexperience/perfectomobile/wd/hub", host));
            driver = new RemoteWebDriverExtended(new HttpAuthenticatedCommandExecutor(url), capabilities);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
        }

        [TestCleanup]
        public void PerfectoCloseConnection()
        {
            driver.Close();

            // In case you want to download the report or the report attachments, do it here.
            //try
            //{
            //    driver.DownloadReport(DownloadReportTypes.pdf, "C:\\test\\report");
            //    driver.DownloadAttachment(DownloadAttachmentTypes.video, "C:\\test\\report\\video", "flv");
            //    driver.DownloadAttachment(DownloadAttachmentTypes.image, "C:\\test\\report\\images", "jpg");
            //}
            //catch (Exception ex)
            //{
            //    Trace.WriteLine(string.Format("Error getting test logs: {0}", ex.Message));
            //}

            driver.Quit();
        }

        [TestMethod]
        public void WebDriverTestMethod()
        {
            //Write your test here
        }
    }
}
