using ConsoleLibrary;
using System;
using System.ComponentModel;
using Xunit;

namespace CardGames
{
    public class ConsoleHelperTests
    {
        [Fact]
        public void AskQuestionNoParams()
        {
            TestConsole test = new TestConsole();

            test.Input.Add("1");

            ConsoleHelper helper = new ConsoleHelper(test);

            helper.AskQuestionLine<int>("Question?");

            Assert.Equal(2, test.Output.Count);
            Assert.Equal("Question?", test.Output[0]);
        }

        [Theory]
        [InlineData("Player 1", "Player {0}", 1)]
        public void AskQuestionIntValue(string expected, string question, int value)
        {
            TestConsole test = new TestConsole();

            test.Input.Add("1");

            ConsoleHelper helper = new ConsoleHelper(test);

            helper.AskQuestionLine<int>(question, value);

            Assert.Equal(expected, test.Output[0]);
        }

        [Theory]
        [InlineData("2", 2)]
        [InlineData("3", 3)]
        public void AskQuestionOutputInt(string input, int expected)
        {
            TestConsole test = new TestConsole();

            test.Input.Add(input);

            ConsoleHelper helper = new ConsoleHelper(test);

            int actual = helper.AskQuestionLine<int>("Question?");

            Assert.Equal<int>(expected, actual);
        }


        [Theory]
        [InlineData("")]
        [InlineData("not a number")]
        [InlineData("4.0")]
        public void AskQuestionOutputNotInt(string input)
        {
            TestConsole test = new TestConsole();

            test.Input.Add(input);

            ConsoleHelper helper = new ConsoleHelper(test);

            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => helper.AskQuestionLine<int>("Question?"));

            Assert.Equal(5, test.Output.Count);
            Assert.Equal("Question?", test.Output[0]);
            Assert.Equal(String.Empty, test.Output[1]);
            Assert.IsType<TestConsoleClear>(test.Output[2]);
            Assert.Equal("Question?", test.Output[3]);
            Assert.Equal(String.Empty, test.Output[4]);
        }

        [Fact]
        public void AskQuestionNeverInt()
        {
            TestConsole test = new TestConsole();

            for (int i = 0; i < 101; i++)
            {
                test.Input.Add("not a number");
            }            

            ConsoleHelper helper = new ConsoleHelper(test);

            Exception ex = Assert.Throws<Exception>(() => helper.AskQuestionLine<int>("Question?"));

            Assert.Equal("Possible infinite loop encountered.", ex.Message);
        }

        [Fact]
        public void Clear()
        {
            TestConsole test = new TestConsole();

            ConsoleHelper helper = new ConsoleHelper(test);

            helper.Clear();

            Assert.IsType<TestConsoleClear>(test.Output[1]);
        }

        [Theory]
        [InlineData(' ', ConsoleKey.Spacebar, false, "Press Spacebar: ", "Press Spacebar:  ")]
        [InlineData('a', ConsoleKey.A, false, "Press A: ", "Press A: A")]
        [InlineData('A', ConsoleKey.A, true, "Press A: ", "Press A: A")]
        public void AskQuestionKey(char infoChar, ConsoleKey infoKey, bool infoShift, string question, string expected)
        {
            TestConsole test = new TestConsole();
            test.Input.Add(new ConsoleKeyInfo(infoChar, infoKey, infoShift, false, false));

            ConsoleHelper helper = new ConsoleHelper(test);
            ConsoleKey actualKey = helper.AskQuestionKey(question);

            Assert.Equal(2, test.Output.Count);
            Assert.Equal<ConsoleKey>(infoKey, actualKey);
            Assert.Equal(expected, test.Output[0]);
            Assert.Equal(String.Empty, test.Output[1]);
        }
    }
}
