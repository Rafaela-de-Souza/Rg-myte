using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTe.Models.Entities;
using MyTe.Services;

namespace MyTe.Controllers
{
    public class TiposWBSController : Controller
    {
        private readonly WBSsService wbssService;
        public TiposWBSController(WBSsService wbssService)
        {
            this.wbssService = wbssService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListarWBSs()
        {
            var lista = wbssService.Listar();
            return View(lista);
        }

        [HttpGet]
        //[Authorize(Roles ="Administrador")]
        public IActionResult IncluirWBS()
        {
            return View();
        }

        [HttpPost]

        public IActionResult IncluirWBS(WBS wbs)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                wbssService.Incluir(wbs);
                return RedirectToAction("ListarWBSs");//Requisição GET
            }
            catch (Exception)
            {

                throw;
            };
        }
        // Action para alterar a descrição de uma área
        [HttpGet]
        //[Authorize(Roles = "Administrador")]
        public IActionResult AlterarWBS(int id)
        {
            try
            {
                //verificando se o id informado é válido
                if (id <= 0)
                {
                    throw new ArgumentException($"O valor informado na URL ({id}) é inválido");
                }

                WBS? wbs = wbssService.Buscar(id);

                if (wbs == null)
                {
                    throw new ArgumentException($"Nenhum objeto com este id : {id}");
                }
                return View(wbs);
            }
            catch (Exception e)
            {
                return View("_Erro", e);
            };
        }

        [HttpPost]

        public IActionResult AlterarWBS(WBS wbs)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                wbssService.Alterar(wbs);
                return RedirectToAction("ListarWBSs");//Requisição GET
            }
            catch (Exception)
            {

                throw;
            };

        }

        [HttpGet]
        //[Authorize(Roles = "Administrador")]
        public IActionResult RemoverWBS(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException($"O valor informado na URL ({id}) é inválido");
                }
                WBS? wbs = wbssService.Buscar(id);
                if (wbs == null)
                {
                    throw new ArgumentException($"Nenhum objeto com este id : {id}");
                }
                return View(wbs);
            }
            catch (Exception e)
            {
                return View("_Erro", e);
            }
        }

        [HttpPost]
        public IActionResult RemoverWBS(WBS wbs)
        {
            try
            {
                wbssService.Remover(wbs);
                return RedirectToAction("ListarWBSs");
            }
            catch (Exception e)
            {
                return View("_Erro", e);
            }
        }
    }
}