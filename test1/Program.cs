using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] text = System.IO.File.ReadAllLines(@"C:\triangle2.txt");   
            int n = text.Length;
            string [][]splittext = new string[n][];

            for (int i = 0; i < n; i++)
            {
                splittext[i] = text[i].Split();
                Console.WriteLine(text[i]);
            }

            int[][] mas = new int[n][];
            for (int i = 0; i < n; i++)
            {
                int tmp = splittext[i].Length;
                mas[i] = new int[tmp];
                for (int j = 0; j < tmp; j++)
                {
                    mas[i][j] = Convert.ToInt32(splittext[i][j]);
                }
                
            }
            string str;
            Console.WriteLine(Test(mas, out str).ToString());
            Console.WriteLine(str);
            Console.ReadKey();
        }
        public static int Test(int[][] tmp, out string str)
        {
            int indexrow = 2;
            int indexcolumn = 0;
            int result = 0;
            int rowCount = tmp.Length;
            int[] perebor = new int[3];
            for (int i = 0; i < 3; i++)
                perebor[i] = 0;
            int[] rowLenght = new int[tmp.Length];
            for (int i = 0; i < tmp.Length; i++)
            {

                rowLenght[i] = tmp[i].Length;
            }
            result += tmp[0][0];
            str = null;
            str = str + " " + tmp[0][0];
            result += Math.Max(tmp[1][0], tmp[1][1]);
            str = str + " " + Math.Max(tmp[1][0], tmp[1][1]);
            indexcolumn = (Math.Max(tmp[1][0], tmp[1][1]) == tmp[1][0]) ? 0 : 1;
            do
            {
                if ((indexcolumn != 0) && (indexcolumn < tmp[indexrow].Length)) 
                {
                    perebor[0] = tmp[indexrow][indexcolumn - 1];
                    perebor[1] = tmp[indexrow][indexcolumn];
                    perebor[2] = tmp[indexrow][indexcolumn + 1];
                    
                    result += perebor.Max();
                    if (perebor.Max() == perebor[0])
                        indexcolumn--;
                    else if (perebor.Max() == perebor[2])
                        indexcolumn++;
                    str = str + " " + tmp[indexrow][indexcolumn];
                }
                else
                {
                    result += Math.Max(tmp[indexrow][0], tmp[indexrow][0]);
                    indexcolumn = (Math.Max(tmp[1][0], tmp[1][1]) == tmp[indexrow][0]) ? 0 : 1;
                    str = str + " " + tmp[indexrow][indexcolumn];
                }
                indexrow++;
            } while (indexrow < rowCount);
            return result;
        }
    }


}

     
