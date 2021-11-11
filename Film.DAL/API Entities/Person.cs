using System;
using System.Collections.Generic;
using System.Text;

namespace Film.DAL.API_Entities
{
    public class Person
    {
        public string Job { get; set; }
        public List<PersonDetails> Items { get; set; }
    }
}
