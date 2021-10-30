using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


/*
 *  Имеется пустой участок земли (двумерный массив) и план сада, который необходимо реализовать.
 *  Эту задачу выполняют два садовника, которые не хотят встречаться друг с другом.
 *  Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо, сделав ряд, он спускается вниз.
 *  Второй садовник начинает работу с нижнего правого угла сада и перемещается снизу вверх, сделав ряд, он перемещается влево.
 *  Если садовник видит, что участок сада уже выполнен другим садовником, он идет дальше. Садовники должны работать параллельно.
 *  Создать многопоточное приложение, моделирующее работу садовников.
 */


namespace Zadanie_21
{
    class Program
    {
        static int l = 20;
        static int[,] pole = new int[l, l];
        static int speed = 0;
        static int score1 = 0;
        static int score2 = 0;
        static void Sad1 ()
        {
            for (int y = 0; y < l; y++)
            {
                for (int x = 0; x < l; x++)
                {
                    if (pole[y, x] != 2)
                    {
                        pole[y, x] = 1;
                    }
                    Thread.Sleep(speed);
                }
            }
        }
        static void Sad2()
        {

            for (int x = l-1; x > -1; x--)
            {
                for (int y = l-1; y > -1; y--)
                {
                    if (pole[y, x] != 1)
                    {
                        pole[y, x] = 2;
                    }
                    Thread.Sleep(speed);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("ЗАДАНИЕ 21. МНОГОПОТОЧНОСТЬ. КЛАСС THREAD");
            Console.WriteLine();
            Console.WriteLine("*** ВЕСЕЛЫЕ САДОВНИКИ ***");
            Console.Write("Угадайте, какой садовник (1 или 2) обработает больше участков?\n Ваш выбор:");
            string winner = Console.ReadLine();
            ThreadStart threadStart = new ThreadStart(Sad1);
            Thread thread = new Thread(threadStart);
            thread.Start();
            Sad2();

            Pole(winner);
            Console.ReadKey();
        }

        static public void Pole(string winner)
        {
            //Console.Clear();

            Console.WriteLine();
            for (int y = 0; y < l; y++)
            {
                for (int x = 0; x < l; x++)
                {
                    Console.Write(pole[y, x]);
                    if (pole[y, x]==1)
                    {
                        score1++;
                    }
                    else
                    {
                        score2++;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Первый садовник обработал {0} уч. сада", score1);
            Console.WriteLine("Второй садовник обработал {0} уч. сада", score2);
            if (((score1>score2)&&winner=="1")|| ((score1 < score2) && winner == "2"))
            {
                Console.WriteLine("Поздравляю! Вы угадали!");
            }
            else
            {
                Console.WriteLine("Увы! Вы не угадали.");
            }
        }
    }
}
