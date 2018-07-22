using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NrsLib.SequentiallyJsonDataLoader;

namespace UnitTestProject {
    [TestClass]
    public class JsonsLoaderTest {
        private string testSourceFileDirectoryFullPath;

        [TestInitialize]
        public void TestInitialize() {
            testSourceFileDirectoryFullPath = Path.Combine(Environment.CurrentDirectory, "TestFile");
        }


        [TestMethod]
        public void TestDefaultLoad() {
            var generator = new JsonsLoader(testSourceFileDirectoryFullPath);
            var instance1 = generator.Generate<TestClass>();
            Assert.IsTrue(instance1.TestData == 1);
            var instance2 = generator.Generate<TestClass>();
            Assert.IsTrue(instance2.TestData == 2);
        }

        [TestMethod]
        public void TestAppendsSuffix()
        {
            var generator = new JsonsLoader(testSourceFileDirectoryFullPath);
            generator.Setting.ChangeFileSuffix("Suffix");
            var instance1 = generator.Generate<TestClass>();
            Assert.IsTrue(instance1.TestData == 3);
            var instance2 = generator.Generate<TestClass>();
            Assert.IsTrue(instance2.TestData == 4);
        }
    }
}
