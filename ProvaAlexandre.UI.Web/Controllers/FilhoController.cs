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
    public class FilhoController : Controller
    {
        public ActionResult Index()
        {
            var aplicacao = new FilhoAplicacao();
            var listaDeFilhos = aplicacao.ListarTodos();
            return View(listaDeFilhos);
        }

        public ActionResult Detalhes(int id)
        {
            var aplicacao = new FilhoAplicacao();
            var filho = aplicacao.ListarPorId(id);
            if (filho == null)
                return HttpNotFound();
            return View(filho);
        }
        public ActionResult ListarMae(int id)
        {
            var aplicacao = new FilhoAplicacao();
            var listaDeFilhosDaMesmaMae = aplicacao.ListarPorIdDaMae(id);
            return View(listaDeFilhosDaMesmaMae);
        }

        public ActionResult Cadastrar()
        {
            var Mae = new MaeAplicacao();
            ViewBag.listaDeMae = new SelectList(
                Mae.ListarTodos(),
                "MaeId",
                "Nome"
                );
            var Funcionario = new FuncionarioAplicacao();
            ViewBag.listaDeFuncionario = new SelectList(
                Funcionario.ListarTodos(),
                "FuncionarioId",
                "Nome"
                );

            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Filho filho)
        {
            if (ModelState.IsValid)
            {
                var aplicacao = new FilhoAplicacao();
                aplicacao.Salvar(filho);
                return RedirectToAction("Index");
            }

            return View(filho);
        }

        public ActionResult Editar(int id)
        {
            var aplicacao = new FilhoAplicacao();
            var filho = aplicacao.ListarPorId(id);
            if (filho == null)
                return HttpNotFound();

            var aplicacaoMae = new MaeAplicacao();
            ViewBag.ListaDeMae = new SelectList(
                aplicacaoMae.ListarTodos(),
                "MaeId",
                "NomeMae",
                filho.MaeId
                );

            return View(filho);
        }

        [HttpPost]
        public ActionResult Editar(Filho filho)
        {
            if (ModelState.IsValid)
            {
                var aplicacao = new FilhoAplicacao();
                aplicacao.Salvar(filho);
                return RedirectToAction("Index");
            }


            return View(filho);
        }


        public ActionResult Excluir(int id)
        {
            var aplicacao = new FilhoAplicacao();
            var filho = aplicacao.ListarPorId(id);
            if (filho == null)
                return HttpNotFound();

            return View(filho);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id)
        {
            var aplicacao = new FilhoAplicacao();
            aplicacao.Excluir(id);
            return RedirectToAction("Index");
        }

    }
}
