using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvaAlexandre.Aplicacao;
using ProvaAlexandre.Dominio;

namespace ProvaAlexandre.UI.Web.Controllers
{
    [Authorize]
    public class EquipamentoController : Controller
    {
        public ActionResult Index()
        {
            var aplicacao = new EquipamentoAplicacao();
            var listaDeEquipamentos = aplicacao.ListarTodos();
            return View(listaDeEquipamentos);
        }

        public ActionResult Detalhes(int id)
        {
            var aplicacao = new EquipamentoAplicacao();
            var equipamento = aplicacao.ListarPorId(id);
            if (equipamento == null)
                return HttpNotFound();
            return View(equipamento);
        }
        public ActionResult ListarCliente(int id)
        {
            var aplicacao = new EquipamentoAplicacao();
            var listaDeEquipamentosdomesmocliente = aplicacao.ListarPorIdDoCliente(id);
            return View(listaDeEquipamentosdomesmocliente);
        }

        public ActionResult Cadastrar()
        {
            var cliente = new ClienteAplicacao();
            ViewBag.listaDeCliente = new SelectList(
                cliente.ListarTodos(),
                "Cliente_id",
                "Nome"
                );
            var funcionario = new FuncionarioAplicacao();
            ViewBag.listaDeFuncionario = new SelectList(
                funcionario.ListarTodos(),
                "FuncionarioId",
                "Nome"
                );

            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Equipamento equipamento)
        {
            if (ModelState.IsValid)
            {
                var aplicacao = new EquipamentoAplicacao();
                aplicacao.Salvar(equipamento);
                return RedirectToAction("Index");
            }

            return View(equipamento);
        }

        public ActionResult Editar(int id)
        {
            var aplicacao = new EquipamentoAplicacao();
            var equipamento = aplicacao.ListarPorId(id);
            if (equipamento == null)
                return HttpNotFound();

            var cliente = new ClienteAplicacao();
            ViewBag.listaDeCliente = new SelectList(
                cliente.ListarTodos(),
                "Cliente_id",
                "Nome"
                );
            var funcionario = new FuncionarioAplicacao();
            ViewBag.listaDeFuncionario = new SelectList(
                funcionario.ListarTodos(),
                "FuncionarioId",
                "Nome"
                );

            return View(equipamento);
        }

        [HttpPost]
        public ActionResult Editar(Equipamento equipamento)
        {
            if (ModelState.IsValid)
            {
                var aplicacao = new EquipamentoAplicacao();
                aplicacao.Salvar(equipamento);
                return RedirectToAction("Index");
            }


            return View(equipamento);
        }


        public ActionResult Excluir(int id)
        {
            var aplicacao = new EquipamentoAplicacao();
            var equipamento = aplicacao.ListarPorId(id);
            if (equipamento == null)
                return HttpNotFound();

            return View(equipamento);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id)
        {
            var aplicacao = new EquipamentoAplicacao();
            aplicacao.Excluir(id);
            return RedirectToAction("Index");
        }

    }
}
