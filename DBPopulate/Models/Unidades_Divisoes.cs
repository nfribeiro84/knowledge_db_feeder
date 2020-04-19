using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPopulate.Models
{
    [PetaPoco.TableName("Unidades_Divisoes")]
    [PetaPoco.PrimaryKey("UnidadesDivisoesId")]
    class Unidades_Divisoes
    {
        public int UnidadesDivisoesId { get; set; }
        public int UnidadesTerritoriaisId { get; set; }
        public int DivisoesTerritoriaisId { get; set; }
    }
}
