using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using AspNetCore.Reporting;
using Payrol.Data;
using Payrol.Models;


namespace Payrol.Controllers
{
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment  _webHostEnvironment;
        private readonly IRepositoryStaff _staffRepository;

        public ReportController(IWebHostEnvironment webHostEnvironment, IRepositoryStaff repositoryStaff)
        {
            this._webHostEnvironment = webHostEnvironment;
            this._staffRepository = repositoryStaff;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Print()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\Report3.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            //parameters.Add("rp1", "Welcome");
            var salary = await _staffRepository.GetSalaries();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("Dataset1", salary);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }
    }
}
