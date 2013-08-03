using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDemoDataAccess.Repositories
{
    public interface IRepositoryCollection
    {
        [Import]
        IReviewRepository ReviewRepository { get; set; }

        [Import]
        ISubjectRepository SubjectRepository { get; set; }
    }

    [Export(typeof(IRepositoryCollection))]
    public class RepositoryCollection : IRepositoryCollection
    {

        public RepositoryCollection()
        {
        }

        [Import]
        public IReviewRepository ReviewRepository { get; set; }

        [Import]
        public ISubjectRepository SubjectRepository { get; set; }

    }
}
