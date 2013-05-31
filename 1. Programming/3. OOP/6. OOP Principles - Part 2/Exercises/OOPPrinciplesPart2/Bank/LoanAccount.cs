namespace Bank
{
    class LoanAccount : Account, IAccount, IDepositable
    {
        //calculate interest
        public override decimal CalculateInterest()
        {
            if (this.CustomerType == "Individual")
            {
                decimal interest = (this.monthsOfUsage - 3) * this.interestRate * this.balance / 100;
                if (interest < 0)
                {
                    return 0;
                }
                else
                {
                    return interest;
                }
            }
            else
            {
                decimal interest = (this.monthsOfUsage - 2) * this.interestRate * this.balance / 100;
                if (interest < 0)
                {
                    return 0;
                }
                else
                {
                    return interest;
                }
            }
        }

        //constructor
        public LoanAccount(Customer customer, decimal interest, int months)
        {
            this.customer = customer;
            this.interestRate = interest;

            if (months < 0)
            {
                throw new System.ArgumentException("Months cannot be less than 0!");
            }

            this.monthsOfUsage = months;
        }
    }
}
