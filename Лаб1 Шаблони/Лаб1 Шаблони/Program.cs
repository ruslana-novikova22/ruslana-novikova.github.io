/*Варіант 4. Розробити клас підсистеми для завантаження даних про онлайн зустріч (дата, опис, URL, список учасників) 
 * та списку всіх користувачів системи (ID, Ім'я, аватар) з файлів в форматі JSON та XML. 
 * Визначення типу файлу визначається при запуску системи. Передбачити, що дані про кожну зустріч та кожного 
 * користувача зберігаються в окремих файлах. Файл зустрічі містить імена файлів - учасників цієї зустрічі.*/

using System.Text;

string fileName = "meeting.xml";
Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("♔");

MeetingReader reader = MeetingReader.Create(fileName);
var events = reader.ReadFromFile(fileName);

foreach (var e in events)
    Console.WriteLine(e);
Console.ReadLine();