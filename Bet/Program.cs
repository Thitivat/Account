using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bet
{
    public class Program
    {
        private static int _currentMoney;
        private static int _winStreak = 0;
        private static int _loseStreak = 0;
        private static int _minStartMoney = 50;
        private static int _startMoney;
        private static int _previousMoney;
        public static void Main(string[] args)
        {
            Console.WriteLine("Input money");
            _currentMoney = Convert.ToInt32(Console.ReadLine());

            //for (int i = 0; i < 100; i++)
            //{
            //    Console.WriteLine(GetBet().ToString());
            //}

            for (int i = 0; i < 100; i++)
            {
                int startMoney = GetStartMoney();
                _previousMoney = startMoney;
                if (_currentMoney > 0 && _currentMoney >= startMoney)
                {
                    bool result = GoBet(GetBet(), startMoney);
                    Console.WriteLine("Round : {0} Start Money : {1}, Result : {2}, Current Money : {3}, Win Streak : {4}, Lose Streak : {5}", i, startMoney, result, _currentMoney, _winStreak, _loseStreak);
                }
                else
                {
                    Console.WriteLine("Not enought money");
                    break;
                }
            }
            Console.ReadKey();

        }

        private static int GetStartMoney()
        {
            //int multiply = _loseStreak == 0 ? 1 : _loseStreak;
            int multiply = 2;
            if (_loseStreak == 0 && _winStreak == 0 || _winStreak == 1)
            {
                _startMoney = ((_currentMoney * 2) / 100) * multiply;
            }
            else if (_loseStreak > 0)
            {
                _startMoney = _previousMoney * 2;
            }
            return ((_currentMoney * 2) / 100) * multiply >= _minStartMoney ? _startMoney : _currentMoney;
        }

        private static bool GetBet()
        {
            //Random o = new Random();
            Thread.Sleep(23);
            return (((DateTime.Now.Ticks) % 10) % 2) != 1 ? true : false;
        }

        private static bool GoBet(bool bet, int money)
        {
            bool betResult = ((DateTime.Now.Ticks % 10) % 2) != 1 ? true : false;
            //bool betResult = NextBool(r);
            if (_currentMoney <= 0 || _currentMoney < money)
            {
                Console.WriteLine("You don't have enought money.");
                return false;
            }
            else
            {
                if (GetBet())
                {
                    _currentMoney += money;
                    _winStreak++;
                    _loseStreak = 0;
                    return true;
                }
                else
                {
                    _currentMoney -= money;
                    _loseStreak++;
                    _winStreak = 0;
                    return false;
                }
            }
        }

    }
}
