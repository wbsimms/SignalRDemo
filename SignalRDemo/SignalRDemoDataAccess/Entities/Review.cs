using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalRDemoDataAccess.Types;

namespace SignalRDemoDataAccess.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        [MaxLength(30)]
        public string TwoWordReview { get; set; }
        public Subject Subject { get; set; }
    }
}
