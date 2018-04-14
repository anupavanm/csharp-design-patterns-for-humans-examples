using System;

namespace ChainOfResponsibilityPattern
{
  abstract class Account
  {
    private Account mSuccessor;
    protected decimal mBalance;

    public void SetNext(Account account)
    {
      mSuccessor = account;
    }

    public void Pay(decimal amountTopay)
    {
      if (CanPay(amountTopay))
      {
        Console.WriteLine("Paid {0:c} using {1}.", amountTopay, this.GetType().Name);
      }
      else if (this.mSuccessor != null)
      {
        Console.WriteLine("Cannot pay using {0}. Proceeding..", this.GetType().Name);
        mSuccessor.Pay(amountTopay);
      }
      else
      {
        throw new Exception("None of the accounts have enough balance");
      }
    }
    private bool CanPay(decimal amount)
    {
      return mBalance >= amount ? true : false;
    }
  }

  class Bank : Account
  {
    public Bank(decimal balance)
    {
      this.mBalance = balance;
    }
  }

  class Paypal : Account
  {
    public Paypal(decimal balance)
    {
      this.mBalance = balance;
    }
  }

  class Bitcoin : Account
  {
    public Bitcoin(decimal balance)
    {
      this.mBalance = balance;
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      // Let's prepare a chain like below
      //      $bank->$paypal->$bitcoin
      //
      // First priority bank
      //      If bank can't pay then paypal
      //      If paypal can't pay then bit coin
      var bank = new Bank(100);          // Bank with balance 100
      var paypal = new Paypal(200);      // Paypal with balance 200
      var bitcoin = new Bitcoin(300);    // Bitcoin with balance 300

      bank.SetNext(paypal);
      paypal.SetNext(bitcoin);

      // Let's try to pay using the first priority i.e. bank
      bank.Pay(259);
      // Output will be
      // ==============
      // Cannot pay using bank. Proceeding ..
      // Cannot pay using paypal. Proceeding ..:
      // Paid 259 using Bitcoin!

      Console.ReadLine();
    }
  }
}
