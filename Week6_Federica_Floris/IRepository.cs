using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Federica_Floris
{
    public interface IRepository
    {
        List<Agente> VediTutti();  //per visualizzare tutti gli agenti

        List<Agente> CercaAgenteByArea(string area);

        Agente CercaAgenteByCF(string cf);

        void CercaAgenteByAnniServizio(int anniServizio);

        bool Aggiungi(Agente agente);


    }
}
