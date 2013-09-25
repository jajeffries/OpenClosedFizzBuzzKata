using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Test_can_print_fizz_instead_of_three()
        {
            var fizzBuzzer = FizzBuzzFactory.Create();
            var actual = fizzBuzzer.Output(3);
            Assert.AreEqual("1", actual[0]);
            Assert.AreEqual("2", actual[1]);
            Assert.AreEqual("Fizz", actual[2]);
        }

        [TestMethod]
        public void Test_can_print_buzz_instead_of_five()
        {
            var fizzBuzzer = FizzBuzzFactory.Create();
            var actual = fizzBuzzer.Output(5);
            Assert.AreEqual("Buzz", actual[4]);
        }

        [TestMethod]
        public void Test_can_print_fizzbuzz_instead_of_15()
        {
            var fizzBuzzer = FizzBuzzFactory.Create();
            var actual = fizzBuzzer.Output(15);
            Assert.AreEqual("FizzBuzz", actual[14]);
        }
    }

    public class FizzBuzzFactory
    {
        public static FizzBuzzer Create()
        {
            return new FizzBuzzer(n =>
                {
                    if (n%3 == 0 && n%5 == 0)
                    {
                        return "FizzBuzz";
                    }
                    else if (n%3 == 0)
                    {
                        return "Fizz";
                    }
                    else if (n%5 == 0)
                    {
                        return "Buzz";
                    }
                    else
                    {
                        return n.ToString();
                    }
                });
        }
    }

    public class FizzBuzzer
    {
        private Func<int, string> _converter;

        public FizzBuzzer(Func<int, string> converter)
        {
            _converter = converter;
        }


        public List<string> Output(int n)
        {
            var output = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                output.Add(_converter(i));
            }
            return output;
        }
    }
}
