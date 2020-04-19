using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPopulate.Models
{
    [PetaPoco.TableName("HT_NomesAlternativos")]    
    class HT_NomesAlternativos
    {
        public int HierarquiasTerritoriaisId { get; set; }
        public int NomesId { get; set; }
    }
}
