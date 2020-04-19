using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPopulate.Models
{
    [PetaPoco.TableName("DivisoesTerritoriais")]
    [PetaPoco.PrimaryKey("DivisoesTerritoriaisId")]
    class DivisoesTerritoriais
    {
        public int DivisoesTerritoriaisId { get; set; }
        public int NomesId { get; set; }
        public int? UnidadesTerritoriaisId { get; set; }
        public string Descricao { get; set; }
    }
}
