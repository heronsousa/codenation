using System;
using System.Collections.Generic;
using System.Linq;

namespace Codenation.Challenge
{
    public class Country
    {        
        public State[] Top10StatesByArea()
        {
            var states = new List<State> {
                SetState("Acre", "AC", 164123.040),
                SetState("Alagoas", "AL", 27778.506),
                SetState("Amapá", "AP", 142828.521),
                SetState("Amazonas", "AM", 1559159.148),
                SetState("Bahia" , "BA",564733.177),
                SetState("Ceará", "CE",148920.472),
                SetState("Distrito Federal" , "DF",5779.999),
                SetState("Espírito Santo", "ES",46095.583),
                SetState("Goiás", "GO",340111.783),
                SetState("Maranhão", "MA",331937.450),
                SetState("Mato Grosso", "MT",903366.192),
                SetState("Mato Grosso do Sul", "MS",357145.532),
                SetState("Minas Gerais", "MG",586522.122),
                SetState("Pará", "PA",1247954.666),
                SetState("Paraíba", "PB",56585.000),
                SetState("Paraná", "PR",199307.922),
                SetState("Pernambuco", "PE",98311.616),
                SetState("Piauí", "PI",251577.738),
                SetState("Rio de Janeiro", "RJ",43780.172),
                SetState("Rio Grande do Norte", "RN",52811.047),
                SetState("Rio Grande do Sul", "RS",281730.223),
                SetState("Rondônia", "RO",237590.547),
                SetState("Roraima", "RR",224300.506),
                SetState("Santa Catarina", "SC",95736.165),
                SetState("São Paulo", "SP",248222.362),
                SetState("Sergipe", "SE",21915.116),
                SetState("Tocantins", "TO",277720.520)
            }.OrderByDescending(state => state.Area).ToArray();

            Array.Resize(ref states, 10);

            return states;
        }

        public State SetState(string name, string acronym, double area)
        {
            State state = new State(name, acronym);
            state.Area = area;

            return state;
        }
    }
}
