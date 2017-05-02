using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RazorPDFCore;
using RadniNalog.Models;

namespace RadniNalog.Controllers
{
    public class PdfGeneratorController : RazorPDFCore.Controller
    {
        public IActionResult IndexPDF()
        {
            Zaposlenik z = new Zaposlenik
            {
                ID = 1,
                Ime = "Ivan"
            };

            return ViewPdf(z,"/Views/Home/printme");
        }
    }
}