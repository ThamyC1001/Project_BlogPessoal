﻿using Blogpessoal.src.dtos;
using Blogpessoal.src.modelos;

namespace Blogpessoal.src.repositorios
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de CRUD de usuario</para>
    /// <para>Criado por: Thamyres Cavalcanti </para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 29/04/2022</para>
    /// </summary>

    public interface IUsuario
    {
        void NovoUsuario(NovoUsuarioDTO Usuario);
        void AtualizarUsuario(AtualizarUsuarioDTO usuario);

        void DeletarUsuario(int id);
        UsuarioModelo PegarUsuarioPeloId(int id);
        UsuarioModelo PegarUsuarioPeloEmail(string email);
        UsuarioModelo PegarUsuarioPeloNome(string nome);
    }
}