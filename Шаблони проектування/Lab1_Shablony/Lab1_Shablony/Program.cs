/*Варіант 4.Розробити клас підсистеми для завантаження даних про онлайн зустріч (дата, опис, URL, список учасників)
 * та списку всіх користувачів системи (ID, Ім'я, аватар) з файлів в форматі JSON та XML. 
 * Визначення типу файлу визначається при запуску системи. Передбачити, що дані про кожну зустріч та кожного 
 * користувача зберігаються в окремих файлах. Файл зустрічі містить імена файлів - учасників цієї зустрічі.*/

using System.Text.Json;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;

public interface IJsonDataReader
{
    Meeting ReadData<Meeting>(string filePath);
}

public interface IXmlDataReader<User>
{
    List<User> ReadData(string filePath);
}
public class JsonDataReader : IJsonDataReader
{
    public Meeting ReadData<Meeting>(string filePath)
    {
        if (File.Exists(filePath))
        {
            string jsonText = File.ReadAllText(filePath);
            Meeting data = JsonConvert.DeserializeObject<Meeting>(jsonText);
            return data;
        }
        else
        {
            throw new FileNotFoundException("File not found");
        } 
    }
}

public class XmlDataReader<User> : IXmlDataReader<User>
{
    public List<User> ReadData(string filePath)
    {
        List<User> data;

        using (var streamReader = new StreamReader(filePath))
        {
            var serializer = new XmlSerializer(typeof(List<User>), new XmlRootAttribute("Users"));
            data = (List<User>)serializer.Deserialize(streamReader);
        }

        return data;
    }
}

public class DataReaderFactory
{
    public static IJsonDataReader CreateJsonDataReader()
    {
        return new JsonDataReader();
    }

    public static IXmlDataReader<User> CreateXmlDataReader()
    {
        return new XmlDataReader<User>();
    }
}
public class Meeting
{
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }

    [XmlArray("Participants")]
    [XmlArrayItem("Participant")]
    public List<string> Participants { get; set; }
}

public class User
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Avatar { get; set; }
}
public class MeetingLoader
{
    private IJsonDataReader jsonDataReader;

    public MeetingLoader(IJsonDataReader jsonDataReader)
    {
        this.jsonDataReader = jsonDataReader;
    }

    public Meeting LoadMeetingData(string filePath)
    {
        return jsonDataReader.ReadData<Meeting>(filePath);
    }
}

public class UserLoader
{
    private IXmlDataReader<User> xmlDataReader;

    public UserLoader(IXmlDataReader<User> xmlDataReader)
    {
        this.xmlDataReader = xmlDataReader;
    }

    public List<User> LoadUserData(string filePath)
    {
        return xmlDataReader.ReadData(filePath);
    }
}

class Program
{
    static void Main()
    {
        var jsonDataReader = DataReaderFactory.CreateJsonDataReader();
        var meetingLoader = new MeetingLoader(jsonDataReader);

        var xmlDataReader = DataReaderFactory.CreateXmlDataReader();
        var userLoader = new UserLoader(xmlDataReader);

        var meeting = meetingLoader.LoadMeetingData("meeting.json");
        Console.WriteLine("Meeting Date: " + meeting.Date);
        Console.WriteLine("Meeting Description: " + meeting.Description);
        Console.WriteLine("Meeting URL: " + meeting.Url);
        Console.WriteLine("Meeting Participants:");
        foreach (var participant in meeting.Participants)
        {
            Console.WriteLine(participant);
        }

        List<User> users = userLoader.LoadUserData("user.xml");
        foreach (var user in users)
        {
            Console.WriteLine("User ID: " + user.ID);
            Console.WriteLine("User Name: " + user.Name);
            Console.WriteLine("User Avatar: " + user.Avatar);
            Console.WriteLine();
        }
    }
}


