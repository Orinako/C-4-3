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
            int generation = 100;
            int g = 0;
            int totalDeaths = 0;
            int totalBirths = 0;
            while (g++ < generation)
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
                    if (cells[i, j])
                    {
                            if (alive < 2)
                            {
                                cells[i, j] = false;
                                totalDeaths++;
                            }
                            if (alive > 3)
                            {
                                cells[i, j] = false;
                                totalDeaths++;
                            }
                    }
                    //Клетки рождаются
                    else
                    {
                            if (alive == 3)
                            {
                                cells[i, j] = true;
                                totalBirths++;
                            }
                    }
                }
            }

                if (g % 5 == 0)
                {
                    Random deathAmount = new Random();
                    int death = deathAmount.Next(4);
                    int d=0;
                    while (d++ < death)
                    {
                        Random killK = new Random();
                        Random killL = new Random();
                        int k = killK.Next(heigth);
                        int l = killL.Next(width);
                        cells[k, l] = false;
                        totalDeaths++;
                    }
                }

                if (g % 8 == 0)
                {
                    Random birthAmount = new Random();
                    int birth = birthAmount.Next(10);
                    int b = 0;
                    while (b++ < birth)
                    {    
                        Random birthH = new Random();
                        Random birthW = new Random();
                        int h = birthH.Next(heigth);
                        int w = birthW.Next(width);
                        cells[h, w] = true;
                        totalBirths++;
                    }
                }

                for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (cells[i, j] == false) Console.Write(' ');
                    if (cells[i, j] == true) Console.Write('+');
                }
                
                Console.WriteLine("\r");
                
            }
                
                if (g == generation)
                {
                    Console.WriteLine($"Этим клеткам удалось дожить до {g}-ого поколения!");
                    Console.WriteLine("За это время:");
                    Console.WriteLine($" погибло клеток - {totalDeaths, 8}");
                    Console.WriteLine($" родилось клеток - {totalBirths, 7}");
                }
                System.Threading.Thread.Sleep(100);
                Console.CursorVisible = false;
            }

            #endregion

            Console.ReadKey();
        }
    }
}
