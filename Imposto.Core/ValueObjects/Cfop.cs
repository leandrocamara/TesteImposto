namespace Imposto.Core.ValueObjects
{
    public struct Cfop
    {
        private readonly string _value;

        public Cfop(string estadoOrigem, string estadoDestino)
        {
            _value = string.Empty;

            if (estadoOrigem == "SP" || estadoOrigem == "MG")
            {
                if (estadoDestino == "RJ") _value = "6.000";
                if (estadoDestino == "PE") _value = "6.001";
                if (estadoDestino == "MG") _value = "6.002";
                if (estadoDestino == "PB") _value = "6.003";
                if (estadoDestino == "PR") _value = "6.004";
                if (estadoDestino == "PI") _value = "6.005";
                if (estadoDestino == "RO") _value = "6.006";
                if (estadoDestino == "SE") _value = "6.007";
                if (estadoDestino == "TO") _value = "6.008";
                if (estadoDestino == "SE") _value = "6.009";
                if (estadoDestino == "PA") _value = "6.010";
            }
        }

        public string Value()
        {
            return _value;
        }
    }
}