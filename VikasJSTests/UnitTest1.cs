using NUnit.Framework;
using System.IO;
using System.Diagnostics;
using System;

namespace VikasJSTests
{
    public class Tests
    {
        private string cmdResult;

        [SetUp]
        public void Setup()
        {
            string fileName = "VikasTests.js";
            string path = @"C:\Users\Aleksandr_Goriachkin\Desktop\VikasTestsFolder\test";
            string execCMD = $"/C node {path}/{fileName}";

            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.Arguments = execCMD;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.WaitForExit();
            
            cmdResult = cmd.StandardOutput.ReadToEnd();
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual("Hi", cmdResult);
            //Assert.AreEqual("1 2 3 4 5 6 7", cmdResult);
            //Assert.AreEqual("1 2 3 4 5 6 7", cmdResult);
        }
    }
}