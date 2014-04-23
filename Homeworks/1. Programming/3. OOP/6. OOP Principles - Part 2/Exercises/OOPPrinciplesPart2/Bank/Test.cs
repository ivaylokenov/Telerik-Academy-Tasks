namespace Bank
{
    class Test
    {
        static void Main()
        {
            //in my opition accounts should have DateTime property "startDate" or something for
            //the time of the account openning nad months should be calculated with DateTime.Now - startDate
            //but we cannot test the program this way, so months are entered in the constructors
            //
            //Also calculate interest should add the interest to the main balance but I did not add that because
            //in the task is not exactly clear

            DepositAccount deposit = new DepositAccount(new Individual("Pesho", 21, "Male"), 7.5m, 15);
            deposit.DepositMoney(10000m);
            System.Console.WriteLine(deposit.CalculateInterest());
            deposit.WithdrawMoney(5000m);
            System.Console.WriteLine(deposit.Balance);

            LoanAccount loan = new LoanAccount(new Company("Pesho ltd.", "00000153265"), 5.5m, 10);
            loan.DepositMoney(50000m);
            System.Console.WriteLine(loan.CalculateInterest());
        }
    }
}
