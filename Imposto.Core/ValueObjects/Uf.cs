using System;
using System.Collections.Generic;

namespace Imposto.Core.ValueObjects
{
    public struct Uf
    {
        private readonly string _value;

        public Uf(string value)
        {
            _value = value?.ToUpper();

            Validate();
        }

        public string Value()
        {
            return _value;
        }

        public bool SiglaSudeste()
        {
            return SiglasSudeste().Contains(_value);
        }

        private void Validate()
        {
            if (!SiglasValidas().Contains(_value))
                throw new Exception($"UF inválida! {_value}");
        }

        private List<string> SiglasValidas()
        {
            return new List<string>
            {
                "RO", "AC", "AM", "RR", "PA", "AP", "TO", "MA", "PI", "CE", "RN", "PB", "PE", "AL", "SE", "BA", "MG",
                "ES", "RJ", "SP", "PR", "SC", "RS", "MS", "MT", "GO", "DF"
            };
        }

        private List<string> SiglasSudeste()
        {
            return new List<string> {"MG", "ES", "RJ", "SP"};
        }
    }
}