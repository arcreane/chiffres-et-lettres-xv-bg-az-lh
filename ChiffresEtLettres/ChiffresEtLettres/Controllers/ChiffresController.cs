using ChiffresEtLettres.Properties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ChiffresEtLettres.Controllers
{
    public class ChiffresController : Controller
    {
        // GET: LettresController
        public ActionResult Index()
        {
            Chiffres m_chiffres = new Chiffres();

            int nombreAleatoire = m_chiffres.GetNombreAlea();

            ViewBag.Nombre = nombreAleatoire;

            return View();
        }
    }
}
