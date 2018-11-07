﻿using Microsoft.EntityFrameworkCore;
using Minos.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        public void Salvar(Professor professor)
        {
            using (var contexto = new MinosContext())
            {
                contexto.Professores.Add(professor);
                contexto.SaveChanges();
            }
        }

        public List<Professor> ListarProfessores()
        {
            using (var contexto = new MinosContext())
            {
                var professores = contexto
                    .Professores
                    .Include(p => p.Turmas)
                    .ThenInclude(pt => pt.Turma)
                    .ToList();
                return professores;
            }
        }

        public Professor ObterProfessorPeloId(int turmaId)
        {
            using (var contexto = new MinosContext())
            {
                var professor = contexto.Professores.First(x => x.Id == turmaId);
                return professor;
            }
        }

        //public void Excluir(int id)
        //{
        //    var professor = ObterProfessorPeloId(id);
        //    using (var contexto = new MinosContext())
        //    {
        //        contexto.Remove(professor);
        //        contexto.SaveChanges();
        //    }
        //}

        public void Excluir(int id)
        {
            using (var contexto = new MinosContext())
            {
                var professor = contexto.Professores.Where(p => p.Id == id).First();
                contexto.Professores.Remove(professor);
                contexto.SaveChanges();
            }
        }
    }
}