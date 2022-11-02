using System;

namespace Задание_4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<<<Игра в жизнь!>>>");
            Console.WriteLine("Введите ширину чашки Петри:");
            int width = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите высоту чашки Петри:");
            int heigth = int.Parse(Console.ReadLine());


            #region (Генерация поля и расстановка значений для заполнения символами)
            bool[,] cells;
            cells = new bool[heigth, width];

            Random cellsGen = new Random();
            int symbol;
            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    symbol = cellsGen.Next(2);
                    if (symbol == 0) cells[i, j] = false;
                    else cells[i, j] = true;
                }
            }
            #endregion

            #region (Расстановка символов-клеток)
            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (cells[i, j] == false) Console.Write(' ');
                    if (cells[i, j] == true) Console.Write('+');
                }
                Console.WriteLine("\r");
            }
            #endregion

            #region (Основной цикл перебора поколений)
            int generation = 1000;
            int g = 0;
            while (g <= generation)
            {
                Console.Clear();
                Console.WriteLine("<<<Игра в жизнь!>>>");
 
                for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int alive = 0;
                    //Проверка соседей для каждой клетки
                    for (int x = (i > 0 ? i - 1 : 0); x < (i == heigth - 1 ? heigth : i + 2); x++)
                    {
                        for (int y = (j > 0 ? j - 1 : 0); y < (j == width - 1 ? width : j + 2); y++)
                        {
                            
                            if (cells[x, y] == true) alive++;
                            
                        }
                    }
                    //Клетки умирают
                    if (cells[i, j] == true)
                    {
                        if (alive < 2) cells[i, j] = false;
                        if (alive > 3) cells[i, j] = false;
                    }
                    //Клетки рождаются
                    else
                    {
                        if (alive == 3) cells[i, j] = true;
                    }
                }
            }
            
            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (cells[i, j] == false) Console.Write(' ');
                    if (cells[i, j] == true) Console.Write('+');
                }

                g++;
                Console.WriteLine("\r");
                
            }
                System.Threading.Thread.Sleep(200);
            }

            #endregion





            Console.CursorVisible = false;
            Console.ReadKey();
        }
    }
}
