/*Варіант 4.
Сформувати файл “Halereya.xml”, що містить інформацію про дані з полями: код; прізвище
художника; назва картини; ціна; ознака: 1 – картина в експозиції; 2 – картина в запаснику; 3 – картина на “виїзді”.

 Переглянути файл на консолі;
 За кодом вивести на консоль прізвище художника, назву картини та її ціну.
 Обчислити сумарну ціну усіх картин, що містяться в запаснику.*/

using System;
using System.Diagnostics;
using System.Xml;

class Program 
{
    static void Main()
    {

        //Створюємо xml документ
        XmlDocument document = new XmlDocument();

        XmlElement element = document.CreateElement("Halereya");
        document.AppendChild(element);

        //Дані
        AddPaint(document, element, 1, "Williams", "Sunrise", 567438, 2);
        AddPaint(document, element, 2, "Smith", "Apples", 937284, 1);
        AddPaint(document, element, 3, "Jameson", "Sea", 1648293, 1);
        AddPaint(document, element, 4, "Atlas", "Lady", 638290, 3);
        AddPaint(document, element, 5, "Miller", "Dance", 2657313, 2);
        AddPaint(document, element, 6, "Cora", "Fantasy", 5372812, 3);
        AddPaint(document, element, 7, "Wilder", "Magic", 427184, 1);
        AddPaint(document, element, 8, "Jones", "Moves", 184632, 3);
        AddPaint(document, element, 9, "Watson", "Night", 748294, 2);

        document.Save("Halereya.xml");

        Console.WriteLine("Halereya.xml file created successfully.");

        //Переглянути файл на консолі
        Console.WriteLine("Information about paints:");
        XmlNodeList paints = element.ChildNodes;
        foreach (XmlNode pa in paints)
        {
            int code = int.Parse(pa.Attributes["Code"].Value);
            string lastName = pa.Attributes["LastName"].Value;
            string nameOfPaint = pa.Attributes["NameOfPaint"].Value;
            int price = int.Parse(pa.Attributes["Price"].Value);
            int feature = int.Parse(pa.Attributes["Feature"].Value);

            Console.WriteLine($"Code: {code} Surename: {lastName}, Name of paint: {nameOfPaint}, Price: {price}, Feature: {feature}");
        }

        //За кодом вивести на консоль прізвище художника, назву картини та її ціну.
        Console.Write("Enter the code:");
        int searchCode = int.Parse(Console.ReadLine());

        XmlNode searchedPaint = FindPaintByCode(element, searchCode);
        if (searchedPaint != null)
        {
            string LastName = searchedPaint.Attributes["LastName"].Value;
            string NameOfPaint = searchedPaint.Attributes["NameOfPaint"].Value;
            int Price = int.Parse(searchedPaint.Attributes["Price"].Value);

            Console.WriteLine($"Surename: {LastName}, Name of paint: {NameOfPaint}, Price: {Price}");
        }
        else
            Console.WriteLine("Paint is not found");

        //Обчислити сумарну ціну усіх картин, що містяться в запаснику.

        int Sum = 0;
        XmlNodeList totalPrice = element.ChildNodes;
        foreach(XmlNode pa in totalPrice)
        {
            int feature = int.Parse(pa.Attributes["Feature"].Value);
            int price = int.Parse(pa.Attributes["Price"].Value);

            if (feature == 2)
            {
                Sum += price;
            }
        }
        Console.WriteLine($"Сумарна цiна в запаснику: {Sum}");
    }
    static void AddPaint(XmlDocument document, XmlElement element, int code, string lastname, string nameOfPaint, int price, int feature)
    {
        XmlElement paintElement = document.CreateElement("Paint");

        paintElement.SetAttribute("Code", code.ToString());
        paintElement.SetAttribute("LastName", lastname);
        paintElement.SetAttribute("NameOfPaint", nameOfPaint);
        paintElement.SetAttribute("Price", price.ToString());
        paintElement.SetAttribute("Feature", feature.ToString());

        element.AppendChild(paintElement);
    }
    static XmlNode FindPaintByCode(XmlElement element, int code)
    {
        XmlNodeList paints = element.ChildNodes;
        foreach(XmlNode pa in paints)
        {
            int paintingCode = int.Parse(pa.Attributes["Code"].Value);
            if(paintingCode == code)
            {
                return pa;
            }
        }
        return null;
    }
}



