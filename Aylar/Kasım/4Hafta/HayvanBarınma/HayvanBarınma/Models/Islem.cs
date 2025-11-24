using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanBarınma.Models
{
    public class Islem
    {
        public int id { get; set; }
        public DateTime Tarih { get; set; }
        public string Hayvan { get; set; }
        public string Veteriner { get; set; }
        public string IslemTuru { get; set; }
        public string Açıklama { get; set; }
    }
}
