using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPopulate.Models
{
    [PetaPoco.TableName("Unidades_Divisoes_Hierarquias")]
    [PetaPoco.PrimaryKey("UnidadesDivisoesHierarquiasId")]
    class Unidades_Divisoes_Hierarquias
    {
        public int UnidadesDivisoesHierarquiasId { get; set; }
        public int HierarquiasTerritoriaisId { get; set; }
        public int UnidadesDivisoesId { get; set; }
        public int? ParentId { get; set; }
    }
}
