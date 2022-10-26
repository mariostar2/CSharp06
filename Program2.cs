using System;
using System.Collections.Generic; // 일반화 타입 컬렉션
using System.Collections; // 일반 타입 컬랙션


namespace CSharp06
{
    class Box<T> : IEnumerable<T>
    {
        T[] array;
        int index;

        //외부 공개 Getter(프로퍼티)
        //Count를 통해 값을 가져갈때 자신의 값이 아닌 index변수의 값을 리턴하라.
        
        public int Count
        {
            //기본적으로 존재하는 get기능을 내가 구현했다
            //index의 '값'은 사실상 가지고 있는 값의 개수와 동일하다
            //따라서 get(가져갈수 만 있는 )변수를 만들고 index값을 반환시켰다
            get
            {
                return index;
            }
            // int count 변수는 set기능을 구현하지 않아서 대입불가.
        }

        public Box()
        {
            array = new T[20];
        }

        //값을 대입 할수 있는 Add함수.
        public void Add(T value)
        {
            array[index] = value;
            index++;
        }

        //값을 대입 할수 있는 indexer.
        public T this[int index]
        {
            get
            {
                return array [index];
            }
        }

        //아래 함수의 이름은 GetEnumerator이다
        public IEnumerator<T> GetEnumerator()
        {
            //횟수를 array.Length만큼 돌면 원하는 결과가 나오지 않는다.
            //왜? 현재 배열은 20개의 길이를 가지지만 이것은 대입받는 값의 갯수는 아니다.
            //따라서 실제 대입받은 값의 개수만큼 열거(=Enumerate)시킨다
            //for ->foreach ->array i번째로 가저가서 ->리턴한다
            for (int i = 0; i < Count; i++)
                yield return array[i];
        }
        //일반 버전 열거자도 필요하다
        //아래는 IEnumerable 내부에도 존재하는 GetEnumerator다
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class Program2
    {
        //Enumeratr : 수를 세다 (열거형)

        //c#의 모든 컬렉션들은 아래의 두 인터페이스를 상속받아 구현하고 있다.
        //IEnumerator : 데이터를 리턴하는 열거자;
        //Ieumerable : 열거지를 리턴하는 Getter
        public void Start()
        {
            if (false)
            {
                IEnumerator ie = GetEnumerator(); //열거자를 리턴한다.
                Console.WriteLine($"현재 값은 :{ie.Current}");

                ie.MoveNext();
                Console.WriteLine($"현재 값은 : {ie.Current}");

                ie.MoveNext();
                Console.WriteLine($"현재 값은 : {ie.Current}");

                ie.MoveNext();
                Console.WriteLine($"현재 값은: {ie.Current}");
            }

            //for-each 구현하기

            //이 시점에서 객체 box의 일반화 타입은 int라고 명시된다.
            Box<int> box = new Box<int>();
            foreach (int num in box)
            {
                Console.WriteLine(num);
            }
            // 이 시점에서 객체 box2의 일반화 타입은 string이라고 명시되어 있다;
            Box<string> box2 = new Box<string>();
            foreach (string str in box2)
            {
                Console.WriteLine(str);
            }

        }

        //IEnumerable의 자동 완성형이다.
        //열거자를 반환하는 함수는 MoveNext,Reset,Current를 자동으로 만든다.
        IEnumerator GetEnumerator()
        {

            // MoveNext가 실행이 되면 다음 yleld 지점까지 실행한다
            Console.WriteLine("1번");
            yield return 1;             //yleld 대기 

            Console.WriteLine("2번");
            yield return 2;

            Console.WriteLine("3번");
        }
    }
}