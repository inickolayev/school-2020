using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TestGenerator;
using TestGenerator.Extensions;

namespace Anagramma.Generator
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
                    .AddNumbers(4, 3)
                    .AddStrings("stop")
                    .AddStrings("post")
                    .AddStrings("abcd")
                    .AddStrings("spot")
                    .BuildTest()
                .AddTest()
                    .AddNumbers(16, 1)
                    .AddStrings("iamlordvoldemort")
                    .AddStrings("tommarvoloriddle")
                    .BuildTest()
                .For(1, 18, (step, tsb) =>
                {
                    int len = 100;
                    int q = 10;
                    var source = GeneratorHelper.GenerateLowerString(len);
                    tsb = tsb.AddTest()
                        .AddNumbers(len, q)
                        .AddStrings(source)
                        .For(1, q, (i, tb) =>
                        {
                            return new Random().NextBool()
                                ? tb.GenerateString(len, GeneratorHelper.LOWER_CASE_ALPHABET)
                                : tb.AddStrings(GeneratorHelper.Shake(source));
                        })
                        .BuildTest();
                    Console.WriteLine($"Step {step} of {18}");
                    return tsb;
                })
                .BuildTestSet();
            return testSet;
        }
    }
}