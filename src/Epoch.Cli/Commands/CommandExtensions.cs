using System.Diagnostics;
using McMaster.Extensions.CommandLineUtils;
using Tk.Extensions;

namespace Epoch.Cli.Commands
{
    internal static class CommandExtensions
    {
        [DebuggerStepThrough]
        public static int ToReturnCode(this bool value) => value ? 0 : 1;

        public static string GetPackageInfo(this CommandLineApplication app)
        {
            var currentVersion = ProgramBootstrap.GetAppVersion();
            var descLines = new List<string>()
            {
                Crayon.Output.Bright.Cyan(app.Parent?.Name!),
                Crayon.Output.Bright.Yellow($"Version {currentVersion} beta"),
                Crayon.Output.Bright.Yellow($"Repo: https://github.com/tonycknight/epoch-cli"),
            };

            return descLines.Join(Environment.NewLine);
        }
    }
}