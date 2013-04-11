using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvaAlexandre.Aplicacao;
using ProvaAlexandre.Dominio;

namespace ProvaAlexandre.UI.Web.Controllers
{
    public class FuncionarioController : Controller
    {
        //
        // GET: /Funcionario/

        public ActionResult Index()
        {
            var aplicacao = new FuncionarioAplicacao();
            var listaDeFuncionarios = aplicacao.ListarTodos();
            return View(listaDeFuncionarios);
        }

        public ActionResult Detalhes(int id)
        {
            var aplicacao = new FuncionarioAplicacao();
            var funcionario = aplicacao.ListarPorId(id);
            if (funcionario == null)
                return HttpNotFound();
            return View(funcionario);
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
        public ActionResult Cadastrar(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                var aplicacao = new FuncionarioAplicacao();
                aplicacao.Salvar(funcionario);
                return RedirectToAction("Index");
            }

            return View(funcionario);
        }

        public ActionResult Editar(int id)
        {
            var aplicacao = new FuncionarioAplicacao();
            var funcionario = aplicacao.ListarPorId(id);
            if (funcionario == null)
                return HttpNotFound();



            return View(funcionario);
        }

        [HttpPost]
        public ActionResult Editar(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                var aplicacao = new FuncionarioAplicacao();
                aplicacao.Salvar(funcionario);
                return RedirectToAction("Index");
            }

            return View(funcionario);
        }


        public ActionResult Excluir(int id)
        {
            var aplicacao = new FuncionarioAplicacao();
            var funcionario = aplicacao.ListarPorId(id);
            if (funcionario == null)
                return HttpNotFound();

            return View(funcionario);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id)
        {
            var aplicacao = new FuncionarioAplicacao();
            aplicacao.Excluir(id);
            return RedirectToAction("Index");
        }

    }
}
