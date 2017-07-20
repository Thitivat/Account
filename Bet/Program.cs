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
        private static int _minStartMoney = 10;
        private static double _startMoney;
        private static int _previousMoney;
        public static void Main(string[] args)
        {
            Console.WriteLine("Input money");
            _currentMoney = Convert.ToInt32(Console.ReadLine());

            //for (int j = 0; j < 100; j++)
            //{
            //    Console.WriteLine(GetBet().ToString());
            //}
            
            int i = 1;
            for (; ; )
            {
                int betAmounts = (int)GetStartMoney();
                _previousMoney = betAmounts;
                if (_currentMoney > 0 && _currentMoney >= betAmounts)
                {
                    bool result = GoBet(GetBet(), betAmounts);
                    Console.WriteLine("Round : {0} Bet Amount : {1}, Result : {2}, Current Money : {3}, Win Streak : {4}, Lose Streak : {5}", i, betAmounts, result, _currentMoney, _winStreak, _loseStreak);
                }
                else if (_currentMoney > _minStartMoney)
                {
                    bool result = GoBet(GetBet(), betAmounts);
                    Console.WriteLine("Round : {0} Bet Amount : {1}, Result : {2}, Current Money : {3}, Win Streak : {4}, Lose Streak : {5}", i, betAmounts, result, _currentMoney, _winStreak, _loseStreak);
                    if (!result)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Not enought money");
                    break;
                }
                i++;
            }
            Console.ReadKey();

        }

        private static double GetStartMoney()
        {
            //int multiply = _loseStreak == 0 ? 1 : _loseStreak;
            int multiply = 2;
            if (_loseStreak == 0 && _winStreak == 0 || _winStreak == 1)
            {
                _startMoney = (((_currentMoney * 0.7) / 100) * multiply);
            }
            else if (_loseStreak > 0)
            {
                _startMoney = _previousMoney * 2;
            }
            return ((_currentMoney * 0.7) / 100) * multiply >= _minStartMoney ? _startMoney : _currentMoney;
        }

        private static bool GetBet()
        {
            Random o = new Random();
            Thread.Sleep(o.Next(100));
            return (((DateTime.Now.Ticks) % 10) % 2) != 1 ? true : false;
        }

        private static bool GoBet(bool bet, int money)
        {
            bool betResult = ((DateTime.Now.Ticks % 10) % 2) != 1 ? true : false;
            //bool betResult = NextBool(r);
            if (_currentMoney <= 0 || _currentMoney < money)
            {
                Console.WriteLine("You don't have enought money.");
                return true;
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
