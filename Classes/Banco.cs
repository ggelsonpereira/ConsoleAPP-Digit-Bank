using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempConsoleApp1.Classes
{
    public abstract class Banco
    {
        public Banco()
        {
            this.NomeDoBanco = "DigiBank";
            this.CodigoDoBanco = "BFA";
        }

        public string NomeDoBanco { get; private set; }

        public string CodigoDoBanco { get; private set; }
    }
}
