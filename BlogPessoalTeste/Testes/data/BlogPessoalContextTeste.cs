using Blogpessoal.src.data;
using Blogpessoal.src.modelos;
using Blogpessoal.src.utilidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BlogPessoalTeste.Testes.data
{
    [TestClass]
    public class BlogPessoalContextoTeste
    {
        private BlogPessoalContext _contexto;

        [TestInitialize]
        public void inicio()
        {
            var opt = new DbContextOptionsBuilder<BlogPessoalContext>()
                .UseInMemoryDatabase(databaseName: "db_blogpessoal")
                .Options;

            _contexto = new BlogPessoalContext(opt);
        }

        [TestMethod]
        public void InserirNovoUsuarioNoBancoRetornarUsuario()
        {
            UsuarioModelo usuario = new UsuarioModelo();

            usuario.Nome = "Thamyres Cavalcanti";
            usuario.Email = "thamyres@email.com";
            usuario.Senha = "201121";
            usuario.Foto = "AKITAOLINKDAFOTO";
            usuario.Tipo = TipoUsuario.NORMAL;

            _contexto.Usuarios.Add(usuario); // Adcionando usuario

            _contexto.SaveChanges(); // Commita criação

            Assert.IsNotNull(_contexto.Usuarios.FirstOrDefault(u => u.Email == "karol@email.com"));
        }
    }
}
