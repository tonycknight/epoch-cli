using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace Epoch.Cli
{
    internal static class ProgramBootstrap
    {
        public static IServiceProvider CreateServiceCollection() =>
           new ServiceCollection()
                .AddSingleton<IAnsiConsole>(sp => AnsiConsole.Create(new AnsiConsoleSettings() { ColorSystem = ColorSystemSupport.TrueColor }))
                .BuildServiceProvider();

        public static string? GetAppVersion()
            => Assembly.GetExecutingAssembly()
                       .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
    }
}
