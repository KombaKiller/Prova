using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvaAlexandre.Aplicacao;
using ProvaAlexandre.Dominio;

namespace ProvaAlexandre.UI.Web.Controllers
{
    public class MaeController : Controller
    {
        //
        // GET: /Mae/

        public ActionResult Index()
        {
            var aplicacao = new MaeAplicacao();
            var listaDeMaes = aplicacao.ListarTodos();
            return View(listaDeMaes);
        }

        public ActionResult Detalhes(int id)
        {
            var aplicacao = new MaeAplicacao();
            var mae = aplicacao.ListarPorId(id);
            if (mae == null)
                return HttpNotFound();
            return View(mae);
        }

        public ActionResult Cadastrar()
        {
            var aplicacao = new FilhoAplicacao();
            ViewBag.listaDeFilhoes = new SelectList(
                aplicacao.ListarTodos(),
                "FilhoId",
                "Nome"
                );

            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Mae mae)
        {
            if (ModelState.IsValid)
            {
                var aplicacao = new MaeAplicacao();
                aplicacao.Salvar(mae);
                return RedirectToAction("Index");
            }

            return View(mae);
        }

        public ActionResult Editar(int id)
        {
            var aplicacao = new MaeAplicacao();
            var mae = aplicacao.ListarPorId(id);
            if (mae == null)
                return HttpNotFound();



            return View(mae);
        }

        [HttpPost]
        public ActionResult Editar(Mae mae)
        {
            if (ModelState.IsValid)
            {
                var aplicacao = new MaeAplicacao();
                aplicacao.Salvar(mae);
                return RedirectToAction("Index");
            }

            return View(mae);
        }


        public ActionResult Excluir(int id)
        {
            var aplicacao = new MaeAplicacao();
            var mae = aplicacao.ListarPorId(id);
            if (mae == null)
                return HttpNotFound();

            return View(mae);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id)
        {
            var aplicacao = new MaeAplicacao();
            aplicacao.Excluir(id);
            return RedirectToAction("Index");
        }

    }
}
