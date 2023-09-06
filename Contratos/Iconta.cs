using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempConsoleApp1.Classes;

namespace TempConsoleApp1.Contratos
{
    public interface Iconta
    {
        void Deposita(double valor);
        bool Saca(double valor);
        double ConsultaSaldo();
        string GetCodigoDoBanco();
        string GetNumeroAgencia();
        string GetNumeroDaConta();
        List<Extrato> Extrato();
    }
}
