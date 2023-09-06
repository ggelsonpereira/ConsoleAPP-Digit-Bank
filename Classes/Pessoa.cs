using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempConsoleApp1.Contratos;

namespace TempConsoleApp1.Classes
{
    public class Pessoa
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Senha { get; private set; }
        public Iconta Conta { get; set; }

        public void SetNome(string nome)
        {
            this.Nome = nome;
        }

        public void SetCpf(string cpf)
        {
            this.CPF = cpf;
        }

        public void SetSenha(string senha)
        {
            this.Senha = senha;
        }
    }
}
