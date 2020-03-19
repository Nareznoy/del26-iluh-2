using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kolpar
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader R = new StreamReader("in.txt");
            int[] mas = new int[3] { 0, 0, 0 };
            int n_ch = 0;
            int ch;
            int n26 = 0;
            int n13 = 0;
            int n2 = 0;
            int n_par_ryd = 0;
            while (R.EndOfStream == false)
            {
                ch = Convert.ToInt32(R.ReadLine());
                if (n_ch < 3)
                    mas[n_ch] = ch;
                else
                {
                    mas[0] = mas[1];
                    mas[1] = mas[2];
                    mas[2] = ch;
                }
                if (n_ch == 1)
                {
                    if (mas[0] * mas[1] % 26 == 0)
                        n_par_ryd++;
                }
                else if (n_ch > 1)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (mas[i] * mas[2] % 26 == 0)
                            n_par_ryd++;
                    }
                }
                if (ch % 26 == 0)
                {
                    n26++;
                }
                else if (ch % 13 == 0)
                {
                    n13++;
                }
                else if (ch % 2 == 0)
                {
                    n2++;
                }
                n_ch++;
            }
            int n_par = n26 * (n_ch - 1) - ((n26 * (n26 - 1)) / 2) + n13 * n2;
            n_par -= n_par_ryd;
            Console.WriteLine("Количество пар числел, что делятся на 26 без остатка и находятся на растоянии 3 пробелов друг от друга = {0}", n_par);

        }
    }
}
