using Microsoft.WindowsAzure.Storage.Blob;
using PhotoApp.Data.Models;
using PhotoApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoApp.Data
{
    public interface IPhoto
    {
        IEnumerable<Photo> GetAll();
        IEnumerable<Photo> GetByTags(string tag);
        Photo GetById(int id);
        CloudBlobContainer GetBlobContainer(string connectionString,string containerName);
        Task SetImage(string title, string tags, Uri uri);
        List<Tag> ParseTags(string tags);
    }
}
