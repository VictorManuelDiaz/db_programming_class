using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Entities
{
    class Musician_Instrument /*Representa tabla pivote o auxiliar*/
    {
        public int tb_musician_id { get; set; } /*Referencia hacia entidad Músico*/
        public int tb_instrument_id { get; set; } /*Referencia hacia entidad Instrumento*/
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int created_by { get; set; }
        public int updated_by { get; set; }
    }
}
