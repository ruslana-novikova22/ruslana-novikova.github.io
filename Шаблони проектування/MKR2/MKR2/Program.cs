/*Клас рахунки абонента провідного інтернету містить баланс, щомісячну
абонплату та обмеження максимальної швидкості (наприклад 100 Мбіт/сек).
Також клас містить методи поповнення рахунку, списання абонплати та метод
підключення до мережі (виводить в консоль повідомлення «Швидкість
підключення Х Мбіт/сек»). Якщо при списанні абонплати виникає
заборгованість то швидкість доступу знижується до 0, відновлюється швидкість
після погашення заборгованості.
*/


using System;

public class SubscriberAccount
{
    private AccountState currentState;

    public double Balance { get; set; }
    public double SubscriptionFee { get; private set; }
    public double MaxSpeed { get; private set; }

    public SubscriberAccount(double balance, double subscriptionFee, double maxSpeed)
    {
        Balance = balance;
        SubscriptionFee = subscriptionFee;
        MaxSpeed = maxSpeed;
        ChangeState(new StandardState());
    }

    public void ReplenishAccount(double amount)
    {
        Balance += amount;
        Console.WriteLine($"Account replenished by {amount}. Balance: {Balance}");
        currentState.Execute(this);
    }

    public void DeductSubscriptionFee()
    {
        currentState.DeductSubscriptionFee(this);
    }

    public void ConnectToNetwork()
    {
        currentState.ConnectToNetwork(this);
    }

    public void ChangeState(AccountState newState)
    {
        currentState = newState;
    }
}

public abstract class AccountState
{
    public abstract void DeductSubscriptionFee(SubscriberAccount account);
    public abstract void ConnectToNetwork(SubscriberAccount account);
    public abstract void Execute(SubscriberAccount account);
}

// Concrete states
public class StandardState : AccountState
{
    public override void DeductSubscriptionFee(SubscriberAccount account)
    {
        if (account.Balance >= account.SubscriptionFee)
        {
            account.Balance -= account.SubscriptionFee;
            Console.WriteLine($"Subscription fee deducted. Balance: {account.Balance}");
            account.ConnectToNetwork();
        }
        else
        {
            Console.WriteLine("Insufficient funds to deduct the subscription fee.");
            account.ChangeState(new ArrearsState());
        }
    }

    public override void ConnectToNetwork(SubscriberAccount account)
    {
        Console.WriteLine($"Connection speed: {account.MaxSpeed} Mbps");
    }

    public override void Execute(SubscriberAccount account)
    {
    }
}

public class ArrearsState : AccountState
{
    public override void DeductSubscriptionFee(SubscriberAccount account)
    {
        Console.WriteLine("Arrears not settled. Access speed reduced to 0.");
    }

    public override void ConnectToNetwork(SubscriberAccount account)
    {
        Console.WriteLine("Access speed: 0 Mbps. Settle arrears to restore speed.");
    }

    public override void Execute(SubscriberAccount account)
    {
    }
}

class Program
{
    static void Main()
    {
        SubscriberAccount account = new SubscriberAccount(20, 50, 100);

        account.ConnectToNetwork();
        account.DeductSubscriptionFee();

        Console.Write("Enter the replenishment amount: ");
        double replenishmentAmount = double.Parse(Console.ReadLine());
        account.ReplenishAccount(replenishmentAmount);

        account.DeductSubscriptionFee();
    }
}


