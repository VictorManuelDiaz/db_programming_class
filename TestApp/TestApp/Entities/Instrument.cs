using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Entities
{
    class Instrument
    {
        public int tb_instrument_id { get; set; }
        public string name { get; set; }
        public string music_key { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int created_by { get; set; }
        public int updated_by { get; set; }
        public List<Musician_Instrument> Musicians { get; set; }
        /*Indica que un instrumento puede ser tocado por varios músicos*/
    }
}



