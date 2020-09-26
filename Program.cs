using System;

namespace Ulearn142
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] vers1 = new string[]
            {
                "1.6.47",
                "0.001",
                "1.5.0",
                "5.05",
                "7.0.1",
                "5.1.2.4"
            };
            string[] vers2 = new string[]
            {
                "0.0.1",
                "0.1",
                "1.5.1",
                "5.005",
                "7",
                "5.1.3"
            };
            for (int i = 0; i < Math.Min(vers1.Length, vers2.Length); i++)
            {
                if (VerCmp(vers1[i], vers2[i]) == 0)
                {
                    Console.WriteLine(vers1[i] + " = " + vers2[i]);
                }
                else if (VerCmp(vers1[i], vers2[i]) == 1)
                {
                    Console.WriteLine(vers1[i] + " > " + vers2[i]);
                }
                else if (VerCmp(vers1[i], vers2[i]) == -1)
                {
                    Console.WriteLine(vers1[i] + " < " + vers2[i]);
                }
            }

        }

    public static int VerCmp(string version1, string version2)
        {
            // каждая строка разбиваются на подстроки
            // в исходной строке эти подстроки разделяет '.'
            string[] ver1 = version1.Split('.');
            string[] ver2 = version2.Split('.');

            // проверяем каждый элемент в 2ух массивах
            // (для сравнения мы каждую строку переводим в целое число,
            // в следствии этого, незначемые нули не учитываются при сравнении)
            for (int i = 0; i < Math.Max(ver1.Length, ver2.Length); i++)
            {
                // в случае, когда индекс >= размера первого массива
                // мы сравниваем только элементы второго с 0
                if (i >= ver1.Length )
                {
                    if (int.Parse(ver2[i]) > 0)
                    {
                        // если находится элемент > 0, то второй массив больше
                        return -1;
                    }
                    continue;
                }

                // анологисно, когда индекс >= размера второго массива
                if (i >= ver2.Length)
                {
                    if (int.Parse(ver1[i]) > 0)
                    {
                        return 1;
                    }
                    continue;
                }

                // если индекс меньше, чем каждая из длин массивов,
                // то мы просто сравниваем текущие числа
                if (int.Parse(ver1[i]) > int.Parse(ver2[i]))
                {
                    return 1;
                }
                if (int.Parse(ver1[i]) < int.Parse(ver2[i]))
                {
                    return -1;
                }
            }
            return 0;
        }
    }
}
