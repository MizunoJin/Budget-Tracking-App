using System.Xml.Linq;
using Budget_Tracking_App.Interfaces;

namespace Budget_Tracking_App.Repositories
{
    public class XmlFileRepository : ILogRepository
    {
        private readonly string filePath = "log.xml";

        public void Log(string message)
        {
            XDocument xDocument;
            XElement rootElement;

            if (File.Exists(filePath))
            {
                xDocument = XDocument.Load(filePath);
                rootElement = xDocument.Element("Logs");
            }
            else
            {
                xDocument = new XDocument();
                rootElement = new XElement("Logs");
                xDocument.Add(rootElement);
            }

            XElement logEntry = new XElement("Log",
                new XElement("Date", DateTime.Now.ToString()),
                new XElement("Message", message));

            rootElement.Add(logEntry);
            xDocument.Save(filePath);
        }
    }
}
