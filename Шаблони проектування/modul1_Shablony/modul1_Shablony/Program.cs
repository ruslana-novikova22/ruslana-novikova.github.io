/*Об’єкт Рахунок в банку (ПІБ власника, ІПН, сума на рахунку) містить метод
Оплатити (Призначення, дата, сума), та Поповнити рахунок (сума). Реалізувати
фінансовий моніторинг за користувачем: при кожній оплаті, сума якої
перевищує неоподаткований мінімум (17 грн.), надсилати дані до податкової
інспекції.
Вказати шаблон, який доцільно використати для розв'язування задачі.*/

//В цій задачі я використала шаблон Декоратор, бо він дозволяє додати новий функціонал до об'єкта без зміни структури коду.
//Ми створили декоратор для Рахунка у банку і додали до нього функції оплати і поповнення рахунку

using System;

interface IBankAccount
{
    void AccountInfo();
}

class BankAccount : IBankAccount
{
    private string Surname;
    private string IPN;
    private double Balance;

    public BankAccount(string surname, string ipn, double balance)
    {
        Surname= surname;
        IPN= ipn;
        Balance = balance;
    }

    public void AccountInfo()
    {
        Console.WriteLine($"Власник: {Surname}, ІПН: {IPN}, Сума на рахунку: {Balance}");
    }
}

class PaymentDecorator : IBankAccount
{
    private IBankAccount BankAccount;
    private string Purpose;
    private DateTime Date;
    private double Amount;

    public PaymentDecorator(IBankAccount bankAccount, string purpose, DateTime date, double amount)
    {
        BankAccount = bankAccount;
        Purpose = purpose;
        Date = date;
        Amount = amount;
    }

    public void AccountInfo()
    {
        Console.WriteLine("Виконано оплату:");
        Console.WriteLine($"Призначення: {Purpose}");
        Console.WriteLine($"Дата: {Date}");
        Console.WriteLine($"Сума: {Amount}");
        BankAccount.AccountInfo();

        if (Amount > 17.0)
        {
            SendToInspection(Amount);
        }
    }

    private void SendToInspection(double amount)
    {
        Console.WriteLine($"Дані відправлені до податкової інспекції за оплату у розмірі {amount} грн.");
    }
}

class DepositDecorator : IBankAccount
{
    private IBankAccount BankAccount;
    private double Deposit;

    public DepositDecorator(IBankAccount bankAccount, double amount)
    {
        BankAccount = bankAccount;
        Deposit = amount;
    }

    public void AccountInfo()
    {
        Console.WriteLine("Поповнено рахунок на суму: " + Deposit);
        BankAccount.AccountInfo();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введіть ваше ім'я: ");
        string surname = Console.ReadLine();

        Console.Write("Введіть ваш ІПН: ");
        string ipn = Console.ReadLine();

        Console.Write("Введіть початковий баланс рахунку: ");
        double balance = double.Parse(Console.ReadLine());

        IBankAccount account = new BankAccount(surname, ipn, balance);

        while (true)
        {
            Console.WriteLine("\nОберіть опцію:");
            Console.WriteLine("1. Оплатити");
            Console.WriteLine("2. Поповнити рахунок");
            Console.WriteLine("3. Вийти");
            Console.Write("Ваш вибір: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Введіть призначення оплати: ");
                string purpose = Console.ReadLine();

                Console.Write("Введіть дату оплати: ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.Write("Введіть суму оплати: ");
                double amount = double.Parse(Console.ReadLine());

                account = new PaymentDecorator(account, purpose, date, amount);
            }
            else if (choice == 2)
            {
                Console.Write("Введіть суму поповнення рахунку: ");
                double depositAmount = double.Parse(Console.ReadLine());

                account = new DepositDecorator(account, depositAmount);
            }
            else if (choice == 3)
            {
                break;
            }
        }

        Console.WriteLine("\nЗагальна інформація про рахунок:");
        account.AccountInfo();
    }
}

