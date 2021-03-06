﻿using Minos.Site.Controllers;
using Minos.Site.Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Minos.UnitTests
{
    public class ProfessorTests : Tests
    {
        [Trait("ProfessorController", "Cadastrar Professor")]
        [Fact(DisplayName = "Deveria Salvar Professor Chamando Repository Uma Vez")]
        public void DeveriaSalvarProfessorChamandoRepositoryUmaVez()
        {
            //arrange
            CriaMock();
            PopulaTurmaId();
            
            //act
            CriaAdminController();
            turmaRepositoryMock.Setup(x => x.ObterTurmaPeloId(It.IsAny<int>())).Returns(new Turma(Grau.Medio, Serie.NonoAno, Turno.Manha, "") { Id = 1 });
            sut.CadastrarProfessor("Robson", "Junior", turmaId);
            

            //assert
            professorRepositoryMock.Verify(x => x.Salvar(It.IsAny<Professor>()), Times.Once);
            
        }



        [Trait("ProfessorController", "Cadastrar Professor")]
        [Fact(DisplayName = "Deveria Não Salvar Nome Do Professor Com Numeros")]
        public void DeveriaNaoSalvarProfessorComNumero()
        {
            //arrange
            CriaMock();
            PopulaTurmaId();

            //act
            CriaAdminController();
            turmaRepositoryMock.Setup(x => x.ObterTurmaPeloId(It.IsAny<int>())).Returns(new Turma(Grau.Medio, Serie.NonoAno, Turno.Manha, "A1T"));
            sut.CadastrarProfessor("Robso2n", "Robson", turmaId);


            //assert
            professorRepositoryMock.Verify(x => x.Salvar(It.IsAny<Professor>()), Times.Never);
        }

        [Trait("ProfessorController", "Cadastrar Professor")]
        [Fact(DisplayName = "Deveria Não Salvar Com Nome Do Professor Null")]
        public void DeveriaNaoSalvarProfessorComNull()
        {
            //arrange
            CriaMock();
            PopulaTurmaId();

            //act
            CriaAdminController();
            turmaRepositoryMock.Setup(x => x.ObterTurmaPeloId(It.IsAny<int>())).Returns(new Turma(Grau.Medio, Serie.NonoAno, Turno.Manha, "A1T"));
            sut.CadastrarProfessor("Robson", null, turmaId);

            //assert
            professorRepositoryMock.Verify(x => x.Salvar(It.IsAny<Professor>()), Times.Never);

        }

        [Trait("ProfessorController", "Cadastrar Professor")]
        [Fact(DisplayName = "Deveria Não Salvar Com Nome Do Professor Vazio")]
        public void DeveriaNaoSalvarProfessorComVazio()
        {
            //arrange
            CriaMock();
            PopulaTurmaId();

            //act
            CriaAdminController();
            turmaRepositoryMock.Setup(x => x.ObterTurmaPeloId(It.IsAny<int>())).Returns(new Turma(Grau.Medio, Serie.NonoAno, Turno.Manha, "A1T"));
            sut.CadastrarProfessor("", "Junior", turmaId);

            //assert
            professorRepositoryMock.Verify(x => x.Salvar(It.IsAny<Professor>()), Times.Never);

        }

        [Trait("ProfessorController", "Cadastrar Professor")]
        [Fact(DisplayName = "Deveria Não Salvar Com a conexão com o Repository De Turma Retornando Null")]
        public void DeveriaNaoSalvarComAConexaoComRepositoryDeTurmaRetornandoNull()
        {
            //arrange
            CriaMock();
            PopulaTurmaId();

            //act
            CriaAdminController();
            turmaRepositoryMock.Setup(x => x.ObterTurmaPeloId(It.IsAny<int>())).Returns(turmaNull);
            sut.CadastrarProfessor("Robson", "Junior", turmaId);

            //assert
            professorRepositoryMock.Verify(x => x.Salvar(It.IsAny<Professor>()), Times.Never);

        }

        [Trait("ProfessorController", "Cadastrar Professor")]
        [Fact(DisplayName = "Deveria Não Salvar Com a lista de turmas passada pelo usuario sem valores atribuidos a ela")]
        public void DeveriaNaoSalvarComAListaDeTurmasPassadaPeloUsuarioSemValoresAtribuidosAEla()
        {
            //arrange
            CriaMock();
            PopulaTurmaId();

            //act
            CriaAdminController();
            
            sut.CadastrarProfessor("Robson", "Junior", turmaIdVazia);
            //assert
            turmaRepositoryMock.Verify(x => x.ObterTurmaPeloId(It.IsAny<int>()), Times.Never);
            professorRepositoryMock.Verify(x => x.Salvar(It.IsAny<Professor>()), Times.Never);

        }

        [Trait("ProfessorController", "Cadastrar Professor")]
        [Fact(DisplayName = "Deveria Não Salvar Com a lista de turmas passada pelo usuario sem valores atribuidos a ela")]
        public void DeveriaNaoSalvarComAListaDeTurmasPassadaIgualANuloPeloUsuario()
        {
            //arrange
            CriaMock();
            PopulaTurmaId();

            //act
            CriaAdminController();
            
            sut.CadastrarProfessor("Robson", "Junior", null);
            //assert
            turmaRepositoryMock.Verify(x => x.ObterTurmaPeloId(It.IsAny<int>()), Times.Never);
            professorRepositoryMock.Verify(x => x.Salvar(It.IsAny<Professor>()), Times.Never);

        }
        
        [Trait("ProfessorController", "Cadastrar Professor")]
        [Fact(DisplayName = "Deveria Nao Salvar Professor Quando Repository Retorna Instancia Turma Vazia")]
        public void DeveriaNaoSalvarProfessorQuandoRepositoryRetornaInstanciaTurmaVazia()
        {
            //arrange
            CriaMock();
            PopulaTurmaId();

            //act
            CriaAdminController();
            turmaRepositoryMock.Setup(x => x.ObterTurmaPeloId(It.IsAny<int>())).Returns(new Turma(Grau.Nenhum, Serie.Nenhuma, Turno.Nenhum, "A1T"));

            sut.CadastrarProfessor("Robson", "Junior", turmaId);
            //assert
            professorRepositoryMock.Verify(x => x.Salvar(It.IsAny<Professor>()), Times.Never);
        }
    }
}
