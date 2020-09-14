using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WetterApp.Models;


namespace WetterApp.Datenbank
{
    public class Data
    {
        private static List<Wetter> WetterListe = new List<Wetter>();
        
        public List<Wetter> getAll()
        {
            return WetterListe;
        }

        public Wetter wetterName(int id)
        {
            return WetterListe.Where(h =>h.Id == id).FirstOrDefault();
        }

        public void Delete(int id)
        {
            WetterListe.Remove(wetterName(id));
        }


        public void speichern(Wetter wetter)
        {

            if (wetter.Id == 0)
            {
              wetter.Datum = DateTime.Now;
              WetterListe.Add(wetter);
            }
            else
            {
                var aktuallisieren = wetterName(wetter.Id);


                aktuallisieren.Name = wetter.Name;
                aktuallisieren.Temperatur = wetter.Temperatur;
                aktuallisieren.WetterLage = wetter.WetterLage;
                aktuallisieren.Windgeschwindigkeit = wetter.Windgeschwindigkeit;
            }


            

            
            
        }





    }



}

