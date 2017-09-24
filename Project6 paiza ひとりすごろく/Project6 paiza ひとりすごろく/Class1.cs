using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_paiza_ひとりすごろく
{
    class Dice
    {
        public int T; //天
        public int B; //地
        public int U; //進行方向
        public int D; //後
        public int L; //手前
        public int R; //奥
        public Dice(string dice)
        {
            var diceArray = dice.Split(' ').Select(n => int.Parse(n)).ToArray();
            this.T = diceArray[0];
            this.B = diceArray[1];
            this.U = diceArray[2];
            this.D = diceArray[3];
            this.L = diceArray[4];
            this.R = diceArray[5];
        }

        public int Rotation(int number, int counter)
        {
            if(number == T)
            {
                return counter;
            }
            else if(number == B)
            {
                var temp = B;
                B = T;
                T = temp;
                var temp2 = U;
                U = D;
                D = temp2;
                return counter + 2;
            }
            else if(number == U)
            {
                var temp = U;
                U = B;
                B = D;
                D = T;
                T = temp;
                return counter+ 1;
            }
            else if(number == D)
            {
                var temp = D;
                D = B;
                B = U;
                U = T;
                T = temp;
                return counter + 1;
            }
            else if(number == L)
            {
                var temp = L;
                L = B;
                B = R;
                R = T;
                T = temp;
                return counter + 1;
            }
            else
            {
                var temp = R;
                R = B;
                B = L;
                L = T;
                T = temp;
                return counter + 1;
            }

        }
    }

    class Program
    {
        public static void Main()
        {
            var dice = new Dice(Console.ReadLine());
            var N = int.Parse(Console.ReadLine());
            var board = new int[N];
            for (int i = 0; i < N; i++)
            {
                board[i] = int.Parse(Console.ReadLine());
            }

            var counter = 0;
            //ゲームする
            for (int i = 1; i < N; i++)
            {
                counter = dice.Rotation(board[i], counter);
            }

            Console.WriteLine(counter);
        }
    }
}
