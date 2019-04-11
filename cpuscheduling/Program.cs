using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cpuscheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            String mainchoices = null, fcfschoice = null, sjfchoice = null,bfchoice = null;
            //this is for fcfs
            int[] b = new int[10], c = new int[10], a = new int[10];
            //this is for sjf
            int[] process = new int[10], bt = new int[10], arr = new int[10];
            //this is for bestfit
            int[] proc = new int[20], block = new int[20];
            cpumenu menu = new cpumenu();

            //mainmenu
            mainmenu:

            menu.mainmenu(mainchoices);

            switch (menu.setchoices)
            {
                case "1":
                case "FCFS":
                case "fcfs":
                    menu.fcfsmenu(fcfschoice,a,b,c);
                    goto mainmenu;
                case "2":
                case "SJF":
                case "sjf":
                    menu.sjfmenu(sjfchoice,process,bt,arr);
                    goto mainmenu;
                case "3":
                    menu.bestfitmenu(bfchoice,proc, block);
                    goto mainmenu;
                case "4":
                    Console.Clear();
                    Console.WriteLine("\n\n\nTHANK YOU FOR USING CHUNCHUNMARU'S CPU SCHEDULING!");
                    Console.WriteLine("\n\n\nThe system will now exit....");
                    System.Threading.Thread.Sleep(3000);
                    System.Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Please choose from 1-4 or cpu scheduling name ex: FCFS (only applies to CPU scheduling)!");
                    System.Threading.Thread.Sleep(3500);
                    goto mainmenu;
            }
        }
    }
}
