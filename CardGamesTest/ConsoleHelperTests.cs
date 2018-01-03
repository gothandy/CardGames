﻿using ConsoleLibrary;
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

            helper.AskQuestion<int>("Question?");

            Assert.Single(test.Output);
            Assert.Equal("Question?", test.Output[0]);
        }

        [Theory]
        [InlineData("Player 1", "Player {0}", 1)]
        public void AskQuestionIntValue(string expected, string question, int value)
        {
            TestConsole test = new TestConsole();

            test.Input.Add("1");

            ConsoleHelper helper = new ConsoleHelper(test);

            helper.AskQuestion<int>(question, value);

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

            int actual = helper.AskQuestion<int>("Question?");

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

            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => helper.AskQuestion<int>("Question?"));

            Assert.Equal(3, test.Output.Count);
            Assert.Equal("Question?", test.Output[0]);
            Assert.IsType<TestConsoleClear>(test.Output[1]);
            Assert.Equal("Question?", test.Output[2]);
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

            Exception ex = Assert.Throws<Exception>(() => helper.AskQuestion<int>("Question?"));

            Assert.Equal("Possible infinite loop encountered.", ex.Message);
        }

    }
}