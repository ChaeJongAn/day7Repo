using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staticPractice
{
    class Reward
    {
        int _gold;
        public int Gold
        {
            get { return _gold; }
            set { _gold = value; }
        }
    }

    class Enemy
    {
        static int _createCount; // 생성 숫자
        int _id; //이건 숨겨진 필드고
    public     static Reward rwd = new Reward(); 
        //이건 외부와 소통하기 위한 겟셋 모음집, 프로퍼티
        public int UniqueID
        {
            get { return _id; }
            set { _id = value; }
        }
        public Enemy()
        {
            rwd = new Reward();
            _createCount++;
            UniqueID = _createCount;
        }

        public void IncreaseCreateCount()
        {
            _createCount++; //정적 숫자 변동
        }

        public void ShowCreateCount()
        {
            Console.WriteLine(_createCount); //열람
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Enemy enemy1 = new Enemy();
            //Enemy enemy2 = new Enemy();
            //Enemy enemy3 = new Enemy();

            //Console.WriteLine(enemy1.UniqueID);
            //Console.WriteLine(enemy2.UniqueID);
            //Console.WriteLine(enemy3.UniqueID);
        }
    }

        class Hunter
    {
        static int _deathCount; //일반적인 필드 만드는거처럼 만들고, static만 붙이면 특별취급
        int _healthPoint;
        int _money;
    }
}