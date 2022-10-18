using System;

namespace CSharp06
{
    internal class Program
    {


        interface IEat
        {
            //먹는 다는 행위(함수)를 규격화 한다 
            void Eat();
        }
        //인터페이스(interface)
        // = 추상클래스와 유사하고 규격을 만들 때 사용한다.
        //클래스를 내부에서는 사용가능하나
        class Person : IEat
        {
            public void Eat()
            {
                Console.WriteLine("사람이 밥을 먹는다");
            }
        }

        class Lion : IEat
        {
            public void Eat()
            {
                Console.WriteLine("사자이 고기를 먹는다");
            }
        }

        class Camel : IEat
        {
            public void Eat()
            {
                Console.WriteLine("낙타가 풀을 먹는다");
            }
        }

        class Cat :IEat
        {
            public void Eat()
            {
                Console.WriteLine("고양이가 먹이를 먹는다");
            }

        }
         
        
        class Dog :IEat
        {
            public void Eat()
            {
                Console.WriteLine("강아지가 사료를 먹는다");
            }
        }

        class Cow : IEat
        {
            public void Eat()
            {
                Console.WriteLine("소가 먹이를 먹는다 ");
            }
                
        }
            
       
        static void Main(string[] args)
        {
            Program2 program2 = new Program2();
            program2.Start();
            return;

            Person person = new Person();       //Person 객체 인스턴스
            Lion lion = new Lion();             //Lion 객체 인스턴스.
            Camel camel = new Camel();          //Camel 객체 인스턴스.
            Cat cat = new Cat();                //cat 객체 인스턴스 생성
            Dog dog = new Dog();                //Dog 객채 인스턴스 생성
            Cow cow = new Cow();                //Cow 객채 인스턴스 생성

            person.Eat();
            lion.Eat();
            camel.Eat();
            cat.Eat();
            dog.Eat();
            cow.Eat();


            Console.WriteLine();
            EatFunc(person);
            EatFunc(lion);
            EatFunc(camel);
            EatFunc(cat);
            EatFunc(cow);
            

            Console.WriteLine();
            EatFuncInter(person);
            EatFuncInter(lion);
            EatFuncInter(camel);
            EatFuncInter(cat);

            Console.WriteLine();
            EatFuncObj(person);
            EatFuncObj(lion);
            EatFuncObj(camel);
            EatFuncObj(cat);
        }

        //인터페이스를 사용해 객체간의 결합도를 낮춤
        static void EatFuncInter(object target)
        {
            if(target is IEat)
            {
                IEat eat = target as IEat;
                eat.Eat();                                 
            }
            
        }


        //인터페이스를 사용한 '아규먼트 패싱' 을 사용안한경우
        // 오버로딩을 통해 매서드를 3배 늘림
        static void EatFunc(Person p)
        {
            p.Eat();
        }
        static void EatFunc(Lion lion)
        {
            lion.Eat();
        }
        static void EatFunc(Camel camel)
        {
            camel.Eat();
        }

        static void EatFunc(Cat cat)
        {
            cat.Eat();
        }
        static void EatFunc(Dog dog)
        {
            dog.Eat();
        }

        static void EatFunc(Cow cow)
        {
            cow.Eat();      
        }


        //Object를 이용하자
        //오버로딩을 통해서는 클래스가 늘어남에 따라 함수의 양도 증가하기 때문에
        //모든 자료형을 대입할 수 있는 클래스를 만들어야함
        static void EatFuncObj(object target)
        {
            if(target is Person)
            {
                Person p = target as Person;
                p.Eat();
            }
            else if(target is Lion)
            {
                Lion lion = target as Lion;
                lion.Eat();
            }   

            else if(target is Camel)
            {
                Camel camel = target as Camel;
                camel.Eat();
            }             
        }               
    }
}
