using System;
using System.Threading;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ConsoleApp2
{
    class Program
    {
        static Table Table = new Table();
        static Logger Logger = new Logger();
        static void Main(string[] args)
        {
            int[] initInv1 = { 1, 0, 0 };
            int[] initInv2 = { 0, 1, 0 };
            int[] initInv3 = { 0, 0, 1 };
            File.Create("outfile.txt").Close();
            Agent agent = new Agent(Table, Logger);
            Smoker smoker1 = new Smoker(Table, Logger, 1, initInv1);
            Smoker smoker2 = new Smoker(Table, Logger, 2, initInv2);
            Smoker smoker3 = new Smoker(Table, Logger, 3, initInv3);

        }
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    //class Program
    //{

    //    static void Main(string[] args)
    //    {
    //        int[] initValue1 = { 1, 0, 0 };
    //        File.Create("outfile.txt").Close();
    //        int[] initValue2 = { 0, 1, 0 };
    //        int[] initValue3 = { 0, 0, 1 };
    //        int[] initEmpty = { 0 };
    //        Smoker smoker1 = new Smoker(initValue2, 1);
    //        Smoker smoker2 = new Smoker(initValue3, 2);
    //        Smoker smoker3 = new Smoker(initValue1, 3);
            

    //    }
    //}
    //class Smoker
    //{
    //    const int SMOKING_TIME = 1000;
    //    int[] inventory = { 0, 0, 0 };
    //    int[] initRes = { 0, 0, 0 };

    //    static PrintConsole print = new PrintConsole();
    //    static Agent agent = new Agent();
    //    public Smoker(int[] initRes, int i, bool isAgent = false)
    //    {
    //        this.initRes = initRes;
    //        inventory = initRes;
    //        Thread thread = new Thread(Grab);
    //        thread.Name = $"Smoker {i}";
    //        thread.Start();
    //    }
    //    private void Grab()
    //    {
    //        for (; ; )
    //        {
    //            agent.sem.WaitOne();
    //            if (agent.desk[0] != inventory[0] && agent.desk[1] != inventory[1] && agent.desk[2] != inventory[2])
    //            {
    //                Thread.Sleep(5);
    //                inventory = Array.ConvertAll(inventory, i => i ^ 0);
    //                agent.desk = Array.ConvertAll(agent.desk, i => i * 0);
    //                agent.sem.Release();
    //                Craft();

    //            }
    //            else
    //            {
    //                agent.sem.Release();
    //            }
    //        }
    //    }
    //    private void Craft()
    //    {

    //        agent.isSomeoneSmoking = true;
    //        inventory = initRes;
    //        //Thread.Sleep(5);
    //        print.WriteInfo($"{Thread.CurrentThread.Name} is smoking");
    //        Thread.Sleep(SMOKING_TIME);
    //        agent.isSomeoneSmoking = false;
    //        Grab();
    //    }
    //}
    //class PrintConsole
    //{
    //    Logging logging = new Logging();
    //    public void WriteInfo(string arg)
    //    {
    //        Console.WriteLine(arg);
    //        logging.Log (arg);
    //        //Thread.Sleep(100);
    //    }
    //}
    //class Logging
    //{
    //    public void Log(string arg)
    //    {
    //        FileStream ostrm;
    //        StreamWriter writer;
    //        TextWriter oldOut = Console.Out;
    //        ostrm = new FileStream("outfile.txt", FileMode.Append, FileAccess.Write);
    //        writer = new StreamWriter(ostrm);
    //        Console.SetOut(writer);
    //        Console.WriteLine(arg);
    //        Console.SetOut(oldOut);
    //        writer.Close();
    //        ostrm.Close();
    //    }
    //}
    //class Agent
    //{
    //    PrintConsole print = new PrintConsole();
    //    public Semaphore sem = new Semaphore(2, 4);
    //    public bool isSomeoneSmoking = false;
    //    public int[] desk = { 0, 0, 0 };
    //    public Agent ()
    //    {
    //        Thread thread = new Thread(Drop);
    //        thread.Name = "Agent";
    //        thread.Start();
    //    }

    //    private void Drop()
    //    {
    //        sem.WaitOne();
    //        for (; ; )
    //        {
    //            if (isSomeoneSmoking == false)
    //            {
    //                Random rnd = new Random();

    //                switch (rnd.Next(3))
    //                {
    //                    case 0: desk[0] = 1; desk[1] = 1; desk[2] = 0; break;
    //                    case 1: desk[0] = 1; desk[1] = 0; desk[2] = 1; break;
    //                    case 2: desk[0] = 0; desk[1] = 1; desk[2] = 1; break;
    //                }
    //                Thread.Sleep(0);
    //                print.WriteInfo($"Agent dropped resources, {desk[0]}, {desk[1]}, {desk[2]}");
    //            }
    
    //        }
    //    }
    //}
    
}