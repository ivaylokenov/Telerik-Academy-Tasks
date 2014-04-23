namespace Bank
{
    class DepositAccount : Account, IAccount, IDepositable, IWithdrawable
    {
        //withdrawing money
        public void WithdrawMoney(decimal money)
        {
            if (money < 0 || money > this.balance)
            {
                throw new System.ArgumentException("Invalid money. They should be positive number belowe the total account balance!");
            }

            this.balance -= money;
        }

        //constructor
        public DepositAccount(Customer customer, decimal interest, int months)
        {
            this.customer = customer;
            this.interestRate = interest;

            if (months < 0)
            {
                throw new System.ArgumentException("Months cannot be less than 0!");
            }

            this.monthsOfUsage = months;
        }

        //calculating interest
        public override decimal CalculateInterest()
        {
            if (balance < 1000)
            {
                return 0;
            }
            else
            {
                return base.CalculateInterest();
            }
        }
    }
}
