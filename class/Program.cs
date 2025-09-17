using System;
using System.Reflection.Emit;
using System.Threading;
using System.Xml.Linq;

namespace Class 
{
     class Trainer
    {//  Class Trainer
     //이름 : 플레이어 이름, 프로그램 시작 시 입력하도록 구현
        private string name;
        private Monster[] monsters;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Trainer(string name)
        {
            this.name = name;
            monsters = new Monster[6]; //몬스터를 보관할 수 있는 크기 6의 배열
        }
  
        //Add() : 매개변수로 몬스터를 하나 입력받아 배열의 빈 자리에 추가. 빈 자리가 없다면 추가되지 않음
        public void Add(Monster monster)   
        {
            for (int i = 0; i < monsters.Length; i++)
            { //몬스터스 배열의 끝까지 순회 (최대6)
                if (monsters[i] == null)
                { //i가 널이면 널에 몬스터 대입하고 반환 
                    monsters[i] = monster;
                    return; 
                }
            }
        }

        //Remove() : 매개변수로 몬스터를 하나 입력받아(혹은 몬스터 이름이 적힌 문자열) 동일한 이름을 가진 몬스터를 배열에서 삭제.
        public void Remove(string MonsterName)
        {
            for (int i = 0; i < monsters.Length; i++)
            {//몬스터스 순회 
             //이름에 해당하는 몬스터가 없거나 배열에 몬스터가 한마리도 없는 경우 아무 기능도 수행하지 않음.
                if (monsters[i] == null) continue; //몬스터스가 널이면 건너뜀

                if (monsters[i].Name == MonsterName) 
                {//이름이 같으면 널로 만들고 종료    
                    monsters[i] = null;
                    break;
                }
            }
        }

        //PrintAll() : 자신이 가지고 있는 모든 포켓몬에 대한 정보를 출력
        public void PrintAll()
        {
            for (int i = 0; i < monsters.Length; i++)
            {
                if (monsters[i] != null)//널이 아닌것을  
                monsters[i].Print();//몬스터클래스에 있는걸 프린트
             
            }
        }
    }
    class Monster
    {
        //이름, 레벨 : 객체의 인스턴스 생성 시 new할당에서 이름과 레벨을 입력받을 수 있도록 구현
        private string name;  
        private int level;
        public string Name
        {
            get { return name; }

        }
        public int Level
        {
            get { return level; }

        }
        // Print() : 자신(몬스터)에 대한 정보를 출력
        public Monster(string name, int level)
        {
            this.name = name;
          //자동프로퍼티를 쓰면 출력이 안되나 
            this.level = level;
         
        }

        public void Print()
        {
            Console.WriteLine($"이름:{name}");
            Console.WriteLine($"레벨:{level}");
            Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡ");
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("트레이너 이름 입력:");
            string InputName = Console.ReadLine();

            Trainer trainer = new Trainer(InputName);

            Monster monster1 = new Monster("브케인", 5); //생성
            trainer.Add(monster1); //추가 
            Monster monster2 = new Monster("치코리타", 1);
            trainer.Add(monster2);
            Monster monster3 = new Monster("리아코", 5);
            trainer.Add(monster3);

            trainer.PrintAll(); //목록출력
            trainer.Remove("치코리타"); //삭제 
            trainer.PrintAll(); //삭제후 목록출력
        }
    }
}
