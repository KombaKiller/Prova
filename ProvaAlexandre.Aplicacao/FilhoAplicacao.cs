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
    public class FilhoAplicacao
    {
        private readonly Contexto contexto = new Contexto();

        private void Inserir(Filho filho)
        {
            var strQuery = " ";
            strQuery += " INSERT INTO FILHO (Nome  , Mae_Id , Funcionario_Id,Sexo) ";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}','{3}') ",
                filho.Nome, filho.MaeId, filho.FuncionarioId,filho.Sexo);
            contexto.ExecutaComando(strQuery);
        }

        private void Alterar(Filho filho)
        {
            var strQuery = " ";
            strQuery += " UPDATE FILHO SET ";
            strQuery += string.Format(" Nome = '{0}', ", filho.Nome);
            strQuery += string.Format(" Mae_Id = '{0}' ", filho.MaeId);
            strQuery += string.Format(" Sexo = '{0}', ", filho.Sexo);
            strQuery += string.Format(" Funcionario_Id = '{0}' ", filho.FuncionarioId);
            strQuery += string.Format(" WHERE Filho_Id = {0}", filho.FilhoId);
            contexto.ExecutaComando(strQuery);
        }

        public void Salvar(Filho filho)
        {
            if (filho.FilhoId > 0)
                Alterar(filho);
            else
                Inserir(filho);
        }

        public void Excluir(int id)
        {
            var strQuery = string.Format(" DELETE FROM FILHO WHERE Filho_Id = {0} ", id);
            contexto.ExecutaComando(strQuery);
        }

        public List<Filho> ListarTodos()
        {
            var strQuery = " SELECT * FROM FILHO ";
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno);
        }

        public List<Filho> ListarPorIdDaMae(int id)
        {
            var strQuery = " SELECT * FROM FILHO WHERE Mae_Id = " + id;
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno);
        }

        public List<Filho> ListarPorIdDoFuncionario(int id)
        {
            var strQuery = " SELECT * FROM FILHO WHERE Funcionario_Id = " + id;
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno);
        }


        public Filho ListarPorId(int id)
        {
            var strQuery = " SELECT * FROM FILHO WHERE Filho_Id = " + id;
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno).FirstOrDefault();
        }


        private List<Filho> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var filhos = new List<Filho>();
            while (reader.Read())
            {
                var tempObjeto = new Filho
                {
                    FilhoId = int.Parse(reader["Filho_Id"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    Sexo = reader["Sexo"].ToString(),
                    FuncionarioId = int.Parse(reader["Funcionario_Id"].ToString()),
                    MaeId = int.Parse(reader["Mae_Id"].ToString())
                };
                filhos.Add(tempObjeto);
            }
            return filhos;
        }
    }
}
