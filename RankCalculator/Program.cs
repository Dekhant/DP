using System.Threading.Tasks;
using Library;

namespace RankCalculator
{
    internal static class Program
    {
        private static async Task Main()
        {
            var calculator = new RankCalculator(new Storage());
            calculator.Run();
            await Task.Delay(-1);
        }
    }
}