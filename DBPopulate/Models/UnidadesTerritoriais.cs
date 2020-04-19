using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPopulate.Models
{
    [PetaPoco.TableName("UnidadesTerritoriais")]
    [PetaPoco.PrimaryKey("UnidadesTerritoriaisId")]
    class UnidadesTerritoriais
    {
        public int UnidadesTerritoriaisId { get; set; }
        public int NomesId { get; set; }
        //LandArea

    }
}
