using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPopulate.Models
{
    [PetaPoco.TableName("DT_NomesAlternativos")]
    class DT_NomesAlternativos
    {
        public int DivisoesTerritoriaisId { get; set; }
        public int NomesId { get; set; }
    }
}
