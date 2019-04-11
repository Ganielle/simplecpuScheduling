using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cpuscheduling
{
    class bestfitmemorymanagement
    {
        public void bfmemmanage(int[] blocks, int[] process)
        {
            Regex rx = new Regex(@"^[2-9]+$");
            String proc, blo;
            int[] fragment = new int[20],blockarr = new int[20], procarr = new int[20], parray = new int[20], barray = new int[20];
            int nb,np,temp,lowest=9999,blocheck,proccheck,blonocheck,procnocheck;
            tryagain:
            Console.Clear();
            Console.Write("\n\n Enter number of Blocks (max of 20): ");
            blo = Console.ReadLine();
            int.TryParse(blo, out blonocheck);
            if(string.IsNullOrWhiteSpace(blo) == true || blonocheck < 2 || blonocheck > 20)
            {
                Console.Clear();
                Console.WriteLine("\n\nTry again!");
                System.Threading.Thread.Sleep(2000);
                goto tryagain;
            }

            tryprocess:
            Console.Write("\n\n Enter number of Process (max of 20): ");
            proc = Console.ReadLine();
            int.TryParse(proc, out procnocheck);
            if (string.IsNullOrWhiteSpace(proc) == true || procnocheck < 2 || procnocheck > 20)
            {
                Console.WriteLine("\n\nTry again!");
                System.Threading.Thread.Sleep(2000);
                goto tryprocess;
            }
            else
            {
                Console.Clear();
                nb = int.Parse(blo);
                np = int.Parse(proc);
                //this will enter size of blocks
                Console.WriteLine("Enter the size of blocks");
                for(int a = 1; a <= nb; a++)
                {
                    tryagainblock:
                    Console.Write("Block no." + a + ": ");
                    String blono = Console.ReadLine();
                    if(int.TryParse(blono,out blocheck))
                    {
                        blockarr[a] = int.Parse(blono);
                    }
                    else
                    {
                        Console.WriteLine("TRY AGAIN");
                        goto tryagainblock;
                    }
                }
                //this will enter size of process
                Console.WriteLine("\n\nEnter the size of process");
                for (int a = 1; a <= np; a++)
                {
                    tryagainprocess:
                    Console.Write("Process no." + a + ": ");
                    String procno = Console.ReadLine();
                    if (int.TryParse(procno, out proccheck))
                    {
                        process[a] = int.Parse(procno);
                    }
                    else
                    {
                        Console.WriteLine("TRY AGAIN");
                        goto tryagainprocess;
                    }
                }
                var watch = System.Diagnostics.Stopwatch.StartNew();
                watch.Start();
                for (int i = 1; i <= np; i++)
                {
                    for (int j = 1; j <= nb; j++)
                    {
                        if (barray[j] != 1)
                        {
                            temp = blockarr[j] - process[i];
                            if (temp >= 0)
                                if (lowest > temp)
                                {
                                    parray[i] = j;
                                    lowest = temp;
                                }
                        }
                    }

                    fragment[i] = lowest;
                    barray[parray[i]] = 1;
                    lowest = 10000;
                }
                Console.Clear();
                Console.WriteLine("\n\nProcess\t\tProcess size\t\tBlock no.\t\tBlock size\t\tFragment");
                for (int i = 1; i <= np && parray[i] != 0; i++)
                {
                    Console.WriteLine("P" + i + "\t\t" + process[i] + "\t\t\tB" + parray[i] + "\t\t\t" + blockarr[parray[i]] + "\t\t\t" + fragment[i]);
                }
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                Console.WriteLine("\n\nExecution Time: " + (float)elapsedMs + "ms");
                restart:
                Console.Write("\n\nDo you want to try again?(Y/N): ");
                String choose = Console.ReadLine();
                switch (choose)
                {
                    case "Y":
                    case "y":
                        Console.Clear();
                        Console.Write("\n\n RESTART IN PROGRESS...");
                        System.Threading.Thread.Sleep(2000);
                        goto tryagain;
                    case "N":
                    case "n":
                        Console.Clear();
                        Console.Write("\n\n MAIN MENU...");
                        System.Threading.Thread.Sleep(2000);
                        break;
                    default:
                        goto restart;
                }
            }
        }
    }
}
