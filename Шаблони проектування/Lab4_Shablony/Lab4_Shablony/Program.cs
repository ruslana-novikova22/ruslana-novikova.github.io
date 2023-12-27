using System;
using System.Collections.Generic;

public interface IObserver
{
    void Update(string newsTitle);
}

public class NewsSubscriber : IObserver
{
    private string name;

    public NewsSubscriber(string name)
    {
        this.name = name;
    }

    public void Update(string newsTitle)
    {
        Console.WriteLine($"{name} отримав(ла) повiдомлення: {newsTitle}");
    }
}

public interface IObservable
{
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers(string newsTitle);
}

public class News : IObservable
{
    public string Title { get; }
    public string[] Topics { get; }
    public string Text { get; }
    public string VideoUrl { get; }

    private List<IObserver> observers = new List<IObserver>();

    public News(string title, string[] topics, string text, string videoUrl)
    {
        Title = title;
        Topics = topics;
        Text = text;
        VideoUrl = videoUrl;
    }

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers(string newsTitle)
    {
        foreach (var observer in observers)
        {
            observer.Update(newsTitle);
        }
    }

    public void Publish()
    {
        string newsTitle = Title;
        NotifyObservers(newsTitle);
    }
}

class Program
{
    static void Main()
    {
        IObserver textNewsSubscriber = new NewsSubscriber("Текстовий пiдписник");
        IObserver videoNewsSubscriber = new NewsSubscriber("Вiдео пiдписник");
        IObserver topicSubscriber = new NewsSubscriber("Пiдписник за темою");

        News news = new News("Заголовок новини", new string[] { "полiтика", "економiка" }, "Текст новини", "URL відео");

        Console.WriteLine("Оберiть тему для пiдписки: 1 - Текстовi новини, 2 - Вiдео новини, 3 - Полiтика");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                news.AddObserver(textNewsSubscriber);
                break;
            case "2":
                news.AddObserver(videoNewsSubscriber);
                break;
            case "3":
                news.AddObserver(topicSubscriber);
                break;
            default:
                Console.WriteLine("Невiрний вибiр.");
                break;
        }

        news.Publish();

        Console.WriteLine("Обновити новини? (Y/N)");
        string updateChoice = Console.ReadLine();

        if (updateChoice.ToUpper() == "Y")
        {
            news.Publish();
        }

        Console.WriteLine("Бажаєте вiдписатися вiд новин? (Y/N)");
        string unsubscribeChoice = Console.ReadLine();

        if (unsubscribeChoice.ToUpper() == "Y")
        {
            Console.WriteLine("Оберiть тему для вiдписки: 1 - Текстовi новини, 2 - Вiдео новини, 3 - Полiтика");
            string unsubscribeTopic = Console.ReadLine();

            switch (unsubscribeTopic)
            {
                case "1":
                    news.RemoveObserver(textNewsSubscriber);
                    break;
                case "2":
                    news.RemoveObserver(videoNewsSubscriber);
                    break;
                case "3":
                    news.RemoveObserver(topicSubscriber);
                    break;
                default:
                    Console.WriteLine("Невiрний вибiр.");
                    break;
            }
        }

        Console.ReadKey();
    }
}
