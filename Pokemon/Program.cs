using System;

namespace Pokemon
{


    class Trainer
    {   //과제 1)       //Trainer라는 클래스를 하나 만들겠습니다.
       private int badge;      //해당 클래스는 필드로 획득뱃지 갯수를 저장하는 정수형,
       private string name;    //이름을 나타내는 문자열 필드, 그리고 
       private string start;   //스타팅몬스터를 기입할 수 있는 문자열 필드를 보유하게 합니다.

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Start
        {
            get { return start; }
            set { start = value; }
        }

        Monster[] monsters; //과제 5)  //Trainer 클래스의 필드에, 여러 몬스터를 담을 수 있는 배열을 만들어 주시기 바랍니다.
        public Trainer(string name, string start)
        {
            monsters = new Monster[6];  //그 후, 과제2에서 만든 생성자 내부에 몬스터 배열을 6개 담을 수 있게 동적할당 시키는 코드를 작성하여 주시기 바랍니다.
            //과제 2)
            //트레이너를 생성할 때, 이름과 스타팅몬스터의 이름을 문자열로 입력받아
            //객체를 만드는 생성자를 하나 만들어 주세요.
            Name = name;
            Start = start;
            //this.name = name;
            //this.starter = starter;
        }
        public void Change(Monster change)
        {  //또한 스타팅몬스터를 바꿀 수 있는 메소드도 하나 만들어주시기 바랍니다. (방식 자유)
            monsters[0] = change;
        }

        //과제 6)
        //Trainer에게 생성자를 하나 더 추가하여 줍니다
        public Trainer(string name, Monster monster)  //생성자 오버로딩을 통해, 인자값으로 몬스터를 받습니다
        {
            Name = name;
            monsters = new Monster[6];   //트레이너가 가진 몬스터배열을 6개 담을 수 있게 동적할당 시킵니다
            monsters[0] = monster;  //만들어진 몹 배열의 0번째 인덱스에, 방금 건네받은 몹으로 담아줍니다
        }

        //과제 7) (1~7 여기까지 작성 후 제출)
        //트레이너에게 ShowFirstMob이라는 메소드를 만들어,
        public void ShowFirstMob()
        { //콘솔창에는 배열의 0번째 몹의 레벨과 이름이 출력되는 내용을 기입하여 주시기 바랍니다.
            //Console.WriteLine($"배열의 0번째 몹의 {monsters[0].Level}레벨과, 이름:{monsters[0].Level}");

            if (monsters[0] != null) //첫번째 배열이 널이 아닐때 
            {
                Console.WriteLine($"T:{Name} LV: {monsters[0].Level}, P:{monsters[0].Name} "); 
                                    // 트레이너 네임 // 몬스터들의 배열의 레벨과 이름     
              
            }
            else //널이면 
            {
                Console.WriteLine("첫 몬스터가 없습니다.");
            }
        }
    }
    //과제 3)
    //클래스 외부에 열거형 자료형 MobType를 하나 만들고 요소로는
    //Normal, Fire, Water, Grass 를 입력하여 주시기 바랍니다.
    enum MobType { Normal, Fire, Water, Grass }

    //그 후, Monster라는 클래스를 새로 하나 만들고,
    //해당 클래스의 필드로는 정수형 레벨, 열거형 몹타입,
    //그리고 문자열 이름을 넣어서 만들어 주시기 바랍니다.
    class Monster
    {
        public int Level; //정수형 레벨,
        public MobType Type; //열거형 몹타입,
        public string Name; //문자열 이름


        //과제 4)
        //방금 만들어진 Monster 클래스에 인자값을 요구하지 않는 기본 생성자를 만들고,
        //이렇게 만들어 졌을 경우, 몹의 타입은 Normal, 이름은 "", 레벨은 1로 설정되게코드를 작성하여 주시기 바랍니다. 
        //두번째 생성자는, 인자값으로 몹의 타입, 레벨, 몹의 이름을 받아 생성과 동시에 값을 세팅하는 생성자도 만들어 주시기 바랍니다.

        public Monster()
        {
            Type = MobType.Normal;
            Name = "";
            Level = 1;
        }
        public Monster(MobType type, int level, string name)
        {
            Type = type;
            Name = name;
            Level = level;
        }


        internal class Program
        {
            static void Main(string[] args)
            {
                Monster monster1 = new Monster(MobType.Water, 5, "꼬부기");
                Monster monster2 = new Monster(MobType.Fire, 5, "파이리");
                Monster monster3 = new Monster(MobType.Grass, 5, "이상해");
   
     
                Trainer trainer1 = new Trainer("지우", monster2);
                Trainer trainer2 = new Trainer("웅이", monster1);
             
                trainer1.ShowFirstMob(); //지우 파이리  
                trainer1.Change(monster3); // 지우 이상해로 교체 
                trainer1.ShowFirstMob(); //지우 이상해 
                trainer2.ShowFirstMob(); // 웅이 꼬부기 



            }
        }
    }
}
