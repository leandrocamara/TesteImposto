using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Imposto.Core.NotasFiscais.Interfaces;
using Imposto.Core.Pedidos;

namespace TesteImposto
{
    public partial class FormImposto : Form
    {
        private readonly INotaFiscalService _notaFiscalService;

        public FormImposto(INotaFiscalService notaFiscalService)
        {
            InitializeComponent();
            dataGridViewPedidos.AutoGenerateColumns = true;
            dataGridViewPedidos.DataSource = GetTablePedidos();
            ResizeColumns();

            _notaFiscalService = notaFiscalService;
        }

        private void ResizeColumns()
        {
            double mediaWidth = dataGridViewPedidos.Width /
                                dataGridViewPedidos.Columns.GetColumnCount(DataGridViewElementStates.Visible);

            for (var i = dataGridViewPedidos.Columns.Count - 1; i >= 0; i--)
            {
                var coluna = dataGridViewPedidos.Columns[i];
                coluna.Width = Convert.ToInt32(mediaWidth);
            }
        }

        private object GetTablePedidos()
        {
            var table = new DataTable("pedidos");
            table.Columns.Add(new DataColumn("Nome do produto", typeof(string)));
            table.Columns.Add(new DataColumn("Codigo do produto", typeof(string)));
            table.Columns.Add(new DataColumn("Valor", typeof(string)));
            table.Columns.Add(new DataColumn("Brinde", typeof(bool)));

            return table;
        }

        private void buttonGerarNotaFiscal_Click(object sender, EventArgs eventArgs)
        {
            var table = (DataTable) dataGridViewPedidos.DataSource;

            if (!CamposValidos(table.Rows, out var errorMessage))
            {
                MessageBox.Show(errorMessage, @"Formulário inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var pedido = new Pedido
                {
                    EstadoOrigem = txtEstadoOrigem.Text,
                    EstadoDestino = txtEstadoDestino.Text,
                    NomeCliente = textBoxNomeCliente.Text
                };

                foreach (DataRow row in table.Rows)
                {
                    pedido.ItensDoPedido.Add(new PedidoItem
                    {
                        Brinde = !DBNull.Value.Equals(row["Brinde"]) && Convert.ToBoolean(row["Brinde"]),
                        CodigoProduto = row["Codigo do produto"].ToString(),
                        NomeProduto = row["Nome do produto"].ToString(),
                        ValorItemPedido = Convert.ToDouble(row["Valor"].ToString())
                    });
                }

                try
                {
                    _notaFiscalService.GerarNotaFiscal(pedido);
                    MessageBox.Show(@"Operação efetuada com sucesso");
                    LimparCampos();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, @"Formulário inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool CamposValidos(IEnumerable tableRows, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!UfsValidas().Contains(txtEstadoOrigem.Text.ToUpper()))
                errorMessage = "O Estado Origem inválido!";

            if (!UfsValidas().Contains(txtEstadoDestino.Text.ToUpper()))
                errorMessage = "O Estado Destino inválido!";

            foreach (DataRow row in tableRows)
            {
                if (!double.TryParse(row["Valor"].ToString(), out _))
                    errorMessage = "O Valor do item do pedido deve ser numérico!";
            }

            return string.IsNullOrEmpty(errorMessage);
        }

        private void LimparCampos()
        {
            textBoxNomeCliente.Clear();
            txtEstadoOrigem.Clear();
            txtEstadoDestino.Clear();
            dataGridViewPedidos.Columns.Clear();
            dataGridViewPedidos.DataSource = GetTablePedidos();
            ResizeColumns();
        }

        private List<string> UfsValidas()
        {
            return new List<string>
            {
                "RO", "AC", "AM", "RR", "PA", "AP", "TO", "MA", "PI", "CE", "RN", "PB", "PE", "AL", "SE", "BA", "MG",
                "ES", "RJ", "SP", "PR", "SC", "RS", "MS", "MT", "GO", "DF"
            };
        }
    }
}