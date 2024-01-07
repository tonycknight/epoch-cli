using McMaster.Extensions.CommandLineUtils;
using Epoch.Cli.Commands;
using Tk.Extensions;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using McMaster.Extensions.CommandLineUtils.HelpText;

namespace Epoch.Cli
{
    [ExcludeFromCodeCoverage]
    [Command(Name = "epoch", Description = "Epoch date tools")]
    public class Program
    {
        public static int Main(string[] args)
        {
            using var app = new CommandLineApplication<EpochCommand>()
            {
                UnrecognizedArgumentHandling = UnrecognizedArgumentHandling.Throw,
                MakeSuggestionsInErrorMessage = true,
            };

            app.Conventions
                .UseDefaultConventions()
                .UseConstructorInjection(ProgramBootstrap.CreateServiceCollection());
            app.ExtendedHelpText = app.GetPackageInfo();
            
            try
            {
                return app.Execute(args);
            }
            catch (UnrecognizedCommandParsingException ex)
            {
                Console.WriteLine(Crayon.Output.Bright.Red(ex.Message));
                var possibleMatches = ex.NearestMatches.Select(m => $"{app.Name} {m}").Join(Environment.NewLine);
                if (possibleMatches.Length > 0)
                {
                    Console.WriteLine(Crayon.Output.Bright.Yellow($"Did you mean one of these commands?{Environment.NewLine}{possibleMatches}"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(Crayon.Output.Bright.Red(ex.Message));
            }
            return false.ToReturnCode();
        }
    }
}