using McMaster.Extensions.CommandLineUtils;
using Spectre.Console;
using Tk.Extensions;

namespace Epoch.Cli.Commands
{
    [Command("epoch", Description = "Convert an epoch to date/time and vice-versa")]
    internal class EpochCommand
    {
        private readonly IAnsiConsole _console;

        public EpochCommand(IAnsiConsole console)
        {
            _console = console;
        }

        [Argument(0, Description = "The number or date/time to convert, or `now`.", Name = "value")]
        public IList<string>? Values { get; set; }


        public int OnExecute(CommandLineApplication app)
        {
            try
            {
                var value = Values?.Join(" ")?.Trim();

                if (string.IsNullOrWhiteSpace(value))
                {
                    app.ShowHelp();
                    return false.ToReturnCode();
                }

                if (long.TryParse(value, out long value1))
                {
                    _console.WriteLine(DateTimeOffset.FromUnixTimeSeconds(value1).ToString("yyyy-MM-dd HH:mm:ss"));
                    return true.ToReturnCode();
                }

                if (DateTimeOffset.TryParse(value, out DateTimeOffset value2))
                {
                    _console.WriteLine(value2.ToUnixTimeSeconds().ToString());
                    return true.ToReturnCode();
                }

                if (StringComparer.InvariantCultureIgnoreCase.Equals(value, "now"))
                {
                    _console.WriteLine(DateTimeOffset.Now.ToUnixTimeSeconds().ToString());
                    return true.ToReturnCode();
                }

            }
            catch
            {
            }

            _console.Write(new Markup("[red]Invalid value.[/]"));
            return false.ToReturnCode();
        }
    }
}
