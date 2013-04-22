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
    public class EquipamentoAplicacao
    {
        private readonly Contexto contexto = new Contexto();

        private void Inserir(Equipamento equipamento)
        {
            var strQuery = " ";
            strQuery += " INSERT INTO EQUIPAMENTO (Marca, Modelo, NSerie, Cliente_Id , Funcionario_id) ";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}','{3}', '{4}') ",
                equipamento.Marca, equipamento.Modelo,equipamento.NSerie, equipamento.Cliente_id, equipamento.Funcionario_id);
            contexto.ExecutaComando(strQuery);
        }

        private void Alterar(Equipamento equipamento)
        {
            var strQuery = " ";
            strQuery += " UPDATE EQUIPAMENTO SET ";
            strQuery += string.Format(" Marca = '{0}', ", equipamento.Marca);
            strQuery += string.Format(" Modelo = '{0}', ", equipamento.Modelo);
            strQuery += string.Format(" NSerie = '{0}', ", equipamento.NSerie);
            strQuery += string.Format(" Cliente_id = '{0}', ", equipamento.Cliente_id);
            strQuery += string.Format(" Funcionario_Id = '{0}' ", equipamento.Funcionario_id);
            strQuery += string.Format(" WHERE Equipamento_Id = {0}", equipamento.Equipamento_id);
            contexto.ExecutaComando(strQuery);
        }

        public void Salvar(Equipamento equipamento)
        {
            if (equipamento.Equipamento_id > 0)
                Alterar(equipamento);
            else
                Inserir(equipamento);
        }

        public void Excluir(int id)
        {
            var strQuery = string.Format(" DELETE FROM EQUIPAMENTO WHERE Equipamento_Id = {0} ", id);
            contexto.ExecutaComando(strQuery);
        }

        public List<Equipamento> ListarTodos()
        {
            var strQuery = " SELECT * FROM EQUIPAMENTO ";
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno);
        }

        public List<Equipamento> ListarPorIdDoCliente(int id)
        {
            var strQuery = " SELECT * FROM EQUIPAMENTO WHERE Cliente_id = " + id;
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno);
        }

        public List<Equipamento> ListarPorIdDoFuncionario(int id)
        {
            var strQuery = " SELECT * FROM EQUIPAMENTO WHERE Funcionario_Id = " + id;
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno);
        }


        public Equipamento ListarPorId(int id)
        {
            var strQuery = " SELECT * FROM EQUIPAMENTO WHERE Equipamento_Id = " + id;
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno).FirstOrDefault();
        }


        private List<Equipamento> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var equipamentos = new List<Equipamento>();
            while (reader.Read())
            {
                var tempObjeto = new Equipamento
                {
                    Equipamento_id = int.Parse(reader["Equipamento_Id"].ToString()),
                    Marca = reader["Marca"].ToString(),
                    Modelo = reader["Modelo"].ToString(),
                    NSerie = reader["NSerie"].ToString(),
                    Cliente_id = int.Parse(reader["Cliente_id"].ToString()),
                    Funcionario_id = int.Parse(reader["Funcionario_Id"].ToString())
                    
                };
                equipamentos.Add(tempObjeto);
            }
            return equipamentos;
        }
    }
}
