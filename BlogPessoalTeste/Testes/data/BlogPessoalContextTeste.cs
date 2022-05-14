using Blogpessoal.src.data;
using Blogpessoal.src.modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BlogPessoalTeste.Testes.data
{
    [TestClass]
    public class BlogPessoalContextTeste
    {
        private BlogPessoalContext _context;

        [TestInitialize]
        public void inicio()
        {
            var opt = new DbContextOptionsBuilder<BlogPessoalContext>()
            .UseInMemoryDatabase(databaseName: "db_blogpessoal")
            .Options;

            _context = new BlogPessoalContext(opt);
        }

        [TestMethod]
        public void InserirNovoUsuarioNoBancoRetonarUsuario()
        {
            UsuarioModelo usuario = new UsuarioModelo();

            usuario.Nome = "Thamyres Vitoria";
            usuario.Email = "Thamyres@email.com";
            usuario.Senha = "201122";
            usuario.Foto = "AKITAOLINKDAFOTO"; 

            _context.Usuarios.Add(usuario); // add um usuario

            _context.SaveChanges(); // comita a criação

            Assert.IsNotNull(_context.Usuarios.FirstOrDefault(usuario => usuario.Email == "Thamyres@email.com"));

            //Assert.AreEqual(1, 1);
        }
      
    }
}
