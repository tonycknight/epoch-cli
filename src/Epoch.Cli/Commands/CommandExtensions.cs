using System.Diagnostics;
using McMaster.Extensions.CommandLineUtils;
using Tk.Extensions;
using Tk.Nuget;

namespace Epoch.Cli.Commands
{
    internal static class CommandExtensions
    {
        [DebuggerStepThrough]
        public static int ToReturnCode(this bool value) => value ? 0 : 1;

        public static async Task<string> GetPackageInfoAsync(this CommandLineApplication app)
        {
            var currentVersion = ProgramBootstrap.GetAppVersion();
            var descLines = new List<string>()
            {
                Crayon.Output.Bright.Cyan(app.Parent?.Name!),
                Crayon.Output.Bright.Yellow($"Version {currentVersion} beta"),
                Crayon.Output.Bright.Yellow($"Repo: https://github.com/tonycknight/epoch-cli"),
            };

            if (currentVersion != null)
            {
                var nugetVersion = await (new NugetClient()).GetUpgradeVersionAsync("epoch-cli", currentVersion);
                if (nugetVersion != null)
                {
                    descLines.Add(Crayon.Output.Bright.Magenta($"An upgrade is available: {nugetVersion}"));
                }
            }
            var desc = descLines.Join(Environment.NewLine);

            return desc;
        }
    }
}