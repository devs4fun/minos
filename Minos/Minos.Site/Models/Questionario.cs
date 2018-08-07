﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class Questionario
    {
        public Periodo Periodo { get; private set; } // <- para representar uma data!
        public List<Turma> ListaDeTurmas { get; private set; }
        public List<Pergunta> ListaDePerguntas { get; set; }


        public Questionario(List<Pergunta> listaDePerguntas, Periodo periodo)
        {
            Periodo = periodo;
            ListaDePerguntas = listaDePerguntas;
        }


        public bool EhValido()
        {
            if (Periodo == null || Periodo.DataInicial == default || Periodo.DataFinal == default || ListaDePerguntas == null || ListaDePerguntas.Count == 0) // + || ListaDeTurmas == null || ListaDeTurmas.Count() <= 0 - sera que Questionario deveria ser criado sem uma lista de turmas ?  
            {
                return false;
            }
            return true;
        }

    }
}
