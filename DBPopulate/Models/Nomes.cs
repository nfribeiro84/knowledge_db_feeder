using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPopulate.Models
{
    [PetaPoco.TableName("Nomes")]
    [PetaPoco.PrimaryKey("NomesId")]
    class Nomes
    {
        public int NomesId { get; set; }
        public string Nome { get; set; }
        public string Idioma { get; set; }
    }
}
