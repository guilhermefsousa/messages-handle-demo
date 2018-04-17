using Messages;
using NServiceBus;
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

            //Comandos do tipo FazerPedido devem ser enviados para o terminal de Vendas
            var rotas = transporte.Routing();

            //Especifique o roteamento
            rotas.RouteToEndpoint(typeof(FazerPedido), "Vendas");

            //Especificando o roteamento para todas as mensagens em um Assembly
            //rotas.RouteToEndpoint(typeof(FazerPedido).Assembly, "Vendas");

            //Especifique o roteamento para todas as mensagens em um determinado assembly e namespace
            //rotas.RouteToEndpoint(typeof(FazerPedido).Assembly, "Especifico.Vendas", "AlgumEndpoint");

            var instanciaEndpoint = await Endpoint.Start(configuracaoEndpoint).ConfigureAwait(false);

            await PedidosLoop(instanciaEndpoint).ConfigureAwait(false);

            await instanciaEndpoint.Stop().ConfigureAwait(false);
        }

        private static async Task PedidosLoop(IEndpointInstance instanciaEndpoint)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Aperte 'P' para fazer um pedido ou 'S' para sair.");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.P:
                        var comando = new FazerPedido();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Enviando comando FazerPedido, PedidoId = {comando.PedidoId}");
                        //Envie o comando para os endpoints configurados nas rotas
                        await instanciaEndpoint.Send(comando).ConfigureAwait(false);
                        break;

                    case ConsoleKey.S:
                        return;

                    default:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Entrada desconhecida. Por favor, tente novamente.");
                        break;
                }
            }
        }
    }
}
