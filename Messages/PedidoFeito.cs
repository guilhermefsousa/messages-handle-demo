using NServiceBus;

namespace Messages
{
    public class PedidoFeito : IEvent
    {
        public PedidoFeito(FazerPedido pedido)
        {
            PedidoId = pedido.PedidoId;
        }

        public string PedidoId { get; set; }
    }
}