﻿using Minos.Site.Controllers;
using Minos.Site.Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Minos.UnitTests
{
    public class ProfessorControllerTests
    {
        private Mock<IProfessorRepository> professorRepositoryMock;
        private Mock<ITurmaRepository> turmaRepositoryMock;
        private AdminController sut;
        private Mock<Turma> turmaMock;
        private Mock<List<int>> turmaId;



        public void CriaMock()
        {
            this.professorRepositoryMock = new Mock<IProfessorRepository>();
            this.turmaRepositoryMock = new Mock<ITurmaRepository>();
        }

        
        public void CriaAdminController()
        {
            this.sut = new AdminController(professorRepositoryMock.Object, turmaRepositoryMock.Object);
            
            
        }

        public void CriaTurmaMock()
        {
            this.turmaMock = new Mock<Turma>();
        }

        public void CriaTurmaId()
        {
            this.turmaId = new Mock<List<int>>();
        }

        [Trait("ProfessorController", "Salvar Professor")]
        [Fact(DisplayName = "Deveria Salvar Professor Chamando Repository Uma Vez")]
        public void DeveriaSalvarProfessorChamandoRepositoryUmaVez()
        {
            //arrange
            CriaMock();
            CriaTurmaMock();
            
            //act
            CriaAdminController();
            sut.CadastrarProfessor("Robson", "Junior", turmaId);
            turmaRepositoryMock.Setup(x => x.ObterTurmaPeloId(It.IsAny<List<int>>())).Returns(turmaMock.Object);

            //assert
            professorRepositoryMock.Verify(x => x.Salvar(It.IsAny<Professor>()), Times.Once);
            

        }

        

        //[Trait("ProfessorController", "Deveria Não Salvar Nome Do Professor Com Numeros")]
        //[Fact(DisplayName = "Deveria Não Salvar Nome Do Professor Com Numeros")]
        //public void DeveriaNaoSalvarProfessorComNumero()
        //{
        //    //arrange
        //    CriaMock();

        //    //act
        //    CriaAdminController();

        //    sut.CadastrarProfessor("Robso2n", "Robson", 01);
            

        //    //assert
        //    professorRepositoryMock.Verify(x => x.Salvar(It.IsAny<Professor>()), Times.Never);
        //}

        //[Trait("ProfessorController", "Deveria Não Salvar Com Nome Do Professor Null")]
        //[Fact(DisplayName = "Deveria Não Salvar Com Nome Do Professor Null")]
        //public void DeveriaNaoSalvarProfessorComNull()
        //{
        //    //arrange
        //    CriaMock();
        //    //act
        //    CriaAdminController();
        //    sut.CadastrarProfessor("Robson", null, 01);
        //    //assert
        //    professorRepositoryMock.Verify(x => x.Salvar(It.IsAny<Professor>()), Times.Never);

        //}

        //[Trait("ProfessorController", "Deveria Não Salvar Com Nome Do Professor Vazio")]
        //[Fact(DisplayName = "Deveria Não Salvar Com Nome Do Professor Vazio")]
        //public void DeveriaNaoSalvarProfessorComVazio()
        //{
        //    //arrange
        //    CriaMock();
        //    //act
        //    CriaAdminController();
        //    sut.CadastrarProfessor("", "Junior", 01);
        //    //assert
        //    professorRepositoryMock.Verify(x => x.Salvar(It.IsAny<Professor>()), Times.Never);

        //}
    }
}
