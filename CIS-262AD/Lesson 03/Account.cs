using Lesson_03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_03
{
    public abstract class Account
    {
        private string _name;
        private string _address;
        private Decimal _amountDue;
        private DateTime _invoiceDate;
        public virtual string Name { get { return _name; } set { _name = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        public Decimal AmountDue { get { return _amountDue; } set { _amountDue = value; } }
        public DateTime InvoiceDate
        { 
            get { return _invoiceDate; } 
            set 
            { 
                _invoiceDate = value;
                CalculateDueDate();
            } 
        }
        public DateTime DueDate { get; protected set; }
        public abstract void CalculateDueDate();
    }

    public interface IPayMyBill
    {
        void Pay();
    }

    public class PersonalAccount : Account, IPayMyBill
    {
        private string _firstName;
        private string _lastName;
        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public override string Name { get { return _firstName + " " + _lastName; } }
        public void Pay()
        {
            AmountDue = 0;
        }
        public override void CalculateDueDate()
        {
            DueDate = InvoiceDate.AddDays(30);
        }
    }

    public class BusinessAccount : Account, IPayMyBill
    {
        public void Pay()
        {
            AmountDue = 0;
        }
        public override void CalculateDueDate()
        {
            DueDate = InvoiceDate.AddDays(60);
        }
    }
}
