/*Варіант 4. Розробити клас підсистеми для завантаження даних про онлайн зустріч (дата, опис, URL, список учасників) 
 * та списку всіх користувачів системи (ID, Ім'я, аватар) з файлів в форматі JSON та XML. 
 * Визначення типу файлу визначається при запуску системи. Передбачити, що дані про кожну зустріч та кожного користувача 
 * зберігаються в окремих файлах. Файл зустрічі містить імена файлів - учасників цієї зустрічі.*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public interface IMeetingData
{
    DateTime Date { get; set; }
    string Description { get; set; }
    string URL { get; set; }
    List<string> Participants { get; set; }
}

public interface IUserData
{
    int ID { get; set; }
    string Name { get; set; }
    string Avatar { get; set; }
}

public class MeetingData : IMeetingData
{
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public string URL { get; set; }
    public List<string> Participants { get; set; }
}

public class UserData : IUserData
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Avatar { get; set; }
}

public class XmlDataLoader<Meeting>
{
    public Meeting LoadData(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File not found: {filePath}");
            return default(Meeting);
        }

        using (var reader = new StreamReader(filePath))
        {
            var serializer = new XmlSerializer(typeof(Meeting));
            return (Meeting)serializer.Deserialize(reader);
        }
    }
}

class Program
{
    static void Main()
    {
        var meetingLoader = new XmlDataLoader<MeetingData>();
        var userLoader = new XmlDataLoader<UserData>();

        var meetingData = meetingLoader.LoadData("meeting.xml");
        var userData = userLoader.LoadData("user.xml");

        if (meetingData != null)
        {
            Console.WriteLine("Meeting Date: " + meetingData.Date.ToShortDateString());
            Console.WriteLine("Meeting Description: " + meetingData.Description);
            Console.WriteLine("Meeting URL: " + meetingData.URL);
            Console.WriteLine("Meeting Participants: " + string.Join(", ", meetingData.Participants));
        }
        else
        {
            Console.WriteLine("Meeting data is null. Check if the file exists and is valid.");
        }

        if (userData != null)
        {
            Console.WriteLine("User ID: " + userData.ID);
            Console.WriteLine("User Name: " + userData.Name);
            Console.WriteLine("User Avatar: " + userData.Avatar);
        }
        else
        {
            Console.WriteLine("User data is null. Check if the file exists and is valid.");
        }
    }
}


