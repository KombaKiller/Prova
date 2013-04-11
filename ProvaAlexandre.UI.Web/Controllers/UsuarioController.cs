using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvaAlexandre.Aplicacao;
using ProvaAlexandre.Dominio;

namespace ProvaAlexandre.UI.Web.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            var aplicacao = new UsuarioAplicacao();
            var listaDeUsuarios = aplicacao.ListarTodos();
            return View(listaDeUsuarios);
        }

        public ActionResult Detalhes(int id)
        {
            var aplicacao = new UsuarioAplicacao();
            var usuario = aplicacao.ListarPorId(id);
            if (usuario == null)
                return HttpNotFound();
            return View(usuario);
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
        public ActionResult Cadastrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var aplicacao = new UsuarioAplicacao();
                aplicacao.Salvar(usuario);
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        public ActionResult Editar(int id)
        {
            var aplicacao = new UsuarioAplicacao();
            var usuario = aplicacao.ListarPorId(id);
            if (usuario == null)
                return HttpNotFound();



            return View(usuario);
        }

        [HttpPost]
        public ActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var aplicacao = new UsuarioAplicacao();
                aplicacao.Salvar(usuario);
                return RedirectToAction("Index");
            }

            return View(usuario);
        }


        public ActionResult Excluir(int id)
        {
            var aplicacao = new UsuarioAplicacao();
            var usuario = aplicacao.ListarPorId(id);
            if (usuario == null)
                return HttpNotFound();

            return View(usuario);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id)
        {
            var aplicacao = new UsuarioAplicacao();
            aplicacao.Excluir(id);
            return RedirectToAction("Index");
        }

    }
}
