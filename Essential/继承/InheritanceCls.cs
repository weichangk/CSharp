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


        public string AbstractClassTest()
        {
            Animal animal = new Dog("小黄狗");
            animal.Age = 3;
            string wocao1 = animal.WoCao();
            string eat1 = animal.Eat();

            animal = new Cat("小花猫");
            animal.Age = 2;
            string wocao2 = animal.WoCao();
            string eat2 = animal.Eat();


            return $"{wocao1}{eat1}{Environment.NewLine}{wocao2}{eat2}";
        }

        public string UseIsTest()
        {
            Dog dog = new Dog("小黄狗") { Age = 2};
            //使用is操作符进行模式匹配：狗是动物，狗可以转换为动物
            if (dog is Animal animal && animal.Age >= 1)
            {
                return $"小黄狗是动物，它大于1岁了";
            }
            else
            {
                return "小黄狗不是动物";
            }
        }

        public string UseSwitchTest(Animal animal)
        {
            //使用switch操作符进行模式匹配
            switch (animal)
            {
                case null:
                    return "null";
                case Dog dog when dog.Age >=1:
                    return $"{dog.WoCao()}{dog.Eat()}";
                case Cat cat:
                    return $"{cat.WoCao()}{cat.Eat()}";
                default:
                    return "什么鬼";
            }
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
        protected string _name;
        public abstract int Age { get; set; }

        public Animal(string name)
        {
            _name = name;
        }

        public virtual string WoCao()
        {
            return "WoCao";
        }

        public abstract string Eat();
    }
    public class Dog : Animal
    {
        public Dog(string name) : base(name)
        { 
        }

        public override int Age { get; set; }

        public override string WoCao()
        {
            return $"{_name} WoCao";
        }
        public override string Eat()
        {
            return $"吃了{Age}年的狗粮";
        }

    }

    public class Cat : Animal
    {
        public Cat(string name) : base(name)
        {
        }

        public override int Age { get; set; }

        public override string WoCao()
        {
            return $"{_name} WoCao";
        }
        public override string Eat()
        {
            return $"吃了{Age}年的猫粮";
        }

    }
}
