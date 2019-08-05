using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApp.Models
{
    public class PhotoIndexModel
    {
        public IEnumerable<Photo> Images { get; set; }
        public string SearchQuery { get; set; }
    }
}
