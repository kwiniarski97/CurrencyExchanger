namespace exchange_cli
{
    using System;
    using System.Reflection;
    using System.Threading.Tasks;

    using exchange_cli.JsonRespones;

    using Newtonsoft.Json;

    public class Transaction
    {
        public Transaction(string @base, string target)
        {
            this.Base = @base;
            this.Target = target;
        }

        public string Base { get; set; }

        public string Target { get; set; }

        public Latest Json { get; set; }

        public async Task<double> Exchange(double amount)
        {
            var json = await Api.GetCurrentRatesByBaseAsync(this.Base);

            var rate = this.GetTargetCurrencyRate(json.Rates, this.Target);

            return (double)rate * amount;
        }

        private object GetTargetCurrencyRate(object rates, string target)
        {
            return rates.GetType().GetProperty(target)?.GetValue(rates);
        }
    }
}