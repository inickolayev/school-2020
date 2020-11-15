using System;
using System.Collections.Generic;
using System.IO;
using TestGenerator;

namespace Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
        }
        
        public void Run()
        {

            Directory.CreateDirectory("tests");
            testSet.WriteToFiles((t, ind) => $"tests/test_{ind}.txt");
        }

        public TestSet SimpleTestSetGenerate()
        {
            var N_LIM = 1_000_000;
            var Q_LIM = 1_000_000;
            var N_LIM_MIN = 1_00_000;
            var Q_LIM_MIN = 5_00_000;
            var DIFF = 250_000;
            var A_LIM = 1_000_000_000_000;
            int testCount = 40;
            int simpleALIM = 1000;
            int simpleNLIM = 1000;
            int simpleQLIM = 1000;
            var testSet = new TestSetBuilder()
                .For(1, testCount, (step, tsb) =>
                {
                    tsb.AddTest()
                        .AddNumbers(simpleNLIM, simpleQLIM)
                        .GenerateNumbers(simpleNLIM, 1, simpleALIM)
                        .For(1, simpleQLIM, (ind, testBuilder) => testBuilder
                            .GenerateNumber(1, simpleALIM)
                        )
                        .BuildTest();
                    Console.WriteLine($"Step {step} of {testCount}");
                    return tsb;
                })
                .BuildTestSet();
            return testSet;
        }

        public TestSet BitTestSetInitGenerate()
        {
            var DIFF = 250_000;
            var A_LIM = 1_000_000_000_000;
            int bigTestCount = 4;
            var bigTestSet = new TestSetBuilder()
                .For(1, 4, (step_n, tsb) =>
                {
                    tsb.For(1, 4, (step_q, tsb) =>
                    {
                        int n = DIFF * step_n, q = DIFF * step_q;
                        tsb.AddTest()
                            .AddNumbers(n, q)
                            .GenerateNumbers(n, 1, A_LIM)
                            .For(1, q, (ind, testBuilder) => testBuilder
                                .GenerateNumber(1, A_LIM)
                            )
                            .BuildTest();
                        Console.WriteLine($"Substep {step_q} of {bigTestCount}");
                        return tsb;
                    });
                    Console.WriteLine($"Step {step_n} of {bigTestCount}");
                    return tsb;
                })
                .BuildTestSet();

            Directory.CreateDirectory("bigTests");
            bigTestSet.WriteToFiles((t, ind) => $"bigTests/big_test_{ind}.txt");
            return bigTestSet;
        }

        public TestSet BitTestSetInitGenerate()
        {
            var N_LIM_MIN = 1_00_000;
            var Q_LIM_MIN = 5_00_000;
            var A_LIM = 1_000_000_000_000;
            var bigTestSetInit = new TestSetBuilder()
                .AddTest()
                    .AddNumbers(N_LIM_MIN, Q_LIM_MIN)
                    .GenerateNumbers(N_LIM_MIN, 1, A_LIM)
                    .For(1, Q_LIM_MIN, (ind, testBuilder) => testBuilder
                        .GenerateNumber(1, A_LIM)
                    )
                    .BuildTest()
                .BuildTestSet();
            return bigTestSetInit;
        }
    }
}
