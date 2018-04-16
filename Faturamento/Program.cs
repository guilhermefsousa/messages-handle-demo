using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Faturamento
{
    class Program
    {
        private static async Task Main()
        {
            Console.Title = "Faturamento";

            var configuracaoEndpoint = new EndpointConfiguration("Faturamento");

            var transporte = configuracaoEndpoint.UseTransport<LearningTransport>();

            var instanciaEndpoint = await Endpoint.Start(configuracaoEndpoint).ConfigureAwait(false);

            Console.WriteLine("Aperte Enter para sair.");
            Console.ReadLine();

            await instanciaEndpoint.Stop().ConfigureAwait(false);
        }
    }
}
