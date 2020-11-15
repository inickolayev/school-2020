using System;
using System.Collections.Generic;
using System.IO;
using TestGenerator;

namespace Factorial.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
        }

        public void Run()
        {
            var path = "tests";
            Directory.CreateDirectory(path);
            var testSet = GenerateTests();
            testSet.WriteToFiles((t, ind) => $"{path}/test_{ind}.txt");
        }

        public TestSet GenerateTests()
        {
            long FIRST_LIM = 15;
            long SECOND_LIM = 1000_000;
            long THIRD_LIM = 1000_000_000_000_000;
            long LIM = 1000_000_000_000_000_000;
            var testSet = new TestSetBuilder()
                .AddTest()
                    .AddNumbers(1)
                    .BuildTest()
                .AddTest()
                    .AddNumbers(2)
                    .BuildTest()
                .AddTest()
                    .AddNumbers(3)
                    .BuildTest()
                .For(1, 7, (step, tsb) =>
                {
                    tsb.AddTest()
                        .GenerateNumber(4, FIRST_LIM)
                        .BuildTest();
                    Console.WriteLine($"Step {step} of {7}");
                    return tsb;
                })
                .For(1, 20, (step, tsb) =>
                {
                    tsb.AddTest()
                        .GenerateNumber(FIRST_LIM, SECOND_LIM)
                        .BuildTest();
                    Console.WriteLine($"Step {step} of {20}");
                    return tsb;
                })
                .AddTest()
                    .AddNumbers(LIM)
                    .BuildTest()
                .For(1, 29, (step, tsb) =>
                {
                    tsb.AddTest()
                        .GenerateNumber(SECOND_LIM, THIRD_LIM)
                        .BuildTest();
                    Console.WriteLine($"Step {step} of {29}");
                    return tsb;
                })
                .For(1, 40, (step, tsb) =>
                {
                    tsb.AddTest()
                        .GenerateNumber(THIRD_LIM, LIM)
                        .BuildTest();
                    Console.WriteLine($"Step {step} of {40}");
                    return tsb;
                })
                .BuildTestSet();
            return testSet;
        }
    }
}
