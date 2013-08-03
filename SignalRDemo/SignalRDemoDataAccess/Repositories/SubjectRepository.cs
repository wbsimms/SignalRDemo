using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SignalRDemoDataAccess.Entities;

namespace SignalRDemoDataAccess.Repositories
{
    public interface ISubjectRepository
    {
        IList<Subject> GetAllSubjects();
    }

    [Export(typeof(ISubjectRepository))]
    public class SubjectRepository : ISubjectRepository
    {
        public SubjectRepository()
        {
        }

        public IList<Subject> GetAllSubjects()
        {
            using (SignalRDemoContext context = new SignalRDemoContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;
                context.Configuration.LazyLoadingEnabled = false;
                context.Configuration.ProxyCreationEnabled = false;
                List<Subject> retval = context.Subjects.AsNoTracking().ToList();
                return retval;
            }
        }
    }
}
