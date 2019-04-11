using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cpuscheduling
{
    class sjfcpusched
    {
        public void sjfmethod(int[] process, int[] bt, int[] arr)
        {
            Regex rx = new Regex(@"^[2-9]+$");
            String p;
            int many,atcheck,btcheck,temp,temp2,temp3,pos,total = 0;
            double avg_wt, avg_tat;
            int[] wt = new int[10], tat = new int[10];
            Boolean checking = false;
            tryagainprocess:
            Console.Clear();
            Console.Write("\n\n Enter number of process: ");
            p = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(p) == true || !rx.IsMatch(p))
            {
                Console.Clear();
                Console.WriteLine("Please Enter from 2-10 only");
                System.Threading.Thread.Sleep(3500);
                goto tryagainprocess;
            }
            else
            {
                many = Convert.ToInt32(p);
                if (many >= 2 || many <= 10)
                {
                    //this will create process
                    for (int a = 0; a < many; a++)
                    {
                        process[a] = a;
                    }
                //this is for arrival time
                arrivaltime:
                    Console.Clear();
                    Console.WriteLine("\n\nPlease enter process arrival time");
                    for (int a = 0; a < many; a++)
                    {
                    failed:
                        Console.Write("P" + a + ": ");
                        String stringarr;
                        stringarr = Console.ReadLine();
                        if (int.TryParse(stringarr, out atcheck))
                        {
                            arr[a] = int.Parse(stringarr);
                        }
                        else
                        {
                            Console.WriteLine("Try again");
                            goto failed;
                        }
                    }
                    //this will check if there's a 0 entry point
                    for (int a = 0; a < many; a++)
                    {
                        if (arr[a] != 0 && checking == false)
                        {
                            checking = false;
                        }
                        else
                        {
                            checking = true;
                            break;
                        }
                    }
                    if (checking == false)
                    {
                        Console.WriteLine("THERE'S NO ENTRY POINT! ONE PROCESS MUST ARRIVED AT 0!");
                        System.Threading.Thread.Sleep(2000);
                        goto arrivaltime;
                    }
                //this is for burst time
                bursttime:
                    Console.WriteLine("\n\n Please enter process burst time ");
                    for (int a = 0; a < many; a++)
                    {
                        Console.Write("P" + a + ": ");
                        String bursted = Console.ReadLine();
                        if (int.TryParse(bursted, out btcheck))
                        {
                            bt[a] = int.Parse(bursted);
                        }
                        else
                        {
                            Console.WriteLine("Try again");
                            goto bursttime;
                        }
                    }
                    //this will compute the execution time 
                    var watch = System.Diagnostics.Stopwatch.StartNew();
                    watch.Start();
                    //this will show all inputs
                    Console.Clear();
                    //selection sort
                    for (int j = 0; j <= many - 2; j++)
                    {
                        pos = j;
                        for (int i = 0; i <= many - 2; i++)
                        {
                           if (arr[j] < bt[pos + 1] && bt[j] < bt[pos + 1])
                            {
                                temp2 = arr[i + 1];
                                arr[i + 1] = arr[i];
                                arr[i] = temp2;
                                temp = bt[i + 1];
                                bt[i + 1] = bt[i];
                                bt[i] = temp;
                                temp3 = process[i + 1];
                                process[i + 1] = process[i];
                                process[i] = temp3;
                            }
                        }
                    }
                    //this will calculate waiting time
                    for(int a = 0; a < many; a++)
                    {
                        wt[a] = arr[0];
                        for(int j = 0; j < a; j++)
                        {
                            wt[a] += bt[j];
                            total += wt[a];
                        }
                    }
                    avg_wt = Convert.ToDouble(total / many);
                    total = 0;
                    //this will print the inputs in order
                    Console.WriteLine("\nProcess\t\tArrival Time\t\tBurst Time\t\tWaiting Time\t\tTurnaround Time");
                    for(int a = 0; a < many; a++)
                    {
                        tat[a] = bt[a] + wt[a];
                        total += tat[a];
                        Console.Write("\nP" + process[a] + "\t\t" + arr[a] + "\t\t\t" + bt[a] + "\t\t\t" + wt[a] + "\t\t\t" + tat[a]);
                    }
                    avg_tat = Convert.ToDouble(total / many);
                    //this will print the gantt chart
                    Console.WriteLine("\nGANTT CHART\n");
                    for (int i = 0; i < many; i++)
                    {
                        Console.Write("(P" + process[i] + ")");
                        Console.Write(wt[i] + " ===> ");
                    }
                    Console.Write(tat[many - 1] + "\n\n");
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    Console.WriteLine("Average Waiting Time: " + avg_wt + "ms");
                    Console.WriteLine("Average Turnaround Time: " + avg_tat + "ms");
                    Console.WriteLine("Execution Time: " + elapsedMs + "ms");
                    tryagain:
                    Console.Write("\n\nDo you want to try again?(Y/N): ");
                    String choose = Console.ReadLine();
                    switch (choose)
                    {
                        case "Y":
                        case "y":
                            Console.Clear();
                            Console.Write("\n\n RESTART IN PROGRESS...");
                            System.Threading.Thread.Sleep(2000);
                            goto tryagainprocess;
                        case "N":
                        case "n":
                            Console.Clear();
                            Console.Write("\n\n MAIN MENU...");
                            System.Threading.Thread.Sleep(2000);
                            break;
                        default:
                            goto tryagain;
                    }
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n\nCannot exceed 10 process or more than 1 process");
                    System.Threading.Thread.Sleep(3000);
                    goto tryagainprocess;
                }
            }
        }
    }
}
