namespace smokersWPF
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

                        case 0: table.res1 = 1; table.res2 = 1; table.res3 = 0; break;
                        case 1: table.res1 = 1; table.res2 = 0; table.res3 = 1; break;
                        case 2: table.res1 = 0; table.res2 = 1; table.res3 = 1; break;

                    }
                    logger.log($"Agent provided resources: {table.onTable[0]} {table.onTable[1]} {table.onTable[2]}");
                }
            }
        }
    }
}
