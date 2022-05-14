using Blogpessoal.src.data;
using Blogpessoal.src.dtos;
using Blogpessoal.src.repositorios;
using Blogpessoal.src.repositorios.implementacoes;
using Blogpessoal.src.utilidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPessoalTeste.Testes.repositorios
{
    [TesteClass]
    public class UsuarioRepositorioTeste
    {
        private BlogPessoalContext _context; private IUsuario _repositorio;
        [TestInitialize] public void ConfiguracaoInicial()
        {
            var opt = new DbContextOptionsBuilder<ClassificadoContexto>()
           .UseInMemoryDatabase(databaseName: "db_blogpessoal")
           .Options;
          
            _context = new BlogPessoalContext(opt);
            
            _repositorio = new UsuarioRepositorio(_context); 
        }
          [TestMethod]
          public void CriarQuatroUsuariosNoBancoRetornaQuatroUsuarios()
          { 
            //GIVEN - Dado que registro 4 usuarios no banco
            _repositorio.NovoUsuario(
            new NovoUsuarioDTO("Thamyres Cavalcanti " , "thamyres@email.com", "112022","URLFOTO",TipoUsuario.NORMAL));

            _repositorio.NovoUsuario
                (new NovoUsuarioDTO("Genilsa Cavalcanti",  "genilsa@email.com", "020576",  "URLFOTO", TipoUsuario.NORMAL));

            _repositorio.NovoUsuario
                (new NovoUsuarioDTO("Vinicius Cavalcanti", "vinicius@email.com",  "201121", "URLFOTO", TipoUsuario.NORMAL));

            _repositorio.NovoUsuario
                (new NovoUsuarioDTO("Anderson Cavalcanti","anderson@email.com", "220900", "URLFOTO", TipoUsuario.NORMAL)); 

            //WHEN - Quando pesquiso lista total 

            //THEN - Então recebo 4 usuarios
            Assert.AreEqual(4, _context.Usuarios.Count());

          }
             [TestMethod]
          public void PegarUsuarioPeloEmailRetornaNaoNulo()
          {
            //GIVEN - Dado que registro um usuario no banco
            _repositorio.NovoUsuario(
             new NovoUsuarioDTO( "Genilsa Cavalcanti", "genilsa@email.com", "134652", "URLFOTO", TipoUsuario.NORMAL));

            //WHEN - Quando pesquiso pelo email deste usuario
            var user = _repositorio.PegarUsuarioPeloEmail("genilsa@email.com");

            //THEN - Então obtenho um usuario
            Assert.IsNotNull(user);
          }
           [TestMethod]
          public void PegarUsuarioPeloIdRetornaNaoNuloENomeDoUsuario() 
          {  
            //GIVEN - Dado que registro um usuario no banco
           _repositorio.NovoUsuario ( new NovoUsuarioDTO ( "Neusa Boaz", "neusa@email.com", "134652", "URLFOTO", TipoUsuario.NORMAL)); 

            //WHEN - Quando pesquiso pelo id 6
            var user = _repositorio.PegarUsuarioPeloId(6);
            
            //THEN - Então, deve me retornar um elemento não nulo
            Assert.IsNotNull(user); 
            //THEN - Então, o elemento deve ser Neusa Boaz
            Assert.AreEqual("Neusa Boaz", user.Name); 
          }
        [TestMethod]
        public void AtualizarUsuarioRetornaUsuarioAtualizado()
        {
            //GIVEN - Dado que registro um usuario no banco           
            _repositorio.NovoUsuario
             (new NovoUsuarioDTO("Vinicius Cavalcanti", "vinicius@email.com", "201121", "URLFOTO", TipoUsuario.NORMAL));

            //WHEN - Quando atualizamos o usuario
            var antigo =
            _repositorio.PegarUsuarioPeloEmail("vinicius@email.com");
            _repositorio.AtualizarUsuario(
             new AtualizarUsuarioDTO(7, "Vinicius Oliveira", "201121", "URLFOTONOVA",));

            //THEN - Então, quando validamos pesquisa deve retornar nome Vinicius Oliveira
            Assert.AreEqual(
            "Vinicius Oliveira",
            _context.Users.FirstOrDefault(u => u.Id == userOld.Id).Name);

            //THEN - Então, quando validamos pesquisa deve retornar senha 123456
            Assert.AreEqual(
             "201122",
             _context.Users.FirstOrDefault(u => u.Id ==
             userOld.Id).Password);
            
        }

    }
}