using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PhotoApp.Data;
using PhotoApp.Models;

namespace PhotoApp.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IPhoto _photoService;
        public PhotoController(IPhoto photoService)
        {
            _photoService = photoService;
        }
        public IActionResult Index()
        {
            var imageList = _photoService.GetAll();
            var model = new PhotoIndexModel()
            {
                Images = imageList,
                SearchQuery = ""
            }; 
            return View(model);
        }

        public IActionResult PhotoDetail( int id)
        {
            var photo = _photoService.GetById(id);
            var model = new PhotoDetailModel()
            {
                Id = photo.Id,
                Title = photo.Title,
                Created = photo.DateCreated,
                Url = photo.Url,
                Tags = photo.Tags.Select(t => t.Description).ToList()
            };
            return View(model);
        }
        
    }
}