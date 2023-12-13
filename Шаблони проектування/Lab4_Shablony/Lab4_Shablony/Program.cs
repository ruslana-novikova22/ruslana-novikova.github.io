/*4. Система публікує новини. Новини бувають в текстовому форматі та відео. 
Кожна новина це об’єкт що містить заголовок, теми новини (масив слів) та текст новини чи  URL відео.
Публікація новини  полягає у додаванні відповідного об'єкту до однієї із 2 колекцій.
Користувач може підписатися на всі текстові новини, на всі відео новини чи тільки текстові новини 
за вказаною темою. При публікації новини надсилати користувачу, згідно з його підпискою, 
повідомлення про новину (в консоль вивести заголовок новини).*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Program
    {
        public class News
        {
            public string Title { get; set; }
            public string[] Topics { get; set; }
        }
        public class Text : News
        {
            public string TextNews { get; set; }
        }
        public class Video : News
        {
            public string VideoUrl { get; set; }
        }
        //Спостерігач
        public interface IUser
        {
            void Update(News news);
        }

        //Об'єкти
        public interface ISystem
        {
            void AttachForText(IUser user);
            void AttachForVideo(IUser user);
            void DetachForText(IUser user);
            void DetachForVideo(IUser user);
            void NotifyText();
            void NotifyVideo();
        }

        public class System: ISystem
        {
            List<IUser> forText = new List<IUser>();
            List<IUser> forVideo = new List<IUser>();
            private List<Text> collectionText = new List<Text>();
            private List<Video> collectionVideo = new List<Video>();
            public void AttachForText(IUser user)
            {
                Console.WriteLine("Attached the user");
                this.forText.Add(user);
            }
            public void AttachForVideo(IUser user)
            {
                Console.WriteLine("Attached the user");
                this.forVideo.Add(user);
            }
            public void DetachForText(IUser user)
            {
                this.forText.Remove(user);
                Console.WriteLine("Remove the user");
            }
            public void DetachForVideo(IUser user)
            {
                this.forVideo.Remove(user);
                Console.WriteLine("Remove the user");
            }
            public void NotifyText()
            {
                Console.WriteLine("Notifying users...");
                foreach(var user in forText)
                {
                    user.Update(collectionText[collectionText.Count - 1]);
                }
            }
            public void NotifyVideo()
            {
                Console.WriteLine("Notifying users...");
                foreach(var user in forVideo)
                {
                    user.Update(collectionVideo[collectionVideo.Count - 1]);
                }
            }

            public void AddTextNews(Text news)
            {
                collectionText.Add(news);
                this.NotifyText();
            }
            public void AddVideoNews(Video news)
            {
                collectionVideo.Add(news);
                this.NotifyVideo();
            }
        }
        public class User: IUser
        {
            private string name;
            public User(string name)
            {
                this.name=name;
            }
            public void Update(News news)
            {
                Console.WriteLine($"{name} received an update: {news.Title}");
            }
            public void SubscribeTextNews(ISystem system)
            {
                system.AttachForText(this);
            }
            public void SubscribeVideoNews(ISystem system)
            {
                system.AttachForVideo(this);
            }
            public void UnsubscribeTextNews(ISystem system)
            {
                system.DetachForText(this);
            }
            public void UnsubscribeVideoNews(ISystem system)
            {
                system.DetachForVideo(this);
            }
        }
        static void Main(string[] args)
        {
            var newsSys = new System();

            User user1 = new User("User1");
            User user2 = new User("User2");

            user1.SubscribeTextNews(newsSys);
            user2.SubscribeVideoNews(newsSys);

            var news1 = new Text
            {
                Title = "Text News 1",
                TextNews = "This is a sample text news."
            };

            var news2 = new Video
            {
                Title = "Video News 1",
                VideoUrl = "https://example.com/sample_video"
            };

            newsSys.AddTextNews(news1);
            newsSys.AddVideoNews(news2);

            user1.UnsubscribeTextNews(newsSys);

            Text anotherTextNews = new Text
            {
                Title = "Text News 2",
                TextNews = "Another sample text news."
            };

            newsSys.AddTextNews(anotherTextNews);
        }
    }
}

