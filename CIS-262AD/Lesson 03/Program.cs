namespace Lesson_03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>();

            PersonalAccount personalAccount = new PersonalAccount();

            personalAccount.FirstName = "Blake";
            personalAccount.LastName = "Merry";
            personalAccount.InvoiceDate = DateTime.Now;
            personalAccount.AmountDue = 900;
            personalAccount.Address = "54321 Oldroad Dr, Specificburg, Fiftysecondstate 10101-0101";

            accounts.Add(personalAccount);

            BusinessAccount businessAccount = new BusinessAccount();

            businessAccount.Name = "AAA";
            businessAccount.InvoiceDate = DateTime.Now;
            businessAccount.AmountDue = 9000;
            businessAccount.Address = "12345 Newroad St, Genericton, Fiftyfirststate 01010-1010";

            accounts.Add(businessAccount);

            foreach (Account account in accounts)
                Console.WriteLine($"Name:{account.Name} Ammount Due:${account.AmountDue:F2} Due:{account.DueDate}");

            personalAccount.Pay();
            businessAccount.Pay();
        }
    }
}