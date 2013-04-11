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
    public class MaeAplicacao
    {
        private readonly Contexto contexto = new Contexto();

        private void Inserir(Mae mae)
        {
            var strQuery = " ";
            strQuery += " INSERT INTO MAE (Nome, Idade) ";
            strQuery += string.Format(" VALUES ('{0}','{1}') ",
                mae.Nome, mae.Idade);
            contexto.ExecutaComando(strQuery);
        }

        private void Alterar(Mae mae)
        {
            var strQuery = " ";
            strQuery += " UPDATE MAE SET ";
            strQuery += string.Format(" Nome = '{0}', ", mae.Nome);
            strQuery += string.Format(" Idade = '{0}' ", mae.Idade);
            strQuery += string.Format(" WHERE Mae_Id = {0}", mae.MaeId);
            contexto.ExecutaComando(strQuery);
        }

        public void Salvar(Mae mae)
        {
            if (mae.MaeId > 0)
                Alterar(mae);
            else
                Inserir(mae);
        }

        public void Excluir(int id)
        {
            var strQuery = string.Format(" DELETE FROM MAE WHERE Mae_Id = {0} ", id);
            contexto.ExecutaComando(strQuery);
        }

        public List<Mae> ListarTodos()
        {
            var strQuery = " SELECT * FROM MAE ";
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno);
        }

        public Mae ListarPorId(int id)
        {
            var strQuery = " SELECT * FROM MAE WHERE Mae_Id = " + id;
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno).FirstOrDefault();
        }

        private List<Mae> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var mae = new List<Mae>();
            while (reader.Read())
            {
                var tempObjeto = new Mae
                {
                    MaeId = int.Parse(reader["Mae_Id"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    Idade = int.Parse(reader["Idade"].ToString()),

                };
                mae.Add(tempObjeto);
            }
            return mae;
        }
    }
}
