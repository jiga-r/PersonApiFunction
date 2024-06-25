using System.Xml.Serialization;

[XmlRoot("Person")]
public class Person
{
    [XmlElement("Name")]
    public string Name { get; set; }

    [XmlElement("Address")]
    public string Address { get; set; }

    [XmlElement("Phone")]
    public string Phone { get; set; }

    [XmlElement("DateOfBirth")]
    public string DateOfBirth { get; set; }
}
