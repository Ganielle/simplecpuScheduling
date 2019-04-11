using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cpuscheduling
{
    class cpumenu
    {
        private string menuchoose;
        private string menufcfs;
        private string menusjf;
            //this is for main menu choices
        public string setchoices
         {
            get { return menuchoose; }
            set { menuchoose = value; }
         }
            //this is the main menu
        public void mainmenu(string choice)
         {
           Console.Clear();
           Console.WriteLine("\n\nWELCOME TO CHUNCHUNMARU'S CPU SCHEDULING!");
           Console.WriteLine("Made by: Jan Bien Gabrielle A. Daniel");
           Console.WriteLine("         Ariel V. Teves");
           Console.WriteLine("         Cassandrar Elyssa Caitlin O. Lisondra\n\n");
            for (int a = 0; a <= 50; a++)
            {
              Console.Write("=");
            }
           Console.WriteLine("\n\n *MAIN MENU*");
           Console.WriteLine("\n\n1.)First Come First Server (FCFS NON-PREEMPTIVE CPU SCHEDULING)");
           Console.WriteLine("2.)Shortest Job First (SJF PREEMPTIVE CPU SCHEDULING");
           Console.WriteLine("3.)Best Fit (Memory Scheduling)");
           Console.WriteLine("4.)Exit\n\n");
           Console.Write("Choose:  ");
           choice = Console.ReadLine();
           menuchoose = choice;
         }
            //this is the fcfs main menu
        public void fcfsmenu(string choice, int[] n, int[] burst, int[] arrival)
        {
            fcfsmainmenu:
            Console.Clear();
            Console.WriteLine("\n\nFirst Come First Serve (FCFS CPU SCHEDULING)");
            Console.WriteLine("\n\n1.)Proceed");
            Console.WriteLine("2.)Back");
            Console.Write("\nChoose:  ");
            choice = Console.ReadLine();
            if(choice == "1")
            {
                fcfscpusched fcfs = new fcfscpusched();
                fcfs.fcfsmethod(n, burst, arrival);
            }
            else if(choice == "2")
            {
                Console.Clear();
                Console.WriteLine("Going back to menu ....");
                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("PLEASE CHOOSE FROM 1-2 ONLY!");
                System.Threading.Thread.Sleep(3000);
                goto fcfsmainmenu;
            }
        }
        public void sjfmenu(String choice, int[] process, int[] bt, int[] arr)
        {
        sjfmainmenu:
            Console.Clear();
            Console.WriteLine("\n\nSHORTEST JOB FIRST (SJF CPU SCHEDULING)");
            Console.WriteLine("\n\n1.)Proceed");
            Console.WriteLine("2.)Back");
            Console.Write("\nChoose:  ");
            choice = Console.ReadLine();
            if (choice == "1")
            {
                sjfcpusched sjf = new sjfcpusched();
                sjf.sjfmethod(process, bt, arr);
                
            }
            else if (choice == "2")
            {
                Console.Clear();
                Console.WriteLine("Going back to menu ....");
                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("PLEASE CHOOSE FROM 1-2 ONLY!");
                System.Threading.Thread.Sleep(3000);
                goto sjfmainmenu;
            }
        }
        public void bestfitmenu(String choice,int[] process,int[] block)
        {
            sjfmainmenu:
            Console.Clear();
            Console.WriteLine("\n\nBEST FIT MEMORY MANAGEMENT");
            Console.WriteLine("\n\n1.)Proceed");
            Console.WriteLine("2.)Back");
            Console.Write("\nChoose:  ");
            choice = Console.ReadLine();
            if (choice == "1")
            {
                bestfitmemorymanagement bf = new bestfitmemorymanagement();
                bf.bfmemmanage(process, block);
            }
            else if (choice == "2")
            {
                Console.Clear();
                Console.WriteLine("Going back to menu ....");
                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("PLEASE CHOOSE FROM 1-2 ONLY!");
                System.Threading.Thread.Sleep(3000);
                goto sjfmainmenu;
            }
        }
    }
}
