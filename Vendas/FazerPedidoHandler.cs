using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System.Threading.Tasks;

namespace Vendas
{
    //Manipulador de mensagens
    public class FazerPedidoHandler : IHandleMessages<FazerPedido>
    {
        private static ILog _log = LogManager.GetLogger<FazerPedidoHandler>();

        public Task Handle(FazerPedido message, IMessageHandlerContext context)
        {
            _log.Info($"FazerPedido Recebido, PedidoId: {message.PedidoId}");

            //Normalmente, é onde alguma lógica de negócios ocorreria
            var pedidoFeito = new PedidoFeito(message);

            _log.Info($"PedidoFeito Concluido, disparando evento de PedidoFeito, PedidoId: {message.PedidoId}");
            //Aqui estamos disparando o evento de PedidoFeito
            return context.Publish(pedidoFeito);
        }
    }
}