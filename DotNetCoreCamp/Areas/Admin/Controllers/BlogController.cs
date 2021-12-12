using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using ClosedXML.Excel;
using DotNetCoreCamp.Areas.Admin.Models;

namespace DotNetCoreCamp.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog Id";
                worksheet.Cell(1, 2).Value = "Blog Adı";
                int blogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(blogRowCount, 1).Value = item.Id;
                    worksheet.Cell(blogRowCount, 2).Value = item.BlogName;
                    blogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheets",
                        "Calisma1.xlsx");
                }
            }
        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogModels = new List<BlogModel>
            {
                new BlogModel {Id = 1, BlogName = "C# Programlamaya Giriş"},
                new BlogModel {Id = 2, BlogName = "Tesla Firmasının Araçları"},
                new BlogModel {Id = 3, BlogName = "20202 Olimpiyatları"}

            };
            return blogModels;
        }
    }
}
