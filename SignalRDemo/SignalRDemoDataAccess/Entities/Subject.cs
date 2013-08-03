using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalRDemoDataAccess.Types;

namespace SignalRDemoDataAccess.Entities
{
    public class Subject
    {
        public Subject()
        {
        }

        public int SubjectId { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }
        public SubjectType SubjectType { get; set; }
    }
}
