using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace crudXamarin.Models
{
    class Empresa
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }


        public override string ToString()
        {
            return this.Nome + " (" + this.Endereco + ") ";
        }
    }

    
}
