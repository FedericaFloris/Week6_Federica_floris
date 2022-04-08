using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Federica_Floris
{
    public abstract class Persona
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CF { get; set; }

        public Persona()
        {

        }

        public Persona(string nome,string cognome, string cf)
        {
            Nome = nome;
            Cognome = cognome;
            CF = cf;
        }


        public override string ToString()
        {
            return $"CF: {CF} - Nome: {Nome} - Cognome: {Cognome}";
        }
    }
}
