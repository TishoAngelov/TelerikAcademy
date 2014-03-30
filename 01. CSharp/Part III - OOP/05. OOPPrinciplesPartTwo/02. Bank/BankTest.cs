using System;

namespace _02.Bank
{
    public class BankTest
    {
        public static void Main()
        {
            Customer individual = new IndividualCust();
            Customer company = new CompanyCust();

            LoanAcc individualLoan = new LoanAcc(individual, 100, 5);
            LoanAcc companyLoan = new LoanAcc(company, 2000, 7);

            // Loan accounts have no interest for the first 3 months if are held by individuals and for 
            // the first 2 months if are held by a company.
            Console.WriteLine(individualLoan.CalcInterestAmount(3));      // 0

            Console.WriteLine(companyLoan.CalcInterestAmount(2));         // 0
            Console.WriteLine(companyLoan.CalcInterestAmount(3));         // 7
            Console.WriteLine();

            individualLoan.Deposit(100);
            Console.WriteLine(individualLoan.Balance);      // 200
            Console.WriteLine();

            DepositAcc companyDep = new DepositAcc(company, 1000, 5);

            companyDep.Deposit(100);
            Console.WriteLine(companyDep.Balance);          // 1100
            Console.WriteLine();

            companyDep.Withdraw(1000);
            Console.WriteLine(companyDep.Balance);          // 100
            Console.WriteLine();

            try
            {
                companyDep.Withdraw(1000);
                Console.WriteLine(companyDep.Balance);        // Exception. No money.. ;(
            }
            catch (InvalidOperationException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(ex.Message);

                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }
}
