using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDemoDataAccess.Utils
{
    public class EnumHelper<T>
    {
        public static T StringToEnum(string name)
        {
            return (T)Enum.Parse(typeof(T), name);
        }

        public static IList<string> EnumToList()
        {
            return new List<string>(Enum.GetNames(typeof (T)));
        }
    }
}
