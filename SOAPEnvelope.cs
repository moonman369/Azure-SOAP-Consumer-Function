using System;
using System.Text;
using System.Xml.Serialization;

namespace Moonman.SOAP
{

    public class NumToWords
    {
        [XmlElement("num")]
        public int Num { get; set; }

        // [XmlAttribute("xmlns")]
        // public string Xmlns { get; set; } = "http://tempuri.org/";

    }


    public class SoapBody
    {
        // [XmlAttribute("xmlns:xsi")]
        // public string XmlnsXsi { get; set; } = "http://www.w3.org/2001/XMLSchema-instance";

        [XmlElement("NumToWords", Namespace = "http://tempuri.org/")]
        public NumToWords Content { get; set; }
    }



    [XmlRoot("Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class SoapEnvelope
    {
        // [XmlAttribute("xmlns:soap")]
        // public string XmlnsSoap { get; set; } = "http://schemas.xmlsoap.org/soap/envelope/";

        // [XmlAttribute("xmlns")]
        // public string Xmlns { get; set; } = "http://schemas.xmlsoap.org/soap/envelope/";

        [XmlElement("Body")]
        public SoapBody Body { get; set; }
    }


    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }


}