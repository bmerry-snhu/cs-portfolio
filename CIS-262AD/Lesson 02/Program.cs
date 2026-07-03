namespace Lesson_02
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
            personalAccount.DueDate = DateTime.Now.AddMonths(1);

            accounts.Add(personalAccount);

            BusinessAccount businessAccount = new BusinessAccount();

            businessAccount.AmmountDue = 9000;
            businessAccount.Name = "AAA";
            businessAccount.Address = "12345 Newroad St, Genericton, Fiftyfirststate 01010-1010";

            accounts.Add(businessAccount);

            foreach (Account account in accounts)
                Console.WriteLine($"Name:{account.Name} Ammount Due:${account.AmmountDue:F2} Due:{account.DueDate}");
        }
    }
}