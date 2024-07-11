using ConsoleApp2;

namespace UnitTests
{
    public class TableUnitTests
    {
        [Fact]
        public void CanCreateTableWithoutParameters()
        {
            // definitions
            var table = new Table();

            // execution
            // no block

            // checking
            Assert.NotNull(table);
        }

        [Fact]
        public void CanSetIsSomeoneSmokingToTrue()
        {
            // definitions
            var table = new Table();

            // execution
            table.isSomeoneSmoking = true;

            // checking
            Assert.Equal(table.isSomeoneSmoking, true);
        }

        [Fact]
        public void CanSetIsSomeoneSmokingToFalse()
        {
            // definitions
            var table = new Table();

            // execution
            table.isSomeoneSmoking = false;

            // checking
            Assert.Equal(table.isSomeoneSmoking, false);
        }
    }
}