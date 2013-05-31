namespace Bank
{
    class MortgageAccount : Account, IAccount, IDepositable
    {
        //constructor
        public MortgageAccount(Customer customer, decimal interest, int months)
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
            if (customer is Individual)
            {
                decimal interest = (this.monthsOfUsage - 6) * this.balance * this.interestRate / 100;
                if (interest > 0)
                {
                    return interest;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                if (this.monthsOfUsage <= 12)
                {
                    //I divide by 200 because of 100 for percentage and 2 for mortgage account of first 12 months
                    decimal interest = this.monthsOfUsage * this.balance * this.interestRate / 200;
                    return interest;
                }
                else
                {
                    decimal interest = 12 * this.balance * this.interestRate / 200 + 
                        (this.monthsOfUsage - 12) * this.balance * this.interestRate / 100;
                    return interest;
                }
            }
        }
    }
}
