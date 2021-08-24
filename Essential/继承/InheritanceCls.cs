using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essential
{
    using Essential.Inheritance;
    public class InheritanceCls
    {

        public string OverridePropertyTest()
        {
            Contact contact;
            PdaItem item;

            contact = new Contact();
            item = contact;

            item.Name = "Inigo Montoya";
            //写成员会造成“运行时”调用最深的或者说派生得最远的实现。父类引用指向子类对象时，父类引用调用的虚方法代码永远得不到调用，而是调用了子类的重载实现
            
            return $"{ contact.FirstName } { contact.LastName}";
        }

        public string OverridePropertyTest1()
        {
            Customer customer;
            Contact contact;

            customer = new Customer();
            contact = customer;

            contact.Name = "Inigo Montoya";

            return $"{ customer.FirstName } { customer.LastName}";
        }

        public string OverrideFuncTest()
        {
            PdaItem item = new PdaItem();
            string itemRun = item.Run("PdaItem");

            Contact contact = new Contact();
            string contactRun = contact.Run("Contact");

            item = contact;
            string itemContactRun = item.Run("PdaItem -> Contact");

            return $"{itemRun}{Environment.NewLine}{contactRun}{Environment.NewLine}{itemContactRun}";
        }
    }
}


namespace Essential.Inheritance
{
    public class PdaItem
    {
        public virtual string Name { get; set; }
        private string Start(string start)
        {
            return start;
        }
        private string Stop(string stop)
        {
            return stop;
        }
        public string Run(string runing)
        {
            string start = Start("Start");
            string run = InternalRun(runing);
            string stop = Stop("Stop");
            return $"{start}*{run}*{stop}";
        }
        public virtual string InternalRun(string internalRun)
        {
            return internalRun;
        }
    }

    public class Contact : PdaItem
    {
        public override string Name
        {
            get
            {
                return $"{ FirstName } { LastName }";
            }

            set
            {
                string[] names = value.Split(' ');
                FirstName = names[0];
                LastName = names[1];
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string InternalRun(string internalRun)
        {
            return $"{internalRun}......";
        }
    }

    public class Customer : Contact
    {
        public override string Name
        {
            get
            {
                return $"{ FirstName } { LastName }";
            }

            set
            {
                string[] names = value.Split(' ');
                FirstName = $"Customer-{names[0]}";
                LastName = $"Customer-{names[1]}";
            }
        }
    }
}
