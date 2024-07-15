using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueen
{
    internal class Program
    {
        public static int Answer = 1;
        public static int Queen= 8;
        public static int[] Queens = new int[Queen];//紀錄該列皇后位置，共X列

        static void Main(string[] args)
        {
            FindQueenInLine(0);
            Console.ReadLine();
        }
        /// <summary>
        /// 要找第幾列
        /// </summary>
        /// <param name="x"></param>
        private static void FindQueenInLine(int x)
        {
            for (int y = 0; y < Queen; y++)
            {
                if (IsAvailable(x, y))
                {
                    Queens[x] = y;
                    if (x == Queen - 1)//最終列
                    {
                        PrintAnswer();
                        return;
                    }
                    FindQueenInLine(x + 1);
                }
            }
        }

        /// <summary>
        /// 檢查每列每欄
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static bool IsAvailable(int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                int locate = Queens[i];//取得之前已記錄的皇后位置
                if (y == locate)//位在同欄
                    return false;
                else if ((i + locate) == (x + y))//橫向檢查
                    return false;
                else if ((i - locate) == (x - y))
                    return false;
            }
            return true;
        }
             

        private static void PrintAnswer()
        {
            Console.WriteLine("Solution " + Answer++);
            for (int x = 0; x < Queen; x++)
            {
                for (int y = 0; y < Queen; y++)
                {
                    if (y == Queens[x]) 
                    {
                        Console.Write("Q"); 
                    }
                    else 
                    {
                        Console.Write("."); 
                    }
                }
                Console.WriteLine();
            }

        }
        

    }
}
