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
            strQuery += " INSERT INTO Usuario (UsuarioLogin, Senha) ";
            strQuery += string.Format(" VALUES ('{0}','{1}') ",
                usuario.UsuarioNome, usuario.Senha);
            contexto.ExecutaComando(strQuery);
        }

        private void Alterar(Usuario usuario)
        {
            var strQuery = " ";
            strQuery += " UPDATE Usuario SET ";
            strQuery += string.Format(" UsuarioLogin = '{0}', ", usuario.UsuarioNome);
            strQuery += string.Format(" Senha = '{0}' ", usuario.Senha);
            strQuery += string.Format(" WHERE Usuario_Id = {0}", usuario.UsuarioId);
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
            var strQuery = string.Format(" DELETE FROM Usuario WHERE Usuario_Id = {0} ", id);
            contexto.ExecutaComando(strQuery);
        }

        public List<Usuario> ListarTodos()
        {
            var strQuery = " SELECT * FROM Usuario ";
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno);
        }

        public Usuario ListarPorId(int id)
        {
            var strQuery = " SELECT * FROM Usuario WHERE Usuario_Id = " + id;
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno).FirstOrDefault();
        }

        private List<Usuario> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var usuario = new List<Usuario>();
            while (reader.Read())
            {
                var tempObjeto = new Usuario
                {
                    UsuarioId = int.Parse(reader["Usuario_Id"].ToString()),
                    UsuarioNome = reader["UsuarioLogin"].ToString(),
                    Senha = reader["Senha"].ToString(),

                };
                usuario.Add(tempObjeto);
            }
            return usuario;
        }
    }
}
