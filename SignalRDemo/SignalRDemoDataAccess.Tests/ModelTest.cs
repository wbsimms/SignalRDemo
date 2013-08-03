using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SignalRDemoDataAccess;
using SignalRDemoDataAccess.Entities;
using SignalRDemoDataAccess.Types;

namespace SignalRDemoDataAccess.Tests
{
    [TestClass]
    public class ModelTest
    {
        [TestMethod]
        public void Test01()
        {
            using (var container = new SignalRDemoDataAccess.SignalRDemoContext())
            {
                Subject subject = new Subject() {Name = "poo2",SubjectType = SubjectType.Park};
                container.Subjects.Add(subject);
                container.SaveChanges();
            }
        }
    }
}
