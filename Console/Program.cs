using System;
enum Hand { Cross = 0, Rock = 1, Paper = 2 }
class Program
{
    static string[] name = { "가위", "바위", "보" };
    static bool parse(string input, out Hand hand)//변환 함수 
    {
        hand = Hand.Paper; //기본값                         
        if (input == "1") { hand = Hand.Cross; return true; } //1을 입력할시, 가위가 됨
        if (input == "2") { hand = Hand.Rock; return true; } //2를 입력할시, 주먹이 됨
        if (input == "3") { hand = Hand.Paper; return true; } //3을 입력할시, 보가 됨 
        return false; //나머지는 아님 
    }
    static void Main()
    {
        Console.Write("1=가위, 2=바위, 3=보 (숫자 입력) : ");

        string input = Console.ReadLine(); //유저 입력 

        Hand user; //유저 손  
        if (!parse(input, out user))//유저 인풋 형변환 함수, 아웃풋으로 유저값을 뱉음    
        {                     //bool 값이 false라 parse를 못할시 
            Console.WriteLine("잘못된 입력입니다. 1, 2, 3중 하나를 입력하세요.");
            return;
        }
        Random rand = new Random(); 
        Hand comp = (Hand)rand.Next(0,3); //컴퓨터 손 랜덤 

        Console.WriteLine("유저: " + name[(int)user]); //유저와 컴이 낸 손이 무엇인지 
        Console.WriteLine("컴퓨터: " + name[(int)comp]);

        int result = output(user, comp); //결과 처리 함수 
        //결과 출력
        if (result > 0) Console.WriteLine("결과:승리!"); // 0보다 클시 
        else if (result == 0) Console.WriteLine("결과:무승부"); //결과를 0을 받았을시
        // else if (result < 0)
        else Console.WriteLine("결과:패배..."); // 위 두 결과가 아닐시 
    }

    static int output(Hand user, Hand comp)//인자는 유저와 컴퓨터 
    {
        if (user == comp) return 0; //같을시 무승부 
        if (user == Hand.Cross && comp == Hand.Paper) return 1; //유저가 가위고, 컴이 보일시 승리 
        if (user == Hand.Rock && comp == Hand.Cross) return 1; //유저가 주먹이고, 컴이 가위일시 승리
        if (user == Hand.Paper && comp == Hand.Rock) return 1; //유저가 보고, 컴이 주먹일시 승리 
        return -1; //나머지는 패
    }
}

