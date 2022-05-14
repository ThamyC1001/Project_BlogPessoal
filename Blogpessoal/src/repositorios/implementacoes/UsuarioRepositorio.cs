using Blogpessoal.src.data;
using Blogpessoal.src.dtos;
using Blogpessoal.src.modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogpessoal.src.repositorios.implementacoes
{
    public class UsuarioRepositorio : IUsuario
    {
        #region Atributos

        private readonly BlogPessoalContext _context;
        
        #endregion Atributos

        #region Construtores

        public UsuarioRepositorio(BlogPessoalContext context)
        {
            _context = context;
        }

        #endregion Construtores

        #region Metodos
        public async Task AtualizarUsuarioAsync(AtualizarUsuarioDTO usuario)
        {
            var usuarioExistente = await PegarUsuarioPeloIdAsync(usuario.Id);
            usuarioExistente.Nome = usuario.Nome;         
            usuarioExistente.Senha = usuario.Senha;
            usuarioExistente.Foto = usuario.Foto;
            _context.Usuarios.Update(usuarioExistente);
           await _context.SaveChangesAsync();

        }      

        public async Task DeletarUsuarioAsync(int id)
        {
            _context.Usuarios.Remove(await PegarUsuarioPeloIdAsync(id));
           await _context.SaveChangesAsync();
        }

        public async Task NovoUsuarioAsync(NovoUsuarioDTO Usuario)
        {
            await _context.Usuarios.AddAsync(new UsuarioModelo
            {
                Email = Usuario.Email,
                Nome = Usuario.Nome,
                Senha = Usuario.Senha,
                Foto = Usuario.Foto,
                Tipo = Usuario.Tipo
            });
        }

        public async Task<UsuarioModelo> PegarUsuarioPeloEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UsuarioModelo> PegarUsuarioPeloIdAsync(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);

        }
        public async Task<List<UsuarioModelo>> PegarUsuarioPeloNomeAsync(string nome)
        {
            return await _context.Usuarios
                .Where(u => u.Nome.Contains(nome))
                .ToListAsync();
        }

        #endregion Metodos
    }
}
