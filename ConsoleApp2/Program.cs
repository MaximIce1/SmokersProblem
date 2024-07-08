using System;
using System.Threading;
using System.Linq;
using System.Runtime.CompilerServices;

namespace smoke
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] initValue1 = { 1, 0, 0 };
            int[] initValue2 = { 0, 1, 0 };
            int[] initValue3 = { 0, 0, 1 };
            int[] initEmpty = { 0 };
            Smoker smoker1 = new Smoker(initValue2, 1);
            Smoker smoker2 = new Smoker(initValue3, 2);
            Smoker smoker3 = new Smoker(initValue1, 3);


        }
    }
    class Smoker
    {
        const int SMOKING_TIME = 1000;
        int[] inventory = { 0, 0, 0 };
        int[] initRes = { 0, 0, 0 };

        PrintConsole print = new PrintConsole();
        static Agent agent = new Agent();
        public Smoker(int[] initRes, int i, bool isAgent = false)
        {
            this.initRes = initRes;
            inventory = initRes;
            Thread thread = new Thread(Grab);
            thread.Name = $"Smoker {i}";
            thread.Start();
        }
        private void Grab()
        {
            for (; ; )
            {
                agent.sem.WaitOne();
                if (agent.desk[0] != inventory[0] && agent.desk[1] != inventory[1] && agent.desk[2] != inventory[2])
                {
                    Thread.Sleep(5);
                    inventory = Array.ConvertAll(inventory, i => i ^ 0);
                    agent.desk = Array.ConvertAll(agent.desk, i => i * 0);
                    agent.sem.Release();
                    Craft();

                }
                else
                {
                    agent.sem.Release();
                }
            }
        }
        private void Craft()
        {

            agent.isSomeoneSmoking = true;
            inventory = initRes;
            Thread.Sleep(5);
            print.WriteInfo($"{Thread.CurrentThread.Name} is smoking");
            Thread.Sleep(SMOKING_TIME);
            agent.isSomeoneSmoking = false;
            Grab();
        }
    }
    class PrintConsole
    {
        public void WriteInfo(string arg)
        {
            Console.WriteLine(arg);
        }
    }
    class Agent
    {
        PrintConsole print = new PrintConsole();
        public Semaphore sem = new Semaphore(2, 4); 
        public bool isSomeoneSmoking = false;
        public int[] desk = { 0, 0, 0 };
        public Agent ()
        {
            Thread thread = new Thread(Drop);
            thread.Name = "Agent";
            thread.Start();
        }

        private void Drop()
        {
            sem.WaitOne();
            for (; ; )
            {
                if (isSomeoneSmoking == false)
                {
                    Random rnd = new Random();

                    switch (rnd.Next(3))
                    {
                        case 0: desk[0] = 1; desk[1] = 1; desk[2] = 0; break;
                        case 1: desk[0] = 1; desk[1] = 0; desk[2] = 1; break;
                        case 2: desk[0] = 0; desk[1] = 1; desk[2] = 1; break;
                    }
                    Thread.Sleep(0);
                    print.WriteInfo($"Agent dropped resources, {desk[0]}, {desk[1]}, {desk[2]}");
                }
                Thread.Sleep(500);
            }
        }
    }
}