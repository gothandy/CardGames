using CardGames;
using System;
using Xunit;

namespace CardGamesTest
{
    public class TestConsoleTests
    {
        [Fact]
        public void NoWrite()
        {
            TestConsole test = new TestConsole();

            Assert.Single(test.Output);
            Assert.Equal(string.Empty, test.Output[0]);
            Assert.Empty(test.Input);
        }

        [Fact]
        public void WriteOnce()
        {
            TestConsole test = new TestConsole();

            test.Write("Word");

            Assert.Single(test.Output);
        }

        [Fact]
        public void WriteTwice()
        {
            TestConsole test = new TestConsole();

            test.Write("Red");
            test.Write("Blue");

            Assert.Single(test.Output);
            Assert.Equal("RedBlue", test.Output[0]);
        }

        [Fact]
        public void WriteLineThenWrite()
        {
            TestConsole test = new TestConsole();

            test.WriteLine("Red");
            test.Write("Blue");

            Assert.Equal(2, test.Output.Count);
            Assert.Equal("Red", test.Output[0]);
            Assert.Equal("Blue", test.Output[1]);
        }

        [Fact]
        public void WriteThenClear()
        {
            TestConsole test = new TestConsole();

            test.Write("Red");
            test.Clear();

            Assert.Equal(3, test.Output.Count);
            Assert.Equal("Red", test.Output[0]);
            Assert.IsType<TestConsoleClear>(test.Output[1]);
            Assert.Equal(String.Empty, test.Output[2]);
        }

        [Fact]
        public void ReadKey()
        {
            TestConsole test = new TestConsole();

            test.Input.Add(new ConsoleKeyInfo('A', ConsoleKey.A, true, false, false));

            ConsoleKeyInfo keyInfo = test.ReadKey(false);

            Assert.Single(test.Output);
            Assert.Equal<ConsoleKey>(ConsoleKey.A, keyInfo.Key);
            Assert.Equal("A", test.Output[0]);
        }
    }
}
