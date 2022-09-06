using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RequestModels
{
    public class BookRequestModel
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }
}
