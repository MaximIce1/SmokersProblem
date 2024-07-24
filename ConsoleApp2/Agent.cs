namespace ConsoleApp2
{
    internal class Agent
    {
        Random random = new Random();
        Table table;
        Logger logger;
        public Agent(Table table, Logger logger)
        {
            Thread thread = new Thread(Supply);
            thread.Name = "Agent";
            thread.Start();
            this.table = table;
            this.logger = logger;
        }
        void Supply()
        {
            byte rndm;
            table.sem.WaitOne();
            for (; ; )
            {
                if (table.isSomeoneSmoking == false)
                {
                    rndm = (byte)random.Next(3);
                    switch (rndm)
                    {

                        case 0: table.onTable[0] = 1; table.onTable[1] = 1; table.onTable[2] = 0; break;
                        case 1: table.onTable[0] = 1; table.onTable[1] = 0; table.onTable[2] = 1; break;
                        case 2: table.onTable[0] = 0; table.onTable[1] = 1; table.onTable[2] = 1; break;

                    }
                    logger.log($"Agent provided resources: {table.onTable[0]} {table.onTable[1]} {table.onTable[2]}");
                }
            }
        }
    }
}
