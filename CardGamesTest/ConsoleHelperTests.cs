using ConsoleLibrary;
using System;
using System.ComponentModel;
using Xunit;

namespace CardGames
{
    public class ConsoleHelperTests
    {
        [Fact]
        public void AskQuestionNeverInt()
        {
            TestConsole test = new TestConsole("");

            ConsoleHelper helper = new ConsoleHelper(test);

            Exception ex = Assert.Throws<Exception>(() => helper.AskQuestion<int>("Question?"));

            Assert.Equal("Possible infinite loop encountered.", ex.Message);
        }
        
        [Fact]
        public void AskQuestionNoParams()
        {
            TestConsole test = new TestConsole("1");

            ConsoleHelper helper = new ConsoleHelper(test);

            helper.AskQuestion<int>("Question?");

            Assert.Equal("Question?", test.Output[0]);
        }

        [Theory]
        [InlineData("Player 1", "Player {0}", 1)]
        public void AskQuestionIntValue(string expected, string question, int value)
        {
            TestConsole test = new TestConsole("1");

            ConsoleHelper helper = new ConsoleHelper(test);

            helper.AskQuestion<int>(question, value);

            Assert.Equal(expected, test.Output[0]);
        }

        [Theory]
        [InlineData("2", 2)]
        [InlineData("3", 3)]
        [InlineData("4.0", 4)]
        public void AskQuestionOutputCorrect(string input, int expected)
        {
            TestConsole test = new TestConsole(input);

            ConsoleHelper helper = new ConsoleHelper(test);

            int actual = helper.AskQuestion<int>("Question?");

            Assert.Equal<int>(expected, actual);
        }

    }
}
