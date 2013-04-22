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
    public class ClienteController : Controller
    {
        //
        // GET: /Cliente/

        public ActionResult Index()
        {
            var aplicacao = new ClienteAplicacao();
            var listaDeClientes = aplicacao.ListarTodos();
            return View(listaDeClientes);
        }

        public ActionResult Detalhes(int id)
        {
            var aplicacao = new ClienteAplicacao();
            var cliente = aplicacao.ListarPorId(id);
            if (cliente == null)
                return HttpNotFound();
            return View(cliente);
        }

        public ActionResult Cadastrar()
        {
            var aplicacao = new EquipamentoAplicacao();
            ViewBag.listaDeEquipamentos = new SelectList(
                aplicacao.ListarTodos(),
                "Equipamento",
                "Modelo"
                );

            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var aplicacao = new ClienteAplicacao();
                aplicacao.Salvar(cliente);
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        public ActionResult Editar(int id)
        {
            var aplicacao = new ClienteAplicacao();
            var cliente = aplicacao.ListarPorId(id);
            if (cliente == null)
                return HttpNotFound();



            return View(cliente);
        }

        [HttpPost]
        public ActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var aplicacao = new ClienteAplicacao();
                aplicacao.Salvar(cliente);
                return RedirectToAction("Index");
            }

            return View(cliente);
        }


        public ActionResult Excluir(int id)
        {
            var aplicacao = new ClienteAplicacao();
            var cliente = aplicacao.ListarPorId(id);
            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id)
        {
            var aplicacao = new ClienteAplicacao();
            aplicacao.Excluir(id);
            return RedirectToAction("Index");
        }

    }
}
