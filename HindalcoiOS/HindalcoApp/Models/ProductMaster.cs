using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HindalcoiOS.Models
{
    public class ProductMaster
    {
        public string PlantName { get; set; }
        public string ProdCode { get; set; }
        public string ProdName { get; set; }
        public string UniqCode { get; set; }
        public DateTime DateAdded { get; set; }
        public string CreatedBy { get; set; }
        public int RoleId { get; set; }
       
    }
}
