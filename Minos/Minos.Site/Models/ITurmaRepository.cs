﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public interface ITurmaRepository
    {
        Turma ObterTurmaPeloId(List<int> turmaId);
    }
}