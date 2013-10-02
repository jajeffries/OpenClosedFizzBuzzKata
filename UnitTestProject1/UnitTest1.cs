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

        [TestMethod]
        public void Test_we_can_print_1()
        {
            var fizzBuzzer = FizzBuzzFactory.Create();
            var actual = fizzBuzzer.Output(1);
            Assert.AreEqual("1", actual[0]);
        }

        [TestMethod]
        public void Test_FizzBarBuzz_is_printed_for_30()
        {
            var fizzBuzzer = FizzBuzzFactory.Create();
            var actual = fizzBuzzer.Output(30);
            Assert.AreEqual("FizzBarBuzz", actual[29]);
        }

        [TestMethod]
        public void Test_A_is_printed_for_1()
        {
            var fizzBuzzer = FizzBuzzFactory.Create();
            var actual = fizzBuzzer.Output(0);
            Assert.AreEqual("A", actual[0]);
        }
    }

    public static class FizzBuzzFactory
    {
        public static FizzBuzzer Create()
        {
            return new FizzBuzzer(new FizzBarBuzzStrategy());
        }
    }

    //public static class OldFizzBuzzFactory
    //{
    //    public static FizzBuzzer Create()
    //    {
    //        return new FizzBuzzer(n =>
    //            {
    //                if (n%3 == 0 && n%5 == 0)
    //                {
    //                    return "FizzBuzz";
    //                }
    //                else if (n%3 == 0)
    //                {
    //                    return "Fizz";
    //                }
    //                else if (n%5 == 0)
    //                {
    //                    return "Buzz";
    //                }
    //                else
    //                {
    //                    return n.ToString();
    //                }
    //            });
    //    }
    //}

    public class DefaultStrategy
    {
        public virtual string Count(int n)
        {
            return n.ToString();
        }
    }

    public class FizzStrategy : DefaultStrategy
    {
        public override string Count(int n)
        {
            if (n%3 == 0)
            {
                return "Fizz";
            }
            else
            {
                return base.Count(n);
            }
        }
    }

    public class BuzzStrategy : FizzStrategy
    {
        public override string Count(int n)
        {
            if (n%5 == 0)
            {
                return "Buzz";
            }
            else
            {
                return base.Count(n);
            }
        }
    }

    public class FizzBuzzStrategy : BuzzStrategy
    {
        public override string Count(int n)
        {
            if (n%5 == 0 && n%3 == 0)
            {
                return "FizzBuzz";
            }
            else
            {
                return base.Count(n);
            }
        }
    }

    public class FizzBarBuzzStrategy : FizzBuzzStrategy
    {
        public override string Count(int n)
        {
            if (n%5 == 0 && n.ToString().Contains("3"))
            {
                return "FizzBarBuzz";
            }
            else
            {
                return base.Count(n);
            }
        }
    }

    public class FizzBuzzer
    {
        private DefaultStrategy _strategy;

        public FizzBuzzer(DefaultStrategy strategy)
        {
            _strategy = strategy;
        }


        public List<string> Output(int n)
        {
            var output = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                var nextCount = _strategy.Count(i);
                output.Add(nextCount);
            }
            return output;
        }
    }
}
