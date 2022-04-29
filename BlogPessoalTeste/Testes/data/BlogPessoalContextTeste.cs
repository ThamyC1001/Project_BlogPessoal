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

            usuario.Nome = "Karol Boaz";
            usuario.Email = "Karol@email.com";
            usuario.Senha = "134652";
            usuario.Foto = "AKITAOLINKDAFOTO"; 

            _context.Usuarios.Add(usuario); // add um usuario

            _context.SaveChanges(); // comita a cria��o

            Assert.IsNotNull(_context.Usuarios.FirstOrDefault(usuario => usuario.Email == "Karol@email.com"));

            //Assert.AreEqual(1, 1);
        }
      
    }
}