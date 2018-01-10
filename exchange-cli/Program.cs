using System;

namespace exchange_cli
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    using CommandLine;

    public class Program
    {
        public static void Main(string[] args)
        {
            var options = new CommandOptions();
            var parserErrors = string.Empty;
            if (!CommandLine.Parser.Default.ParseArgumentsStrict(args, options))
            {
                return;
            }

            var @base = options.Base;
            var target = options.Target;
            var amount = options.Amount;

            var calculator = new Transaction(@base, target);

            var results = calculator.Exchange(amount).GetAwaiter().GetResult();

            Console.WriteLine($"{amount} {@base} = {results} {target} \nPress enter to continue...");
            Console.ReadLine();
        }
    }
}