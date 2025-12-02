using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanBarınma.Models
{
    public class Pet
    {
        public int PetID { get; set; }
        public string Name   { get; set; }
        public string Tur { get; set; }
        public string Irk { get; set; }
        public string Cinsiyet { get; set; }
        public int TahminiYas { get; set; }
        public System.DateTime Gelis { get; set; }
        public string Durum { get; set; }
        public string Padok { get; set; }
    }
}
