using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestGenerator;
using TestGenerator.Extensions;

namespace Circle.Generator
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
            int FIRST_LIM = 100;
            int SECOND_LIM = 1000;
            int VALUE_LIM = 100_000_000;
            var testSet = new TestSetBuilder()
                // Тесты для условия
                .AddTest()
                    .AddNumbers(1)
                    .AddNumbers(5)
                    .AddNumbers(1, 2, 3, 4, 5)
                    .BuildTest()
                .AddTest()
                    .AddNumbers(2)
                    .AddNumbers(3)
                    .AddNumbers(1, 1, 1)
                    .AddNumbers(4)
                    .AddNumbers(1, 0, 0, 0)
                    .BuildTest()
                // Краевые случаи на малых значениях
                .AddTest()
                    .AddNumbers(1)
                    .AddNumbers(3)
                    .AddNumbers(1, 0, 1)
                    .BuildTest()
                .AddTest()
                    .AddNumbers(1)
                    .AddNumbers(4)
                    .AddNumbers(1, 0, 0, 1)
                    .BuildTest()
                .AddTest()
                    .AddNumbers(1)
                    .AddNumbers(3)
                    .AddNumbers(1, 1, 0)
                    .BuildTest()
                .AddTest()
                    .AddNumbers(1)
                    .AddNumbers(4)
                    .AddNumbers(0, 0, 0, 4)
                    .BuildTest()
                // Тесты, общим размером до 10 * 100
                .For(1, 14, (step, tsb) =>
                {
                    var cnt = 10;
                    tsb.AddTest()
                        .AddNumbers(cnt)
                        .For(1, cnt, (q, test) => {
                            var circleCount = new Random().Next(2, FIRST_LIM);
                            return test
                                .AddNumbers(circleCount)
                                .AddNumbers(Enumerable.Range(1, circleCount)
                                    .Select(i => new Random().NextBool()
                                        ? new Random().Next(0, circleCount)
                                        : new Random().Next(0, 3))
                                    .ToArray()
                                );
                        })
                        .BuildTest();
                    Console.WriteLine($"Step {step} of {18}");
                    return tsb;
                })
                // Тесты, общим размером до 10 * 100
                .For(1, 30, (step, tsb) =>
                {
                    var cnt = 100;
                    tsb.AddTest()
                        .AddNumbers(cnt)
                        .For(1, cnt, (q, test) => {
                            var circleCount = new Random().Next(2, SECOND_LIM);
                            return test
                                .AddNumbers(circleCount)
                                .AddNumbers(Enumerable.Range(1, circleCount)
                                    .Select(i => new Random().NextBool()
                                        ? new Random().Next(0, circleCount)
                                        : new Random().Next(0, 10))
                                    .ToArray()
                                );
                        })
                        .BuildTest();
                    Console.WriteLine($"Step {step} of {30}");
                    return tsb;
                })
                // Большой тест 100 * 1000
                .AddTest()
                    .AddNumbers(100)
                    .For(1, 100, (q, test) => {
                        var circleCount = 1000;
                        var t = test
                            .AddNumbers(circleCount)
                            .AddNumbers(Enumerable.Range(1, circleCount)
                                .Select(i => new Random().NextBool()
                                    ? new Random().Next(0, circleCount)
                                    : new Random().Next(0, 10))
                                .ToArray()
                            );
                        Console.WriteLine($"Big test step 100 * 1000");
                        return t;
                    })
                    .BuildTest()
                // Большой тест 10 * 10'000
                .AddTest()
                    .AddNumbers(10)
                    .For(1, 10, (q, test) => {
                        var circleCount = 10_000;
                        var t = test
                            .AddNumbers(circleCount)
                            .AddNumbers(Enumerable.Range(1, circleCount)
                                .Select(i => new Random().NextBool()
                                    ? new Random().Next(0, circleCount)
                                    : new Random().Next(0, 10))
                                .ToArray()
                            );
                        Console.WriteLine($"Big test step 10 * 10'000");
                        return t;
                    })
                    .BuildTest()
                // Большой тест 1 * 100'000
                .AddTest()
                    .AddNumbers(1)
                    .For(1, 1, (q, test) => {
                        var circleCount = 100_000;
                        var t = test
                            .AddNumbers(circleCount)
                            .AddNumbers(Enumerable.Range(1, circleCount)
                                .Select(i => new Random().NextBool()
                                    ? new Random().Next(0, circleCount)
                                    : new Random().Next(0, 10))
                                .ToArray()
                            );
                        Console.WriteLine($"Big test step 1 * 100'000");
                        return t;
                    })
                    .BuildTest()
                // Большой тест 1 * 100'000 c максимальными ограничениями
                .AddTest()
                    .AddNumbers(1)
                    .For(1, 1, (q, test) => {
                        var circleCount = 100_000;
                        var t = test
                            .AddNumbers(circleCount)
                            .AddNumbers(Enumerable.Range(1, circleCount)
                                .Select(i => new Random().NextBool()
                                    ? VALUE_LIM
                                    : new Random().Next(0, 10))
                                .ToArray()
                            );
                        Console.WriteLine($"Big test step 1 * 100'000");
                        return t;
                    })
                    .BuildTest()
                // Тесты, размером до 100 * 1000
                .For(1, 46, (step, tsb) =>
                {
                    var cnt = 100;
                    tsb.AddTest()
                        .AddNumbers(cnt)
                        .For(1, cnt, (q, test) => {
                            var circleCount = new Random().Next(2, 1000);
                            return test
                                .AddNumbers(circleCount)
                                .AddNumbers(Enumerable.Range(1, circleCount)
                                    .Select(i => new Random().NextBool()
                                        ? new Random().Next(0, circleCount)
                                        : new Random().Next(0, 10))
                                    .ToArray()
                                );
                        })
                        .BuildTest();
                    Console.WriteLine($"Step {step} of {46}");
                    return tsb;
                })
                .BuildTestSet();
            return testSet;
        }
    }
}