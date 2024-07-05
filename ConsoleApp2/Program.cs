using System;
using System.Threading;
using System.Linq;
using System.Xml.Serialization;

namespace smoke
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] initValue1 = { 1, 0, 0 };
            int[] initValue2 = { 0, 1, 0 };
            int[] initValue3 = { 0, 0, 1 };
            Smoker agent = new Smoker(null, 4, true);
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
        static int[] desk = { 0, 0, 0 };
        static bool isSmoking = false;
        Semaphore sem = new Semaphore(2, 4);
        //Agent agent = new Agent();
        public Smoker(int[] initRes, int i, bool isAgent = false)
        {
            this.initRes = initRes;
            inventory = initRes;

            if (isAgent == true)
            {
                Thread r = new Thread(Drop);
                r.Name = "Agent";
                r.Start();
            }
            else
            {
                Thread thread = new Thread(Grab);
                thread.Name = $"Smoker {i}";
                thread.Start();
            }
        }
        private void Grab()
        {
            for (; ; )
            {
                sem.WaitOne();
                if (desk[0] != inventory[0] && desk[1] != inventory[1] && desk[2] != inventory[2])
                { 
                    Thread.Sleep(5);
                    Console.WriteLine($"{Thread.CurrentThread.Name} grabbed resources");
                    inventory = Array.ConvertAll(inventory, i  => i^0);
                    desk = Array.ConvertAll(desk, i => i*0);
                    sem.Release();
                    Craft();

                }
                else
                {
                    sem.Release();
                }
            }
        }
        private void Craft()
        {

            isSmoking = true;
            inventory = initRes;
            Console.WriteLine($"{Thread.CurrentThread.Name} is Smoking");
            Thread.Sleep(SMOKING_TIME);
            isSmoking = false;
            Grab();
        }
        private void Drop()
        {
            sem.WaitOne();
            for (; ; )
            {
                if (isSmoking == false)
                {
                    Random rnd = new Random();
                    
                    switch (rnd.Next(3))
                    {
                        case 0: desk[0] = 1; desk[1] = 1; desk[2] = 0; break;
                        case 1: desk[0] = 1; desk[1] = 0; desk[2] = 1; break;
                        case 2: desk[0] = 0; desk[1] = 1; desk[2] = 1; break;
                    }
                    Thread.Sleep(0); 
                    Console.WriteLine($"--------------- \n Agent dropped resources on the desk, {desk[0]} {desk[1]} {desk[2]}");
                }
                Thread.Sleep(500);
            }
            sem.Release();
        }
    }
    //class Agent
    //{
    //    public int[] desk = [0, 0, 0];
    //    public Semaphore sem = new Semaphore(1, 4);
    //    public Agent()
    //    {
    //        Thread thread = new Thread(Drop);
    //        thread.Name = "Agent";
    //        thread.Start();
    //    }
    //    private void Drop ()
    //    {
    //        Random random = new Random();
    //        sem.WaitOne();
    //        switch (random.Next(3))
    //        {
    //            case 0: desk = [1, 1, 0]; break;
    //            case 1: desk = [1, 0, 1]; break;
    //            case 2: desk = [0, 1, 1]; break;
    //        }
    //        Console.WriteLine($"Agent dropped resources on the desk, {desk}");
    //        Thread.Sleep(500);
    //        sem.Release();
    //    }
    //}
}