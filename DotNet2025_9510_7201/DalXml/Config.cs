using System.Xml.Linq;

namespace Dal;
internal static class Config
{
    private const string s_config_xml = "data-config";

    public static int barcode;
    public static int idSale;
   
        public static int getBrcode()
        {
            // ??איזה ניתוב
            string filePath = $@"..\xml\{s_config_xml}.xml";
            XElement root = XElement.Load(filePath);

            int currentId = (int)root.Element("barcode")!;

            root.Element("barcode")!.SetValue(currentId + 10);

            root.Save(filePath);

            return currentId; 
        }

    public static int GetIdSale()
    {
        // ??איזה ניתוב
        string filePath = $@"..\xml\{s_config_xml}.xml";
        XElement root = XElement.Load(filePath);

        int currentId = (int)root.Element("barcode")!;

        root.Element("barcode")!.SetValue(currentId + 10);

        root.Save(filePath);

        return currentId;
    }

}