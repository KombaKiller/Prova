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
    public class FuncionarioAplicacao
    {
        private readonly Contexto contexto = new Contexto();

        private void Inserir(Funcionario funcionario)
        {
            var strQuery = " ";
            strQuery += " INSERT INTO FUNCIONARIO (Nome, Idade,funcao ) ";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}') ",
                funcionario.Nome, funcionario.Idade,funcionario.Funcao);
            contexto.ExecutaComando(strQuery);
        }

        private void Alterar(Funcionario funcionario)
        {
            var strQuery = " ";
            strQuery += " UPDATE FUNCIONARIO SET ";
            strQuery += string.Format(" Nome = '{0}', ", funcionario.Nome);
            strQuery += string.Format(" Idade = '{0}', ", funcionario.Idade);
            strQuery += string.Format(" Funcao = '{0}' ", funcionario.Funcao);
            strQuery += string.Format(" WHERE Funcionario_Id = {0}", funcionario.FuncionarioId);
            contexto.ExecutaComando(strQuery);
        }

        public void Salvar(Funcionario funcionario)
        {
            if (funcionario.FuncionarioId > 0)
                Alterar(funcionario);
            else
                Inserir(funcionario);
        }

        public void Excluir(int id)
        {
            var strQuery = string.Format(" DELETE FROM FUNCIONARIO WHERE Funcionario_Id = {0} ", id);
            contexto.ExecutaComando(strQuery);
        }

        public List<Funcionario> ListarTodos()
        {
            var strQuery = " SELECT * FROM FUNCIONARIO ";
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno);
        }

        public Funcionario ListarPorId(int id)
        {
            var strQuery = " SELECT * FROM FUNCIONARIO WHERE Funcionario_Id = " + id;
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno).FirstOrDefault();
        }

        private List<Funcionario> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var funcionario = new List<Funcionario>();
            while (reader.Read())
            {
                var tempObjeto = new Funcionario
                {
                    FuncionarioId = int.Parse(reader["Funcionario_Id"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    Idade = int.Parse(reader["Idade"].ToString()),
                    Funcao = reader["Funcao"].ToString(),
                };
                funcionario.Add(tempObjeto);
            }
            return funcionario;
        }
    }
}
