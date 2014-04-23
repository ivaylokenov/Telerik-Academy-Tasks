using System;

namespace Bank
{
    abstract class Account : IAccount, IDepositable
    {
        protected Customer customer;
        protected decimal balance = 0;
        protected decimal interestRate;
        protected int monthsOfUsage;

        public virtual decimal CalculateInterest()
        {
            return this.balance * this.monthsOfUsage * this.interestRate / 100;
        }

        //customer type
        public string CustomerType
        {
            get
            {
                if (customer is Individual)
                {
                    return "Individual";
                }
                else
                {
                    return "Company";
                }
            }
        }

        //balance of account
        public decimal Balance
        {
            get { return this.balance; }
        }

        //get and set interest
        public decimal InterestRate
        {
            get { return this.interestRate; }
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentException("Interest cannot be less than 0!");
                }

                this.interestRate = value;
            }
        }

        public int MonthsOfUsage
        {
            get { return this.monthsOfUsage; }
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentException("Months cannot be less than 0!");
                }

                this.monthsOfUsage = value;
            }
        }

        //deposit money method
        public void DepositMoney(decimal money)
        {
            //check money
            if (money < 0)
            {
                throw new System.ArgumentException("Money must be > 0!");
            }

            this.balance += money;
        }
    }
}
