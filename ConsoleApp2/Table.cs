namespace ConsoleApp2
{
    public class Table
    {
        public int[] onTable = { 0, 0, 0 };
        public Semaphore sem = new Semaphore(2, 4);
        public bool isSomeoneSmoking = false;
    }
}