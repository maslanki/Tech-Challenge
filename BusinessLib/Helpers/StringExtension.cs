using System;
using System.ComponentModel;
using System.Text;
namespace BusinessLib.Helpers
{
    public static class DummyStringHelper
    {
        public static string ToString(this object o)
        {
            PropertyDescriptorCollection coll = TypeDescriptor.GetProperties(o);
            StringBuilder builder = new StringBuilder();
            foreach (PropertyDescriptor pd in coll)
            {
                if (pd.GetValue(o) == null) continue;
                builder.Append(string.Format("{0} : {1}", pd.Name, pd.GetValue(o).ToString()));
                builder.Append("\n");

            }
            return builder.ToString();
        }
    }
}
