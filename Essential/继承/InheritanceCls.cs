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

        public string NewKeyWordTest()
        {
            BaseClass baseClass;// = new BaseClass();
            DerivedClass derivedClass = new DerivedClass();
            baseClass = derivedClass;

            string str1 = baseClass.DisplayName();//BaseClass
            string str2 = derivedClass.DisplayName();//DerivedClass

            return $"{str1} {str2}";
        }
        public string NewKeyWordTest1()
        {
            SuperSubDerivedClass superSubDerivedClass = new SuperSubDerivedClass();
            SubDerivedClass subDerivedClass = superSubDerivedClass;
            DerivedClass derivedClass = superSubDerivedClass;
            BaseClass baseClass = superSubDerivedClass;

            string str1 = superSubDerivedClass.DisplayName();//superSubDerivedClass
            string str2 = subDerivedClass.DisplayName();//SubDerivedClass
            string str3 = derivedClass.DisplayName();//SubDerivedClass
            string str4 = baseClass.DisplayName();//BaseClass

            return $"{str1} {str2} {str3} {str4}";
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


    public class BaseClass
    {
        public string DisplayName()
        {
            return "BaseClass";
        }
    }

    public class DerivedClass : BaseClass
    {
        public virtual string DisplayName()//和基类方法同名的虚方法
        {
            return "DerivedClass";
        }
    }

    public class SubDerivedClass : DerivedClass
    {
        public override string DisplayName()
        {
            return "SubDerivedClass";
        }
    }

    public class SuperSubDerivedClass : SubDerivedClass
    {
        public string DisplayName()//不使用override则默认隐藏继承，默认new。使用new修饰符实现在基类面前隐藏了派生类重新声明的成员
        {
            return "SuperSubDerivedClass";
        }
    }


    public abstract class Animal
    {
        string _speciality;
        public abstract string Name { get; set; }

        public Animal(string speciality)
        {
            _speciality = speciality;
        }

        public virtual string SayWoCao()
        {
            return "WoCao";
        }
        public virtual string SpecialityDescription()
        {
            return $"Its specialty is {_speciality}";
        }

        public abstract string Eat();
    }
    public class Dog : Animal
    {
        public Dog(string speciality) : base(speciality)
        { 
        }

        public override string Name { get; set; }

        public override string Eat()
        {
            throw new NotImplementedException();
        }
    }
}
