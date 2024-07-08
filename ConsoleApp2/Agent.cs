namespace ConsoleApp2
{
    internal class Agent
    {

        static Semaphore sem = new Semaphore(1, 4);
        Random random = new Random();
        Table table;
        public Agent(Table table)
        {
            Thread thread = new Thread(Supply);
            thread.Name = "Agent";
            thread.Start();
            this.table = table;
        }
        void Supply()
        {
            byte rndm;
            table.sem.WaitOne();
            for (; ; )
            {
                rndm = (byte)random.Next(3);
                switch (rndm)
                {

                    case 0: table.onTable[0] = 1; table.onTable[1] = 1; table.onTable[2] = 0; break;
                    case 1: table.onTable[0] = 1; table.onTable[1] = 0; table.onTable[2] = 1; break;
                    case 2: table.onTable[0] = 0; table.onTable[1] = 1; table.onTable[2] = 1; break;
                }
                
            }
        }
    }
}
