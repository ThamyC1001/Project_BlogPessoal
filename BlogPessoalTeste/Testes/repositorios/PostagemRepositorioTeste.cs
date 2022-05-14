using Blogpessoal.src.data;
using Blogpessoal.src.dtos;
using Blogpessoal.src.repositorios;
using Blogpessoal.src.repositorios.implementacoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPessoalTeste.Testes.repositorios
{
        [TestClass]
        public class PostagemRepositorioTeste
        {
            private BlogPessoalContext _context;
            private IUsuario _repositorioU;
            private ITema _repositorioT;
            private IPostagem _repositorioP;

            [TestMethod]
            public void CriaTresPostagemNoSistemaRetornaTres()
            {
                // Definindo o contexto
                var opt = new DbContextOptionsBuilder<BlogPessoalContext>()
                     .UseInMemoryDatabase(databaseName: "db_blogpessoal21")
                     .Options;

                _context = new BlogPessoalContext(opt);
                _repositorioU = new UsuarioRepositorio(_context);
                _repositorioT = new TemaRepositorio(_context);
                _repositorioP = new PostagemRepositorio(_context);

                // GIVEN - Dado que registro 2 usuarios
                _repositorioU.NovoUsuario(
                    new NovoUsuarioDTO("Thamyres Cavalcanti", "thamyres@email.com", "484302", "URLDAFOTO")
                );

                _repositorioU.NovoUsuario(
                    new NovoUsuarioDTO("Genilsa Cavalcanti", "genilsa@email.com", "134652", "URLDAFOTO")
                );

            // AND - E que registro 2 temas
            _repositorioT.NovoTema(new NovoTemaDTO("C#"));
                _repositorioT.NovoTema(new NovoTemaDTO("Java"));

                // WHEN - Quando registro 3 postagens
                _repositorioP.NovaPostagem(
                    new NovaPostagemDTO(
                        "C# é muito daora",
                        "É uma linguagem muito utilizada no mundo",
                        "URLDAFOTO",
                        "thamyres@email.com",
                        "C#"
                    ));

                _repositorioP.NovaPostagem(
                    new NovaPostagemDTO(
                        "C# pode ser usado com Testes",
                        "O teste unitário é importante para o desenvolvimento",
                        "URLDAFOTO",
                        "genilsa@email.com",
                        "C#"
                    ));

                _repositorioP.NovaPostagem(
                    new NovaPostagemDTO(
                        "Java é muito maneiro",
                        "Java também é muito utilizada no mundo",
                        "URLDAFOTO",
                        "thamyres@email.com",
                        "Java"
                    ));

                // WHEN - Quando eu busco todas as postagens
                // THEN - Eu tenho 3 postagens
                Assert.AreEqual(3, _repositorioP.PegarTodasPostagens().Count());
            }

            [TestMethod]
            public void AtualizarPostagemRetornaPostagemAtualizada()
            {
                // Definindo o contexto
                var opt = new DbContextOptionsBuilder<BlogPessoalContext>()
                    .UseInMemoryDatabase(databaseName: "db_blogpessoal22")
                    .Options;

                _context = new BlogPessoalContext(opt);
                _repositorioU = new UsuarioRepositorio(_context);
                _repositorioT = new TemaRepositorio(_context);
                _repositorioP = new PostagemRepositorio(_context);

                // GIVEN - Dado que registro 1 usuarios
                _repositorioU.NovoUsuario(
                    new NovoUsuarioDTO(
                    "Thamyres Cavalcanti",
                    "Thamyres@email.com",
                    "484302",
                    "URLDAFOTO"
                    
                ));

                // AND - E que registro 1 tema
                _repositorioT.NovoTema(new NovoTemaDTO("COBOL"));
                _repositorioT.NovoTema(new NovoTemaDTO("C#"));

                // AND - E que registro 1 postagem
                _repositorioP.NovaPostagem(
                    new NovaPostagemDTO(
                        "COBOL é muito maneiro",
                        "É uma linguagem muito utilizada no mundo",
                        "URLDAFOTO",
                        "Thamyres@email.com",
                        "COBOL"
                    ));

                // WHEN - Quando atualizo postagem de id 1
                _repositorioP.AtualizarPostagem(
                    new AtualizarPostagemDTO(
                        1,
                        "C# é muito maneiro",
                        "C# é muito utilizada no mundo",
                        "URLDAFOTOATUALIZADA",
                        "C#"
                    ));

                // THEN - Eu tenho a postagem atualizada
                Assert.AreEqual("C# é muito maneiro", _repositorioP.PegarPostagemPeloId(1).Titulo);
                Assert.AreEqual("C# é muito utilizada no mundo", _repositorioP.PegarPostagemPeloId(1).Descricao);
                Assert.AreEqual("URLDAFOTOATUALIZADA", _repositorioP.PegarPostagemPeloId(1).Foto);
                Assert.AreEqual("C#", _repositorioP.PegarPostagemPeloId(1).Tema.Descricao);
            }

            [TestMethod]
            public void PegarPostagensPorPesquisaRetodarCustomizada()
            {
                // Definindo o contexto
                var opt = new DbContextOptionsBuilder<BlogPessoalContext>()
                    .UseInMemoryDatabase(databaseName: "db_blogpessoal23")
                    .Options;

                _context = new BlogPessoalContext(opt);
                _repositorioU = new UsuarioRepositorio(_context);
                _repositorioT = new TemaRepositorio(_context);
                _repositorioP = new PostagemRepositorio(_context);

                // GIVEN - Dado que registro 2 usuarios
                _repositorioU.NovoUsuario(
                    new NovoUsuarioDTO(
                     "Thamyres Cavalcanti", 
                     "thamyres@email.com", 
                     "924252",
                     "URLDAFOTO"
                ));

                _repositorioU.NovoUsuario(
                    new NovoUsuarioDTO(
                    "Genilsa Cavalcanti",
                    "genilsa@email.com",
                    "201121",
                    "URLDAFOTO"
                    ));

                // AND - E que registro 2 temas
                _repositorioT.NovoTema(new NovoTemaDTO("C#"));
                _repositorioT.NovoTema(new NovoTemaDTO("Java"));

                // WHEN - Quando registro 3 postagens
                _repositorioP.NovaPostagem(
                    new NovaPostagemDTO(
                        "C# é muito maneiro",
                        "É uma linguagem muito utilizada no mundo",
                        "URLDAFOTO",
                        "thamyres@email.com",
                        "C#"
                    ));
                _repositorioP.NovaPostagem(
                    new NovaPostagemDTO(
                        "C# pode ser usado com Testes",
                        "O teste unitário é importante para o desenvolvimento",
                        "URLDAFOTO",
                        "genilsa@email.com",
                        "C#"
                    ));

                _repositorioP.NovaPostagem(
                    new NovaPostagemDTO(
                        "Java é muito maneiro",
                        "Java também é muito utilizada no mundo",
                        "URLDAFOTO",
                        "thamyres@email.com",
                        "Java"
                    ));

                // WHEN - Quando eu busco as postagem
                // THEN - Eu tenho as postagens que correspondem aos criterios
                Assert.AreEqual(2, _repositorioP.PegarPostagensPorPesquisa("maneiro", null, null).Count);
                Assert.AreEqual(2, _repositorioP.PegarPostagensPorPesquisa(null, "C#", null).Count);
                Assert.AreEqual(2, _repositorioP.PegarPostagensPorPesquisa(null, null, "Thamyres Cavalcanti").Count);
            }
        }
    }
}
