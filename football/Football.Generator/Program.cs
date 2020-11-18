using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TestGenerator;
using TestGenerator.Extensions;

namespace Football.Generator
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
            var testSet = new TestSetBuilder()
                // Тесты для условия
                .AddTest()
                    .AddNumbers(22)
                    .BuildTest()
                .AddTest()
                    .AddNumbers(23)
                    .BuildTest()
                .For(1, 8, (step, tsb) =>
                {
                    int lim = 40;
                    tsb = tsb.AddTest()
                        .GenerateNumber(22, lim)
                        .BuildTest();
                    Console.WriteLine($"Step {step} of {18}");
                    return tsb;
                })
                .For(1, 10, (step, tsb) =>
                {
                    tsb = tsb.AddTest()
                        .GenerateNumber(40, 100)
                        .BuildTest();
                    Console.WriteLine($"Step {step} of {18}");
                    return tsb;
                })
                .AddTest()
                    .AddNumbers(1000)
                    .BuildTest()
                .For(1, 19, (step, tsb) =>
                {
                    tsb = tsb.AddTest()
                        .GenerateNumber(100, 1000)
                        .BuildTest();
                    Console.WriteLine($"Step {step} of {19}");
                    return tsb;
                })
                .AddTest()
                    .AddNumbers(10_000)
                    .BuildTest()
                .For(1, 19, (step, tsb) =>
                {
                    tsb = tsb.AddTest()
                        .GenerateNumber(1000, 10_000)
                        .BuildTest();
                    Console.WriteLine($"Step {step} of {19}");
                    return tsb;
                })
                .AddTest()
                    .AddNumbers(100_000)
                    .BuildTest()
                .For(1, 19, (step, tsb) =>
                {
                    tsb = tsb.AddTest()
                        .GenerateNumber(10_000, 100_000)
                        .BuildTest();
                    Console.WriteLine($"Step {step} of {19}");
                    return tsb;
                })
                .AddTest()
                    .AddNumbers(1000_000)
                    .BuildTest()
                .For(1, 19, (step, tsb) =>
                {
                    int lim = 1000_000;
                    tsb = tsb.AddTest()
                        .GenerateNumber(100_000, 1000_000)
                        .BuildTest();
                    Console.WriteLine($"Step {step} of {19}");
                    return tsb;
                })
                .BuildTestSet();
            return testSet;
        }
    }
}