using NServiceBus;
using System;

namespace Messages
{
    public class FazerPedido : ICommand
    {
        public FazerPedido()
        {
            PedidoId = Guid.NewGuid().ToString();
        }

        public string PedidoId { get; set; }
    }
}