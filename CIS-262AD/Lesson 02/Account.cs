using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_02
{
    public class Account
    {
        private string _name;
        private string _address;
        private Decimal _ammountDue;
        private DateTime _invoiceDate;
        private DateTime _dueDate;
        public virtual string Name { get { return _name; } set { _name = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        public Decimal AmmountDue { get { return _ammountDue; } set { _ammountDue = value; } }
        public DateTime InvoiceDate { get { return _invoiceDate; } set { _invoiceDate = value; } }
        public DateTime DueDate { get { return _dueDate; } set { _dueDate = value; } }
    }

    public class PersonalAccount : Account
    {
        private string _firstName;
        private string _lastName;
        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public override string Name { get { return _firstName + " " + _lastName; } }
    }

    public class BusinessAccount : Account
    {

    }
}
