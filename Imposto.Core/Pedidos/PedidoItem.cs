﻿namespace Imposto.Core.Pedidos
{
    public class PedidoItem
    {
        public string NomeProduto { get; set; }
        public string CodigoProduto { get; set; }
        public double ValorItemPedido { get; set; }
        public bool Brinde { get; set; }
    }
}