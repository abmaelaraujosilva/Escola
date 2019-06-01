using Escola.Models;
using Escola.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Escola.Controllers
{
    public class ProjetoPesquisaController : Controller
    {
        // GET: ProjetoPesquisa
        public ActionResult Index(int? id)
        {
            if (id != null)
            {
                Session["Id_Projeto"] = id;
            }
            return View();
        }

        public PartialViewResult Informacoes()
        {
            if (Session["Id_Projeto"] != null)
            {
                Proj_PesquisaRepository _PREP = new Proj_PesquisaRepository();
                Proj_Pesquisa p = new Proj_Pesquisa();
                p = _PREP.GETBYID((int)Session["Id_Projeto"]);
                return PartialView(p);
            }
            return PartialView();
        }

        [HttpPost]
        public ActionResult Informacoes(Proj_Pesquisa proj)
        {
            Proj_PesquisaRepository _PREP = new Proj_PesquisaRepository();
            try
            {
                proj.IdUsuario = (int)Session["IdUsuario"];
                proj.DataSubmissao = DateTime.Now.Date;
                proj.Status = "Não Enviado";
                _PREP.ADD(proj);
                if (Session["Id_Projeto"] == null)
                    Session["Id_Projeto"] = _PREP.GETLAST().First().IdProjeto;
            }
            catch (Exception)
            {
                return PartialView(proj);
            }
            return RedirectToAction("Membros");
        }

        public PartialViewResult Membros()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Membros(Membro m)
        {
            MembroRepository _MREP = new MembroRepository();
            m.IdProjeto = (int)Session["Id_Projeto"];
            if (m.IdMembro == 0)
            {
                _MREP.ADD(m);
            }
            else
            {
                _MREP.UPDATE(m, m.IdMembro);
            }

            return RedirectToAction("Membros");
        }

        public PartialViewResult ListaAluno()
        {
            try
            {
                MembroRepository _MREP = new MembroRepository();
                List<Membro> m = new List<Membro>();
                m = _MREP.GETBYIDPROJ((int)Session["Id_Projeto"], "Tipo in ('Bolsista','Não Bolsista')");
                return PartialView(m);
            }
            catch
            {
                return PartialView(new List<Membro>());
            }

        }

        public PartialViewResult ListaCoordenador()
        {
            MembroRepository _MREP = new MembroRepository();
            List<Membro> m = new List<Membro>();
            m = _MREP.GETBYIDPROJ(Session["Id_Projeto"] == null ? 0 : (int)Session["Id_Projeto"], "Tipo = 'Coordenador'");
            return PartialView(m);
        }

        public PartialViewResult ListaPesquisador()
        {
            MembroRepository _MREP = new MembroRepository();
            List<Membro> m = new List<Membro>();
            m = _MREP.GETBYIDPROJ(Session["Id_Projeto"] == null ? 0 : (int)Session["Id_Projeto"], "Tipo = 'Pesquisador'");
            return PartialView(m);
        }

        public JsonResult EditMembro(int id)
        {
            MembroRepository _MREP = new MembroRepository();
            Membro m = new Membro();
            m = _MREP.GETBYID(id);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var resultado = ser.Serialize(m);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public void DeleteMembro(int id)
        {
            MembroRepository _MREP = new MembroRepository();
            Membro m = new Membro { IdMembro = id };
            _MREP.DELETE(m);
        }
    }
}