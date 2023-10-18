/*19) Елементи колекції «Авіарейси» мають наступну структуру: номер рейсу, пункт відправлення, пункт
прибуття, час відправлення, час прибуття, ціна. У колекції «Квитки» міститься номер квитка, номер
рейсу, дата, місце.
a) Вивести пункти призначення, у які придбано квитки у заданий день на задане місце.
b) Вивести номери рейсів, їх тривалість та загальну кількість проданих на рейс квитків протягом
останнього року, впорядкувавши записи по тривалості рейсів.
c) Зберегти дані однієї з колекцій в xml-файлі.*/

using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

class Program
{
    static void Main()
    {
        //Вивести пункти призначення, у які придбано квитки у заданий день на задане місце.
        List<Ticket> tickets = GetTickets();
        DateTime desiredDate = new DateTime(2022, 12, 29); 
        string desiredPlace = "Місце 30С"; 

        var destinations = tickets
            .Where(ticket => ticket.Date == desiredDate && ticket.Place == desiredPlace)
            .Select(ticket => ticket.Flight.Destination)
            .Distinct();

        foreach (var destination in destinations)
        {
            Console.WriteLine(destination);
        }

        //Вивести номери рейсів, їх тривалість та загальну кількість проданих на рейс квитків протягом
        //останнього року, впорядкувавши записи по тривалості рейсів.
        List<Flight> flights = GetFlights();

        DateTime oneYearAgo = DateTime.Now.AddYears(-1);

        var flightStats = flights
            .Where(flight => flight.DepartureTime > oneYearAgo)
            .GroupBy(flight => flight.FlightNumber)
            .Select(group => new
            {
                FlightNumber = group.Key,
                Duration = (int)(group.Max(flight => flight.ArrivingTime) - group.Min(flight => flight.DepartureTime)).TotalMinutes,
                TotalTicketsSold = group.Count()
            })
            .OrderBy(stat => stat.Duration);

        foreach (var stat in flightStats)
        {
            Console.WriteLine($"Номер рейсу: {stat.FlightNumber}, Тривалiсть: {stat.Duration}, Продана кiлькiсть квиткiв: {stat.TotalTicketsSold}");
        }

        //Зберегти дані однієї з колекцій в xml-файлі.
        List<Flight> flightsXml = GetFlights();

        string filePath = "flights.xml";

        SerializeFlightsToXml(flightsXml, filePath);
        Console.WriteLine($"Flight data has been saved to {filePath}");
    }
    class Flight
    {
        public int FlightNumber;
        public string Departure;
        public string Destination;
        public DateTime DepartureTime;
        public DateTime ArrivingTime;
        public int Price;
    }

    class Ticket
    {
        public int TicketNumber;
        public Flight Flight;
        public DateTime Date;
        public string Place;
    }

    static List<Ticket> GetTickets()
    {
        return new List<Ticket>
        {
            new Ticket
            {
                TicketNumber = 1,
                Flight = new Flight
                {
                    FlightNumber = 2,
                    Departure = "Ужгород",
                    Destination = "Лондон",
                    DepartureTime = new DateTime(2023, 9, 23, 10, 0, 0),
                    ArrivingTime = new DateTime(2023, 9, 23, 12, 27, 0),
                    Price = 1200
                },
                Date = new DateTime(2023, 9, 23),
                Place = "Місце 23А"
            },
            new Ticket
            {
                TicketNumber = 2,
                Flight = new Flight
                {
                    FlightNumber = 5,
                    Departure = "Ужгород",
                    Destination = "Мадрид",
                    DepartureTime = new DateTime(2021, 6, 17, 7, 30, 0),
                    ArrivingTime = new DateTime(2021, 6, 17, 10, 42, 0),
                    Price = 1700
                },
                Date = new DateTime(2021, 6, 17),
                Place = "Місце 14В"
            },
            new Ticket
            {
                TicketNumber = 3,
                Flight = new Flight
                {
                    FlightNumber = 28,
                    Departure = "Київ",
                    Destination = "Прага",
                    DepartureTime = new DateTime(2023, 2, 7, 15, 54, 0),
                    ArrivingTime = new DateTime(2023, 2, 7, 17, 02, 0),
                    Price = 800
                },
                Date = new DateTime(2023, 2, 7),
                Place = "Місце 8А"
            },
            new Ticket
            {
                TicketNumber = 2,
                Flight = new Flight
                {
                    FlightNumber = 16,
                    Departure = "Маріуполь",
                    Destination = "Франкфурт",
                    DepartureTime = new DateTime(2022, 12, 29, 14, 14, 0),
                    ArrivingTime = new DateTime(2022, 12, 29, 16, 36, 0),
                    Price = 1700
                },
                Date = new DateTime(2022, 12, 29),
                Place = "Місце 30С"
            },
        };
    }
    static List<Flight> GetFlights()
    {
        return new List<Flight>
        {
            new Flight
            {
                FlightNumber = 2,
                Departure = "Ужгород",
                Destination = "Лондон",
                DepartureTime = new DateTime(2023, 9, 23, 10, 0, 0),
                ArrivingTime = new DateTime(2023, 9, 23, 12, 27, 0),
                Price = 1200
            },
            new Flight
            {
                FlightNumber = 5,
                Departure = "Ужгород",
                Destination = "Мадрид",
                DepartureTime = new DateTime(2021, 6, 17, 7, 30, 0),
                ArrivingTime = new DateTime(2021, 6, 17, 10, 42, 0),
                Price = 1700
            },
            new Flight
            {
                FlightNumber = 28,
                Departure = "Київ",
                Destination = "Прага",
                DepartureTime = new DateTime(2023, 2, 7, 15, 54, 0),
                ArrivingTime = new DateTime(2023, 2, 7, 17, 02, 0),
                Price = 800
            },
            new Flight
            {
                FlightNumber = 16,
                Departure = "Маріуполь",
                Destination = "Франкфурт",
                DepartureTime = new DateTime(2022, 12, 29, 14, 14, 0),
                ArrivingTime = new DateTime(2022, 12, 29, 16, 36, 0),
                Price = 1700
            },
        };
    }

    static void SerializeFlightsToXml(List<Flight> flightsXml, string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Flight>));

        using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
        {
            serializer.Serialize(fileStream, flightsXml);
        }
    }
}

