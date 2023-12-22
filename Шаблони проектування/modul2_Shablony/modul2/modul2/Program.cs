/*В системі дистанційного навчання зареєстровані викладачі (ПІБ, звання,
ступінь, кафедра), студенти (ПІБ, курс, спеціальність) та технічні працівники
(ПІБ, посада). Класи не містять методів виведення. Вивести інформацію про
всіх учасників системи за шаблоном:
• к.т.н., Андрашко Ю.В., доцент кафедри САТО
• Іваненеко І.І., студент 3 курсу, спеціальність 113 – прикладна математика
• д.ф.-м.н., Маринець В.В., професор кафедри диференціальних рівнянь
• Роля М.Ю., лаборант*/

using System;
using System.Collections.Generic;

namespace Modul_2
{
    public interface IObserver
    {
        void Update();
    }

    public class System
    {
        private List<IObserver> participants = new List<IObserver>();

        public void AddParticipant(IObserver participant)
        {
            participants.Add(participant);
            participant.Update();
        }
    }

    public class Teacher : IObserver
    {
        private string name;
        private string title;
        private string degree;
        private string department;

        public Teacher(string name, string title, string degree, string department)
        {
            this.name = name;
            this.title = title;
            this.degree = degree;
            this.department = department;
        }

        public void Update()
        {
            Console.WriteLine($"{degree}, {name}, {title} кафедри {department}");
        }
    }

    public class Student : IObserver
    {
        private string name;
        private int course;
        private string specialty;

        public Student(string name, int course, string specialty)
        {
            this.name = name;
            this.course = course;
            this.specialty = specialty;
        }

        public void Update()
        {
            Console.WriteLine($"{name}, студент {course} курсу, спецiальнiсть {specialty}");
        }
    }

    public class TechnicalStaff : IObserver
    {
        private string name;
        private string position;

        public TechnicalStaff(string name, string position)
        {
            this.name = name;
            this.position = position;
        }

        public void Update()
        {
            Console.WriteLine($"{name}, {position}");
        }
    }

    class Program
    {
        static void Main()
        {
            System system = new System();
            system.AddParticipant(new Teacher("Андрашко Ю.В.", "доцент", "к.т.н.", "САТО"));
            system.AddParticipant(new Student("Iваненко I.I.", 3, "113 – прикладна математика"));
            system.AddParticipant(new Teacher("Маринець В.В.", "професор", "д.ф.-м.н.", "диференцiальних рiвнянь"));
            system.AddParticipant(new TechnicalStaff("Роля М.Ю.", "лаборант"));
        }
    }
}
