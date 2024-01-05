using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainOnline.Models
{
    public class _Type : Base
    {
        [Key]
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string Value { get; set; }
        public string CSSClass { get; set; }
        public string Sorting { get; set; }
        public int StateId { get; set; }
    }
}
