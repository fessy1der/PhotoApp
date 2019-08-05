using Microsoft.EntityFrameworkCore;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using PhotoApp.Data;
using PhotoApp.Data.Models;
using PhotoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApp.Services
{
    public class PhotoService : IPhoto
    {
        private readonly PhotoAppDbContext _photoAppDbContext;
        public PhotoService(PhotoAppDbContext photoAppDbContext)
        {
            _photoAppDbContext = photoAppDbContext;
        }
        public IEnumerable<Photo> GetAll()
        {
            return _photoAppDbContext.Images.Include(i => i.Tags);
        }

        public Photo GetById(int id)
        {
            return GetAll().Where(i => i.Id == id).First();
        }

        public IEnumerable<Photo> GetByTags(string tag)
        {
            return _photoAppDbContext.Images.Where(i => i.Tags.Any(t => t.Description == tag));
        }

        public CloudBlobContainer GetBlobContainer(string azureConnectionString, string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(azureConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            return blobClient.GetContainerReference(containerName);

        }

        public  async Task SetImage(string title, string tags, Uri uri)
        {
            var image = new Photo
            {
                Title = title,
                Tags = ParseTags(tags),
                Url = uri.AbsoluteUri,
                DateCreated = DateTime.Now
            };
            _photoAppDbContext.Add(image);
            await _photoAppDbContext.SaveChangesAsync();
        }

        public List<Tag> ParseTags(string tags)
        {
            return tags.Split(",").Select(t => new Tag
            {
                Description = t
            }).ToList();
        }
    }
}
