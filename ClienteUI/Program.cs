using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Threading.Tasks;

namespace ClienteUI
{
    class Program
    {
        private static async Task Main()
        {
            Console.Title = "ClienteUI";

            //Definimos todas configurações que determinam como nosso terminal irá operar.
            //Aqui vai o nome do endpoint, serve como identidade lógica para o terminal.
            var configuracaoEndpoint = new EndpointConfiguration("ClienteUI");

            //Aqui definimos o transporte que o NServiceBus irá usar para enviar a receber mensagens.
            var transporte = configuracaoEndpoint.UseTransport<LearningTransport>();

            //Especificando o roteamento lógico para FazerPedido 
            //Comandos do tipo FazerPedido devem ser enviados para o terminal de Vendas
            var rotas = transporte.Routing();
            rotas.RouteToEndpoint(typeof(FazerPedido), "Vendas");

            var instanciaEndpoint = await Endpoint.Start(configuracaoEndpoint).ConfigureAwait(false);

            await PedidosLoop(instanciaEndpoint).ConfigureAwait(false);

            await instanciaEndpoint.Stop().ConfigureAwait(false);
        }

        private static readonly ILog Log = LogManager.GetLogger<Program>();

        private static async Task PedidosLoop(IEndpointInstance instanciaEndpoint)
        {
            while (true)
            {
                Log.Info("Aperte 'P' para fazer um pedido ou 'S' para sair.");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.P:
                        var comando = new FazerPedido();

                        Log.Info($"Enviando comando FazerPedido, PedidoId = {comando.PedidoId}");
                        //Envie o comando para os endpoints configurados nas rotas
                        await instanciaEndpoint.Send(comando).ConfigureAwait(false);
                        break;

                    case ConsoleKey.S:
                        return;

                    default:
                        Log.Info("Entrada desconhecida. Por favor, tente novamente.");
                        break;
                }
            }
        }
    }
}
