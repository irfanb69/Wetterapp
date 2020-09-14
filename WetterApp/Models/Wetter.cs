using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WetterApp.Models
{
    public class Wetter
    {

        public int Id { get; set; }
        [Display(Name = "penis")]
        public string WetterLage { get; set; }


        public decimal Temperatur { get; set; }


        public string Name { get; set; }


        public decimal Windgeschwindigkeit { get; set; }
        //[DataType(DataType.Date)]
        public DateTime Datum { get; set; }
    }
}
