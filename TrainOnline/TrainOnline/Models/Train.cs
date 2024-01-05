using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainOnline.Models
{
    public class Train : Base
    {
        [Key]
        public int TrainId { get; set; }
        public int? TrainNumber { get; set; } = null;
        public int? TypeId { get; set; } = null;
        public int? StatusId { get; set; } = null;

        [ForeignKey("TypeId")]
        public virtual _Type GetTypeId { get; set; } = null;

        [ForeignKey("StatusId")]
        public virtual _Status GetStatusId { get; set; } = null;
    }
}
