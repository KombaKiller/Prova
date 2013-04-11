using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProvaAlexandre.Dominio;
using ProvaAlexandre.Repositorio;

namespace ProvaAlexandre.Aplicacao
{
    public class UsuarioAplicacao
    {
        private readonly Contexto contexto = new Contexto();

        private void Inserir(Usuario usuario)
        {
            var strQuery = " ";
            strQuery += " INSERT INTO usuario (usuarioLogin,senha) ";
            strQuery += string.Format(" VALUES ('{0}','{1}') ",
                usuario.UsuarioNome, usuario.Senha);
            contexto.ExecutaComando(strQuery);
        }

        private void Alterar(Usuario usuario)
        {
            var strQuery = " ";
            strQuery += " UPDATE usuario SET ";
            strQuery += string.Format(" usuarioLogin = '{0}', ", usuario.UsuarioNome);
            strQuery += string.Format(" Senha = '{0}' ", usuario.Senha);
            strQuery += string.Format(" WHERE UsuarioId = {0}", usuario.UsuarioId);
            contexto.ExecutaComando(strQuery);
        }

        public void Salvar(Usuario usuario)
        {
            if (usuario.UsuarioId > 0)
                Alterar(usuario);
            else
                Inserir(usuario);
        }

        public void Excluir(int id)
        {
            var strQuery = string.Format(" DELETE FROM usuario WHERE Usuario_Id = {0} ", id);
            contexto.ExecutaComando(strQuery);
        }

        public List<Usuario> ListarTodos()
        {
            var strQuery = " SELECT * FROM usuario ";
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno);
        }

        public Usuario ListarPorId(int id)
        {
            var strQuery = " SELECT * FROM usuario WHERE Usuario_Id = " + id;
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno).FirstOrDefault();
        }

        private List<Usuario> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var usuarios = new List<Usuario>();
            while (reader.Read())
            {
                var tempObjeto = new Usuario
                {
                    UsuarioId = int.Parse(reader["Usuario_Id"].ToString()),
                    UsuarioNome = reader["usuarioLogin"].ToString(),
                    Senha = reader["Senha"].ToString()
                };
                usuarios.Add(tempObjeto);
            }
            return usuarios;
        }
    }
}
