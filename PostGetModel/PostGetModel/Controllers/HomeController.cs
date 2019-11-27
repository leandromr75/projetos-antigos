using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PostGetModel.Models;

namespace PostGetModel.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var pessoa = new Pessoa
                                   {
                                       PessoaId = 1,
                                       Nome = "Leandro",
                                       Twitter = "leandro@outlook.com"

                                   };
            
            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Lista(Pessoa pessoa)
        {
            
            return View(pessoa);
        }

    }
}
