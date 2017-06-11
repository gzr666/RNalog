using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RazorPDFCore;
using RadniNalog.Models;
using RadniNalog.Data;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.NodeServices;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using OfficeOpenXml;
using RadniNalog.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace RadniNalog.Controllers
{

    [Route("api/pdf")]
    public  class PdfGeneratorController : RazorPDFCore.Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _env;

        public PdfGeneratorController(ApplicationDbContext context, IHostingEnvironment env)
        {

            _context = context;
            _env = env;


        }


        public IActionResult IndexPDF()
        {
            var lista = _context.Zaposlenici.ToList();
            this.Response.Headers.Add("Content-Encoding", "win-1250");


            return ViewPdf(lista,"/Views/Home/View");


        }


        [HttpGet("listaNaloga")]
        public  async Task<IActionResult> ListaZaposlenika([FromServices] INodeServices nodeServices)
        {


            var nalozi = ModelFactory.GetRNalozi(_context.RadniNalozi.Include(v => v.VrstaRada).Include(m => m.MjestoRada).Include(a => a.Automobil).ToList());

           

            


            HttpContext.Response.ContentType = "application/pdf";

            string filename = @"report.pdf";
            HttpContext.Response.Headers.Add("x-filename", filename);
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "x-filename");

            var result = await nodeServices.InvokeAsync<byte[]>("./pdf",nalozi);
            HttpContext.Response.Body.Write(result, 0, result.Length);
            return  new ContentResult();
        }

        
        [HttpGet("pdfNalog/{id}")]
        public async Task<IActionResult> ZaposlenikSingle([FromServices] INodeServices nodeServices, [FromRoute] int id)
        {

            var nalozi = ModelFactory.GetRNalozi(_context.RadniNalozi.Include(v => v.VrstaRada).Include(m => m.MjestoRada).Include(a => a.Automobil).ToList());


            var single = nalozi.SingleOrDefault(m => m.ID == id);




            var result = await nodeServices.InvokeAsync<byte[]>("./pdfSingle", single);

            HttpContext.Response.ContentType = "application/pdf";

            string filename = @"report.pdf";
            HttpContext.Response.Headers.Add("x-filename", filename);
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "x-filename");
            HttpContext.Response.Body.Write(result, 0, result.Length);
            return new ContentResult();
        }




        [HttpGet]
        public String Excel()
        {
            string webRoot = _env.WebRootPath;
            string filename = @"demo1.xlsx";
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, filename);
            FileInfo file = new FileInfo(Path.Combine(webRoot, filename));

            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo(Path.Combine(webRoot, filename));
            }

            using (ExcelPackage package = new ExcelPackage(file))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Employee");
                //First add the headers
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Name";
                worksheet.Cells[1, 3].Value = "Gender";
                worksheet.Cells[1, 4].Value = "Salary (in $)";

                //Add values
                worksheet.Cells["A2"].Value = 1000;
                worksheet.Cells["B2"].Value = "Jon";
                worksheet.Cells["C2"].Value = "M";
                worksheet.Cells["D2"].Value = 5000;

                worksheet.Cells["A3"].Value = 1001;
                worksheet.Cells["B3"].Value = "Graham";
                worksheet.Cells["C3"].Value = "M";
                worksheet.Cells["D3"].Value = 10000;

                worksheet.Cells["A4"].Value = 1002;
                worksheet.Cells["B4"].Value = "Jenny";
                worksheet.Cells["C4"].Value = "F";
                worksheet.Cells["D4"].Value = 5000;

                package.Save(); //Save the workbook.
            }

            return URL;




        }
    }
}