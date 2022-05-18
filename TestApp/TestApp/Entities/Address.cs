using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Entities
{
    class Address
    {
        public int tb_address_id { get; set; }
        public string description { get; set; }
        public string phone { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int created_by { get; set;}
        public int updated_by { get; set;}
        List<Musician> musicians = new List<Musician>();
    }
}
