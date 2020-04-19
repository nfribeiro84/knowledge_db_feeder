using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPopulate.Models
{
    [PetaPoco.TableName("HierarquiasTerritoriais")]
    [PetaPoco.PrimaryKey("HierarquiasTerritoriaisId")]
    class HierarquiasTerritoriais
    {
        public int HierarquiasTerritoriaisId { get; set; }
        public int NomesId { get; set; }
        public string Descricao { get; set; }
    }
}
