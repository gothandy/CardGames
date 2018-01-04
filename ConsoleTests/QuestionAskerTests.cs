using ConsoleLibrary;
using System;
using System.Collections.Generic;
using Xunit;

namespace CardGames
{
    public class QuestionAskerTests
    {
        [Fact]
        public void AskQuestionNoParams()
        {
            TestConsole test = new TestConsole();

            test.Input.Add("1");

            QuestionAsker helper = new QuestionAsker(test);

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

            QuestionAsker helper = new QuestionAsker(test);

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

            QuestionAsker helper = new QuestionAsker(test);

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

            QuestionAsker helper = new QuestionAsker(test);

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

            QuestionAsker helper = new QuestionAsker(test);

            Exception ex = Assert.Throws<Exception>(() => helper.AskQuestionLine<int>("Question?"));

            Assert.Equal("Possible infinite loop encountered.", ex.Message);
        }

        [Theory]
        [InlineData(' ', ConsoleKey.Spacebar, false, "Press Spacebar: ", "Press Spacebar:  ")]
        [InlineData('a', ConsoleKey.A, false, "Press A: ", "Press A: A")]
        [InlineData('A', ConsoleKey.A, true, "Press A: ", "Press A: A")]
        public void AskQuestionKey(char infoChar, ConsoleKey infoKey, bool infoShift, string question, string expected)
        {
            TestConsole test = new TestConsole();
            test.Input.Add(new ConsoleKeyInfo(infoChar, infoKey, infoShift, false, false));

            QuestionAsker helper = new QuestionAsker(test);
            ConsoleKey actualKey = helper.AskQuestionKey(question);

            Assert.Equal(2, test.Output.Count);
            Assert.Equal<ConsoleKey>(infoKey, actualKey);
            Assert.Equal(expected, test.Output[0]);
            Assert.Equal(String.Empty, test.Output[1]);
        }

        [Fact]
        public void CaptureKeyPress()
        {
            TestConsole test = new TestConsole();
            test.Input.Add(new ConsoleKeyInfo('a', ConsoleKey.A, false, false, false));
            test.Input.Add(new ConsoleKeyInfo('b', ConsoleKey.B, false, false, false));
            test.Input.Add(new ConsoleKeyInfo('c', ConsoleKey.C, false, false, false));
            test.Input.Add(new ConsoleKeyInfo('d', ConsoleKey.D, false, false, false));
            test.Input.Add(new ConsoleKeyInfo('e', ConsoleKey.E, false, false, false));

            List<ConsoleKeyTime> keyTimeList = new List<ConsoleKeyTime>();

            QuestionAsker helper = new QuestionAsker(test);

            for (int i = 0; i < 5; i++)
            {
                keyTimeList.Add(helper.PressKeyTime());
            }

            Assert.NotEqual<TimeSpan>(new TimeSpan(0), keyTimeList[0].TimeSpan);
            Assert.NotEqual<TimeSpan>(new TimeSpan(0), keyTimeList[1].TimeSpan);
            Assert.NotEqual<TimeSpan>(new TimeSpan(0), keyTimeList[2].TimeSpan);
            Assert.NotEqual<TimeSpan>(new TimeSpan(0), keyTimeList[3].TimeSpan);
            Assert.NotEqual<TimeSpan>(new TimeSpan(0), keyTimeList[4].TimeSpan);

            Assert.Single(test.Output);
            Assert.Equal(String.Empty, test.Output[0]);
        }
    }
}
