﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public interface ITurmaRepository
    {
        List<Turma> ListarTurmas();
        Turma ObterTurmaPeloId(int turmaId);
        List<Turma> ObterTurmasDesteAno();
        void Salvar(Turma turma);
        void Salvar(string CodigoTurma);
        void Atualizar(Turma turma);
    }
}
