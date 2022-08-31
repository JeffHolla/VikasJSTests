using NUnit.Framework;
using System.IO;
using System.Diagnostics;
using System;
using CliWrap;
using System.Text;
using System.Threading.Tasks;
using CliWrap.Buffered;

namespace VikasJSTests
{
    public class Tests
    {
        private string cmdResult;
        private Command cmd;

        private string nodePath = "\"C:\\Program Files\\nodejs\\node.exe\"";
        private string fileExec;

        [SetUp]
        public async Task Setup()
        {
            string fileName = "VikasTests.js";
            string path = @"C:\Users\Aleksandr_Goriachkin\Desktop\VikasTestsFolder\test";
            fileExec = $"{path}\\{fileName}";
        }

        [TestCase(arguments: new int[] { 1, 5, 2 })]
        [TestCase(arguments: new int[] { 1, -1, 5, 2 })]
        [TestCase(arguments: new int[] { 1, 5, 2 })]
        public async Task MinMaxTests_Easy(int[] array)
        {
            var result = await Cli.Wrap(nodePath)
                .WithArguments(args => args
                    .Add(fileExec)
                    .Add(array.GetStringArray()))
                .ExecuteBufferedAsync();

            var outPut = result.StandardOutput.Replace("\n","").Replace("\r", "").Trim();

            Assert.AreEqual(array.GetStringArray(), outPut);
        }
    }

    public static class ArrayExtensions
    {
        public static string GetStringArray(this int[] arr)
        {
            return string.Join(" ", arr);
        }
    }
}