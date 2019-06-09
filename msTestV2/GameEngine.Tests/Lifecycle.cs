using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GameEngine.Tests
{
    [TestClass]
    public class Lifecycle
    {
        static string SomeTestContext;

        //2º a executar
        [TestInitialize]
        public void LifecycleInit()
        {
            Console.WriteLine("TestInitialize Lifecycle");
        }

        //Executa depois de cada test
        [TestCleanup]
        public void LifecycleClean()
        {
            Console.WriteLine("TestCleanup Lifecycle");
        }

        //1º a executar
        [ClassInitialize]
        public void LifecycleClassInit(TestContext context)
        {
            Console.WriteLine("ClassInitialize Lifecycle");
            Console.WriteLine(" data loaded from disk or some expensive objective creation");
            SomeTestContext = "42";
        }

        //Executa após o último test
        [ClassCleanup]
        public void LifecycleClassClean(TestContext context)
        {
            Console.WriteLine("ClassCleanup Lifecycle");
        }

        public void TestA()
        {
            Console.WriteLine("Test A starting");
            Console.WriteLine($"Shared test context: {SomeTestContext}");
        }

        public void TestB()
        {
            Console.WriteLine("Test B starting");
            Console.WriteLine($"Shared test context: {SomeTestContext}");

        }
    }
}
