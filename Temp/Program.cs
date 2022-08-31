using CliWrap;
using CliWrap.Buffered;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Temp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var nodePath = "\"C:\\Program Files\\nodejs\\node.exe\"";

            string fileName = "VikasTests.js";
            string path = @"C:\Users\Aleksandr_Goriachkin\Desktop\VikasTestsFolder\test";
            string fileExec = $"{path}\\{fileName}";

            string execCMD = $"/K node {path}\\{fileName}";

         
            var result = await Cli.Wrap(nodePath)
                .WithArguments(args => args
                    .Add(@$"C:\Users\Aleksandr_Goriachkin\Desktop\VikasTestsFolder\test\VikasTests.js")
                    .Add("1 5 2"))
                .WithValidation(CommandResultValidation.ZeroExitCode)
                .ExecuteBufferedAsync();

            var res = result.StandardOutput;
            Console.WriteLine(res);
        }
    }
}
