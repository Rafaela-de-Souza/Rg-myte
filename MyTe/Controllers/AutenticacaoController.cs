using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MyTe.Models.Entities;
using Azure.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyTe.Services;
using MyTe.Models.Common;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MyTe.Controllers
{
    public class AutenticacaoController : Controller
    {
        private readonly AutenticacaoService authService;

        public AutenticacaoController(AutenticacaoService service)
        {
            this.authService = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Registrar()
        {
            ViewBag.Roles = new SelectList(authService.ListRoles());
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                var novo = await authService.CreateUser(model);
                if (novo.Success)
                {
                    return RedirectToAction("Login", "Autenticacao");
                }
                foreach (var error in novo.Errors!)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return Registrar();
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null) 
        { 
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LogonViewModel model,
            string? returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var loginSuccess = await authService.LoginUser(model);

                //object LoginResult = null;
                if (loginSuccess)
                {
                    Utils.UsuarioLogado!.Usuario = User.Identity!.Name;

                    if (returnUrl != null)
                    {
                        return Redirect(returnUrl);
                    }

                    if (User.IsInRole("Administrador"))
                    {
                        TempData["SucessMessage"] = "Login bem-sucedido!";
                        return RedirectToAction("ListarHorasLINQ", "Horas");
                    }
                    else
                    {
                        TempData["SucessMessage"] = "Login bem-sucedido!";
                        return RedirectToAction("ListarHoras", "Horas");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Credenciais inválidas");
                }
            }
            return View(model);
        }

        [HttpGet]

        public async Task<IActionResult> Logout()
        {
            await authService.LogoutUser();
            return RedirectToAction("Login", "Autenticacao");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            var erro = "Você não tem permissão para acessar este recurso!!";
            return View("_Erro", new Exception(erro));
        }


    }
}
