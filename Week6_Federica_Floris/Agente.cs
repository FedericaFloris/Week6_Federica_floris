using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Federica_Floris
{
    public class Agente : Persona
    {
        public string AreaGeografica { get; set; }

        public int AnnoInizioAttivita { get; set; }


        public Agente()
        {

        }

        public Agente(string nome,string cognome,string cf,string areaGeografica, int annoInizioAttivita)
            : base(nome, cognome, cf)
        {
            AreaGeografica = areaGeografica;
            AnnoInizioAttivita = annoInizioAttivita;
        }

        public int CalcolaAnniDiServizioAgente()
        {
            return  DateTime.Now.Year - AnnoInizioAttivita;
            
        }

        public override string ToString()
        {
            return base.ToString() + $"- Anni di servizio: {CalcolaAnniDiServizioAgente()}";
        }
    }
}
