using System;
using System.Xml;
using Aquality.Selenium.Core.Logging;

namespace SpecTestProject
{
    public static class RetrievingDataFromFile
    {
        private static readonly XmlDocument TextForTest = new XmlDocument();

        private const string filename = "TextforFirstTest.xml";

        public static string GetPassword() 
        {
            try
            {
                TextForTest.Load(filename);
                Logger.Instance.Info("Getting password for first testcase from file");
                return TextForTest.SelectSingleNode("TextForTest/password").InnerText;
            }
            catch (System.IO.FileNotFoundException) 
            {
                Logger.Instance.Error("Test Data file not found!");
                return null;
            }
        }

        public static string GetEmail() 
        {
            try
            {
                TextForTest.Load(filename);
                Logger.Instance.Info("Getting email for first testcase from file");
                return TextForTest.SelectSingleNode("TextForTest/email").InnerText;
            }
            catch (System.IO.FileNotFoundException) 
            {
                Logger.Instance.Error("Test Data file not found!");
                return null;
            }
        }

        public static string GetDomain()
        {
            try
            {
                TextForTest.Load(filename);
                Logger.Instance.Info("Getting domain for first testcase from file");
                return TextForTest.SelectSingleNode("TextForTest/domain").InnerText;
            }
            catch (System.IO.FileNotFoundException)
            {
                Logger.Instance.Error("Test Data file not found!");
                return null;
            }
        }

        public static string GetDomainExtension()
        {
            try
            {
                TextForTest.Load(filename);
                Logger.Instance.Info("Getting domain extension for first testcase from file");
                return TextForTest.SelectSingleNode("TextForTest/domainextension").InnerText;
            }
            catch (System.IO.FileNotFoundException)
            {
                Logger.Instance.Error("Test Data file not found!");
                return null;
            }
        }

        public static string GetStartUrl()
        {
            try
            {
                TextForTest.Load(filename);
                Logger.Instance.Info("Getting start url for tests from file");
                return TextForTest.SelectSingleNode("TextForTest/url").InnerText;
            }
            catch (System.IO.FileNotFoundException)
            {
                Logger.Instance.Error("Test Data file not found!");
                return null;
            }
        }

        public static string GetFilename()
        {
            try
            {
                TextForTest.Load(filename);
                Logger.Instance.Info("Getting start url for tests from file");
                return TextForTest.SelectSingleNode("TextForTest/filename").InnerText;
            }
            catch (System.IO.FileNotFoundException)
            {
                Logger.Instance.Error("Test Data file not found!");
                return null;
            }
        }

        public static int GetCountOfRandomNumbers()
        {
            try
            {
                TextForTest.Load(filename);
                Logger.Instance.Info("Getting start url for tests from file");
                return Convert.ToInt32(TextForTest.SelectSingleNode("TextForTest/countofrandom").InnerText);
            }
            catch (System.IO.FileNotFoundException)
            {
                Logger.Instance.Error("Test Data file not found!");
                return 0;
            }
        }
    }
}
