using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Envio
{
    class Program
    {
        private static async Task Main()
        {
            Console.Title = "Envio";

            var configuracaoEndpoint = new EndpointConfiguration("Envio");

            var transporte = configuracaoEndpoint.UseTransport<LearningTransport>();

            var instanciaEndpoint = await Endpoint.Start(configuracaoEndpoint).ConfigureAwait(false);

            Console.WriteLine("Aperte Enter para sair.");
            Console.ReadLine();

            await instanciaEndpoint.Stop().ConfigureAwait(false);
        }
    }
}
