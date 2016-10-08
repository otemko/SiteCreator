using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Localization;

namespace SiteCreator.Web.Controllers
{
    public class ResourceController : Controller
    {
        private IHostingEnvironment environment;
        public ResourceController(IHostingEnvironment environment)
        {
            this.environment = environment;
        }

        [HttpGet]
        [Route("api/[controller]/language")]
        public JsonResult Get()
        {
            var folder = Path.Combine(environment.WebRootPath, "languages");
            string language = ChooseLanguageFromRequest(folder);
            var fileName = language + ".json";

            return GetJsonResultByPath(Path.Combine(folder, fileName));
        }

        string ChooseLanguageFromRequest(string folder)
        {
            var filesWithFolders = Directory.GetFiles(folder, "*.json");
            var filesList = new List<string>();
            filesWithFolders.ToList().ForEach(p => filesList.Add(Path.GetFileNameWithoutExtension(p)));
            var files = filesList.ToArray();

            string language = ChooseLanguageFromCookie(files);
            if (language != null) return language;

            language = ChooseLanguageFromHeader(files);
            if (language != null) return language;

            return "en";
        }

        private string ChooseLanguageFromHeader(string[] files)
        {
            string acceptedLanguages = Request.Headers["accept-language"];
            var languages = new HashSet<string>();
            acceptedLanguages.Split(',').ToList().ForEach(p => languages.Add(p.Substring(0, 2)));

            return CheckFilesForLanguage(files, languages.ToArray());
        }

        private string ChooseLanguageFromCookie(string[] files)
        {
            string language = HttpContext.Request.Cookies["Language"];
            if (language == null) return null;
            return CheckFilesForLanguage(files, new[] { language });
        }

        private string CheckFilesForLanguage(string[] files, string[] languages)
        {
            foreach (var language in languages)
                if (files.Contains(language)) return language;

            return null;
        }

        JsonResult GetJsonResultByPath(string path)
        {
            var file = System.IO.File.ReadAllText(path);
            object json = JsonConvert.DeserializeObject(file);

            return new JsonResult(json);
        }
    }
}
