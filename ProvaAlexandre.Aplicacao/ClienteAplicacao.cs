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
    public class ClienteAplicacao
    {
        private readonly Contexto contexto = new Contexto();

        private void Inserir(Cliente cliente)
        {
            var strQuery = " ";
            strQuery += " INSERT INTO CLIENTE (Nome, Idade, Endereco, Telefone) ";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}','{3}') ",
                cliente.Nome, cliente.Idade, cliente.Endereco, cliente.Telefone);
            contexto.ExecutaComando(strQuery);
        }

        private void Alterar(Cliente cliente)
        {
            var strQuery = " ";
            strQuery += " UPDATE CLIENTE SET ";
            strQuery += string.Format(" Nome = '{0}', ", cliente.Nome);
            strQuery += string.Format(" Idade = '{0}', ", cliente.Idade);
            strQuery += string.Format(" Endereco = '{0}', ", cliente.Endereco);
            strQuery += string.Format(" Telefone = '{0}' ", cliente.Telefone);
            strQuery += string.Format(" WHERE Cliente_Id = {0}", cliente.Cliente_id);
            contexto.ExecutaComando(strQuery);
        }

        public void Salvar(Cliente cliente)
        {
            if (cliente.Cliente_id > 0)
                Alterar(cliente);
            else
                Inserir(cliente);
        }

        public void Excluir(int id)
        {
            var strQuery = string.Format(" DELETE FROM CLIENTE WHERE Cliente_Id = {0} ", id);
            contexto.ExecutaComando(strQuery);
        }

        public List<Cliente> ListarTodos()
        {
            var strQuery = " SELECT * FROM CLIENTE ";
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno);
        }

        public Cliente ListarPorId(int id)
        {
            var strQuery = " SELECT * FROM CLIENTE WHERE Cliente_Id = " + id;
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno).FirstOrDefault();
        }

        private List<Cliente> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var cliente = new List<Cliente>();
            while (reader.Read())
            {
                var tempObjeto = new Cliente
                {
                    Cliente_id = int.Parse(reader["Cliente_Id"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    Idade = int.Parse(reader["Idade"].ToString()),
                    Endereco = reader["Endereco"].ToString(),
                    Telefone = reader["Telefone"].ToString(),

                };
                cliente.Add(tempObjeto);
            }
            return cliente;
        }
    }
}
