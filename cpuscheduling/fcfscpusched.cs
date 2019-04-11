using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace cpuscheduling
{
    class fcfscpusched
    {
        Regex rx = new Regex(@"^[2-9]+$");
        public void fcfsmethod(int[] n, int[] burst, int[] arrival)
        {
            int temp,temp2,temp3,btcheck,atcheck;
            double avwt = 0.0, avtat = 0.0;
            int[] wt = new int[10], tat = new int[10];
            Boolean checking = false;
        //this is the mainmenu
        fcfscpumainmenu:
            Console.Clear();
            Console.Write("\n\nEnter how many process(max of 10): ");
            String p = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(p) == true || !rx.IsMatch(p))
            {
                Console.Clear();
                Console.WriteLine("\n\nTry again!");
                System.Threading.Thread.Sleep(2000);
                goto fcfscpumainmenu;
            }
            else
            {
                int many = Convert.ToInt32(p);
                switch (many)
                {
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                        //this will put numbers inside n
                        for(int a = 0; a < many; a++)
                        {
                            n[a] = a;
                        }
                    //ths is for arrival time

                        inputagain:
                        Console.Clear();
                        Console.WriteLine("\nEnter process arrival time ");
                        for (int a = 0; a < many; a++)
                        {
                            failed:
                            Console.Write("P" + a + ": ");
                            String arr;
                            arr = Console.ReadLine();
                            if (int.TryParse(arr,out atcheck))
                            {
                                arrival[a] = int.Parse(arr);
                            }
                            else
                            {
                                Console.WriteLine("try again!");
                                goto failed;
                            }
                        }
                        //this will check if there's a 0 entry point
                        for(int a = 0; a < many; a++)
                        {
                            if(arrival[a] != 0 && checking == false)
                            {
                                checking = false;
                            }
                            else
                            {
                                checking = true;
                                break;
                            }
                        }
                        if(checking == false)
                        {
                            Console.WriteLine("THERE'S NO ENTRY POINT! ONE PROCESS MUST ARRIVED AT 0!");
                            System.Threading.Thread.Sleep(2000);
                            goto inputagain;
                        }
                        //this is for burst time
                        burstime:
                        Console.WriteLine("\n\nEnter process burst time ");
                        for (int a = 0; a < many; a++)
                        {
                            inputagain2:
                            Console.Write("P" + a + ": ");
                            String bursted;
                            bursted = Console.ReadLine();
                            if (int.TryParse(bursted, out btcheck))
                            {
                                burst[a] = int.Parse(bursted);
                            }
                            else
                            {
                                Console.WriteLine("try again!");
                                goto inputagain2;
                            }
                        }
                        //this will compute the execution time 
                        var watch = System.Diagnostics.Stopwatch.StartNew();
                        watch.Start();
                        //this will show all the inputs
                        Console.Clear();
                        Console.WriteLine("\nProcess\t\tArrival Time\t\tBurst Time\t\tWaiting Time\t\tTurnaround Time");
                        //bubble sort
                        for (int j = 0; j <= many - 2; j++)
                        {
                            for (int i = 0; i <= many  - 2; i++)
                            {
                                if (arrival[i] > arrival[i + 1])
                                {
                                    temp2 = arrival[i + 1];
                                    arrival[i + 1] = arrival[i];
                                    arrival[i] = temp2;
                                    temp = burst[i + 1];
                                    burst[i + 1] = burst[i];
                                    burst[i] = temp;
                                    temp3 = n[i + 1];
                                    n[i + 1] = n[i];
                                    n[i] = temp3;
                                }
                            }
                        }
                        for(int a = 0; a < many; a++)
                        {
                            if (arrival[a] < wt[a] )
                            {
                                Console.WriteLine("The P" + n[a] + " burst time is less than P" + n[a+1] + " arrival time");
                                goto burstime;
                            }
                        }
                        //this will calculate waiting time
                        for(int a = 1; a < many; a++)
                        {
                            wt[0] = arrival[0];
                            for(int j = 0; j < a; j++)
                            {

                                wt[a] += burst[j];
                            }
                        }
                        for (int a = 0; a < many; a++)
                        {
                        }
                        //this will calculate turnaround time and at the same time draw the gantt chart
                        for (int i = 0; i < many; i++)
                        {
                            tat[i] = burst[i] + wt[i];
                            avwt += Convert.ToDouble(wt[i]);
                            avtat += Convert.ToDouble(tat[i]);
                            Console.Write("\nP" + i + "\t\t" + arrival[i] + "\t\t\t" + burst[i] + "\t\t\t" + wt[i] + "\t\t\t" + tat[i]);
                        }
                        //this will show the gantt chart
                        Console.WriteLine("\n\nGANTT CHART\n");
                        for (int i = 0; i < many; i++)
                        {
                            Console.Write("(P" + n[i] + ")");
                            Console.Write(wt[i] + " ===> ");
                        }
                        Console.Write(tat[many - 1] + "\n\n");
                        avwt /= Convert.ToDouble(many);
                        avtat /= Convert.ToDouble(many);
                        watch.Stop();
                        var elapsedMs = watch.ElapsedMilliseconds;
                        Console.WriteLine("Average Waiting Time: " +avwt + "ms");
                        Console.WriteLine("Average Turnaround Time: " + avtat + "ms");
                        Console.WriteLine("Execution Time: " + elapsedMs+"ms");
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
                                goto fcfscpumainmenu;
                            case "N":
                            case "n":
                                Console.Clear();
                                Console.Write("\n\n MAIN MENU...");
                                System.Threading.Thread.Sleep(2000);
                                break;
                            default:
                                goto tryagain;
                        }
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\n\nCannot exceed 10 process or more than 1 process");
                        System.Threading.Thread.Sleep(3000);
                        goto fcfscpumainmenu;
                }
            }
        }
    }
}
