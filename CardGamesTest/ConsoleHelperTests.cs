using ConsoleLibrary;
using Xunit;

namespace CardGamesTest
{
    public class ConsoleHelperTests
    {
        [Theory]
        [InlineData("Question?", "Question?")]
        public void AskQuestionNoParams(string expected, string question)
        {
            TestConsole test = new TestConsole("");

            ConsoleHelper helper = new ConsoleHelper(test);

            helper.AskQuestion<int>(question);

            Assert.Equal(expected, test.Output[0]);
        }

        [Theory]
        [InlineData("Player 1", "Player {0}", 1)]
        public void AskQuestionIntValue(string expected, string question, int value)
        {
            TestConsole test = new TestConsole("");

            ConsoleHelper helper = new ConsoleHelper(test);

            helper.AskQuestion<int>(question, value);

            Assert.Equal(expected, test.Output[0]);
        }

    }
}
