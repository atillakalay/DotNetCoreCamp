using DotNetCoreCamp.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCoreCamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                Id = 1,
                Name = "Atilla"
            },
            new WriterClass
            {
                Id = 2,
                Name = "Rabia"
            },
            new WriterClass
            {
                Id = 3,
                Name = "Talha"
            },
        };
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public IActionResult GetById(int id)
        {
            var findWriter = writers.FirstOrDefault(w => w.Id == id);
            var jsonWriter = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriter);
        }
        public IActionResult GetWriterByID(int writerid)
        {
            var findWriter = writers.FirstOrDefault(x => x.Id == writerid);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }

        [HttpPost]
        public IActionResult AddWriter(WriterClass writerClass)
        {
            writers.Add(writerClass);
            var jsonWriters = JsonConvert.SerializeObject(writerClass);
            return Json(jsonWriters);

        }
        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x => x.Id == id);
            writers.Remove(writer);
            return Json(writer);
        }
        public IActionResult UpdateWriter(WriterClass writerClass)
        {
            var writer = writers.FirstOrDefault(x => x.Id == writerClass.Id);
            writer.Name = writerClass.Name;
            var jsonWriter = JsonConvert.SerializeObject(writerClass);
            return Json(jsonWriter);
        }


    }
}
