using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PhotoApp.Data;
using PhotoApp.Models;
using PhotoApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PhotoApp.Controllers
{
    public class UploadController : Controller
    {
        private IConfiguration _config;
        private string AzureConnectionString { get; }
        private IPhoto _photoService;
        


        public UploadController(IConfiguration config, IPhoto photoService)
        {
            _config = config;
            _photoService = photoService;
            AzureConnectionString = _config["AzureConnectionString"];
        }
        public IActionResult Upload()
        {
            var model = new UploadImageModel();
            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> UploadNewImage(IFormFile file, string title, string tags)
        {
            var blob = _photoService.GetBlobContainer(AzureConnectionString, "photos");
            var content = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
            var fileName = content.FileName.Trim('"');
            var blockBlob = blob.GetBlockBlobReference(fileName);
            await blockBlob.UploadFromStreamAsync(file.OpenReadStream());
            await _photoService.SetImage(title, tags, blockBlob.Uri);

            return RedirectToAction("Index", "Photo");
        }
    }
}
