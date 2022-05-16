using Blogpessoal.src.data;
using Blogpessoal.src.dtos;
using Blogpessoal.src.repositorios;
using Blogpessoal.src.repositorios.implementacoes;
using Blogpessoal.src.utilidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPessoalTeste.Testes.repositorios
{
    [TestClass]
    public class UsuarioRepositorioTeste
    {
        private BlogPessoalContext _context;
        private IUsuario _repositorio;

        [TestMethod]
        public async Task CriarQuatroUsuariosNoBancoRetornaQuatroUsuarios()
        {
            // Definindo o contexto
            var opt = new DbContextOptionsBuilder<BlogPessoalContext>()
                .UseInMemoryDatabase(databaseName: "db_blogpessoal1")
                .Options;

            _context = new BlogPessoalContext(opt);
            _repositorio = new UsuarioRepositorio(_context);

            //GIVEN - Dado que registro 4 usuarios no banco
            await _repositorio.NovoUsuarioAsync(
                new NovoUsuarioDTO("Thamyres Cavalcanti", "thamyres@email.com", "201121", "URLFOTO", TipoUsuario.NORMAL)
            );

            await _repositorio.NovoUsuarioAsync(
                new NovoUsuarioDTO("Genilsa Cavalcanti", "genilsa@email.com", "020576", "URLFOTO", TipoUsuario.NORMAL)
            );

            await _repositorio.NovoUsuarioAsync(
                new NovoUsuarioDTO("Anderson Cavalcanti", "anderson@email.com", "220900", "URLFOTO", TipoUsuario.NORMAL)
            );

            await _repositorio.NovoUsuarioAsync(
                new NovoUsuarioDTO("Nicoly Cavalcanti", "nicoly@email.com", "170101", "URLFOTO", TipoUsuario.NORMAL)
            );

            //WHEN - Quando pesquiso lista total            
            //THEN - Então recebo 4 usuarios
            Assert.AreEqual(4, _context.Usuarios.Count());
        }

        [TestMethod]
        public async Task PegarUsuarioPeloEmailRetornaNaoNulo()
        {
            // Definindo o contexto
            var opt = new DbContextOptionsBuilder<BlogPessoalContext>()
                .UseInMemoryDatabase(databaseName: "db_blogpessoal2")
                .Options;

            _context = new BlogPessoalContext(opt);
            _repositorio = new UsuarioRepositorio(_context);

            //GIVEN - Dado que registro um usuario no banco
            await _repositorio.NovoUsuarioAsync(
                new NovoUsuarioDTO("Vinicius Cavalcanti", "vinicius@email.com", "112021", "URLFOTO", TipoUsuario.NORMAL)
            );

            //WHEN - Quando pesquiso pelo email deste usuario
            var usuario = await _repositorio.PegarUsuarioPeloEmailAsync("vinicius@email.com");

            //THEN - Então obtenho um usuario
            Assert.IsNotNull(usuario);
        }

        [TestMethod]
        public async Task PegarUsuarioPeloIdRetornaNaoNuloENomeDoUsuario()
        {
            // Definindo o contexto
            var opt = new DbContextOptionsBuilder<BlogPessoalContext>()
                .UseInMemoryDatabase(databaseName: "db_blogpessoal3")
                .Options;

            _context = new BlogPessoalContext(opt);
            _repositorio = new UsuarioRepositorio(_context);

            //GIVEN - Dado que registro um usuario no banco
            await _repositorio.NovoUsuarioAsync(
                new NovoUsuarioDTO("Andre Cavalcanti", "andre@email.com", "290300", "URLFOTO", TipoUsuario.NORMAL)
            );

            //WHEN - Quando pesquiso pelo id 1
            var usuario = await _repositorio.PegarUsuarioPeloIdAsync(1);

            //THEN - Então, deve me retornar um elemento não nulo
            Assert.IsNotNull(usuario);
            //THEN - Então, o elemento deve ser Andre Cavalcanti
            Assert.AreEqual("Andre Cavalcanti", usuario.Nome);
        }

        [TestMethod]
        public async Task AtualizarUsuarioRetornaUsuarioAtualizado()
        {
            // Definindo o contexto
            var opt = new DbContextOptionsBuilder<BlogPessoalContext>()
                .UseInMemoryDatabase(databaseName: "db_blogpessoal4")
                .Options;

            _context = new BlogPessoalContext(opt);
            _repositorio = new UsuarioRepositorio(_context);

            //GIVEN - Dado que registro um usuario no banco
            await _repositorio.NovoUsuarioAsync(
                new NovoUsuarioDTO("Giovanna Cavalcanti", "giovanna@email.com", "241220", "URLFOTO", TipoUsuario.NORMAL)
            );

            //WHEN - Quando atualizamos o usuario
            await _repositorio.AtualizarUsuarioAsync(
                new AtualizarUsuarioDTO(1, "Giovanna Gabrielly", "122420", "URLFOTONOVA")
            );

            //THEN - Então, quando validamos pesquisa deve retornar nome Giovanna Gabrielly
            var antigo = await _repositorio.PegarUsuarioPeloEmailAsync("giovanna@email.com");

            Assert.AreEqual(
                "Giovanna Gabrielly",
                _context.Usuarios.FirstOrDefault(u => u.Id == antigo.Id).Nome
            );

            //THEN - Então, quando validamos pesquisa deve retornar senha 123456
            Assert.AreEqual(
                "122420",
                _context.Usuarios.FirstOrDefault(u => u.Id == antigo.Id).Senha
            );
        }

    }
}