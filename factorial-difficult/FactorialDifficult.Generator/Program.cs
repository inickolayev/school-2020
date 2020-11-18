using System;
using System.Collections.Generic;
using System.IO;
using TestGenerator;
using TestGenerator.Extensions;

namespace FactorialDifficult.Generator
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
                // Тесты из условий
                .AddTest()
                    .AddNumbers(10, 5)
                    .BuildTest()
                .AddTest()
                    .AddNumbers(3, 2)
                    .BuildTest()
                // краевые случаи
                // k < 5
                .AddTest()
                    .AddNumbers(4, 3)
                    .BuildTest()
                .AddTest()
                    .AddNumbers(8, 3)
                    .BuildTest()
                .AddTest()
                    .AddNumbers(12, 3)
                    .BuildTest()
                // k >= 5 && k < 10
                .AddTest()
                    .AddNumbers(6, 5)
                    .BuildTest()
                .AddTest()
                    .AddNumbers(8, 6)
                    .BuildTest()
                .AddTest()
                    .AddNumbers(12, 6)
                    .BuildTest()
                // k >= 10
                .AddTest()
                    .AddNumbers(30, 10)
                    .BuildTest()
                .AddTest()
                    .AddNumbers(30, 15)
                    .BuildTest()
                .For(1, 10, (step, tsb) =>
                {
                    tsb.AddTest(t =>
                    {
                        var n = new Random().NextLong(1, FIRST_LIM);
                        var k = new Random().NextLong(1, n);
                        return t.AddNumbers(n, k);
                    })
                    .BuildTest();
                    Console.WriteLine($"Step {step} of {10}");
                    return tsb;
                })
                .AddTest()
                    .AddNumbers(SECOND_LIM, SECOND_LIM / 2)
                    .BuildTest()
                .For(1, 19, (step, tsb) =>
                {
                    tsb.AddTest(t =>
                    {
                        long n = new Random().NextLong(FIRST_LIM, SECOND_LIM);
                        long k = new Random().NextLong(1, n);
                        return t.AddNumbers(n, k);
                    })
                    .BuildTest();
                    Console.WriteLine($"Step {step} of {20}");
                    return tsb;
                })
                .AddTest()
                    .AddNumbers(THIRD_LIM, THIRD_LIM / 2)
                    .BuildTest()
                .For(1, 29, (step, tsb) =>
                {
                    tsb.AddTest(t =>
                    {
                        long n = new Random().NextLong(SECOND_LIM, THIRD_LIM);
                        long k = new Random().NextLong(1, n);
                        return t.AddNumbers(n, k);
                    })
                    .BuildTest();
                    Console.WriteLine($"Step {step} of {29}");
                    return tsb;
                })
                .AddTest()
                    .AddNumbers(LIM, LIM / 2)
                    .BuildTest()
                .For(1, 29, (step, tsb) =>
                {
                    tsb.AddTest(t =>
                    {
                        long n = new Random().NextLong(THIRD_LIM, LIM);
                        long k = new Random().NextLong(1, n);
                        return t.AddNumbers(n, k);
                    })
                    .BuildTest();
                    Console.WriteLine($"Step {step} of {29}");
                    return tsb;
                })
                .BuildTestSet();
            return testSet;
        }
    }
}
