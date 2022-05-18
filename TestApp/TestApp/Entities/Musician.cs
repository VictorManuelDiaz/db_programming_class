using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Entities
{
    class Musician
    {
        public int tb_musician_id { get; set; }
        public string inss_number { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public decimal salary { get; set; }
        public int tb_address_id { get; set; } //Lave foránea
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int created_by { get; set; }
        public int updated_by { get; set; }
        public List<Musician_Instrument> Instruments { get; set; }
        /*Indica que a un músico corresponde una lista de instrumentos */

    }
}
