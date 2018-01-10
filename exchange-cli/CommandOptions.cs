namespace exchange_cli
{
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    using CommandLine;
    using CommandLine.Text;

    public class CommandOptions
    {
        [Option('b', "base", Required = true, HelpText = "Base currency")]
        public string Base { get; set; }

        [Option('t', "base", Required = true, HelpText = "Target currency")]
        public string Target { get; set; }

        [Option('a', "amount", Required = false, DefaultValue = 1, HelpText = "Amount of money you want to exchange")]
        public double Amount { get; set; }

        [HelpOption]
        public string GetHelp()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(HelpText.AutoBuild(this));

            var currencies = "\n" + string.Join(
                                 ", ",
                                 new[]
                                     {
                                         "AUD", "BGN", "BRL", "CAD", "CHF", "CNY", "CZK", "DKK", "GBP", "HKD", "HRK",
                                         "HUF", "IDR", "\nILS", "INR", "JPY", "KRW", "MXN", "MYR", "NOK", "NZD",
                                         "PHP", "PLN", "RON", "RUB", "SEK", "\nSGD", "THB", "TRY", "USD", "ZAR"
                                     });
            stringBuilder.Append($"Available currencies are: {currencies}");
            stringBuilder.Append("\n");
            return stringBuilder.ToString();
        }
    }
}