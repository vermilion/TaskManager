using System;
using System.IO;
using System.Text;

namespace Model
{
    public static class Trace
    {
        public static void Write(params string[] param)
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.Append(DateTime.Now + " " + string.Join("\t", param));
            using (var sw = new StreamWriter("trace.log", true, Encoding.Default))
            {
                sw.Write(sb.ToString());
            }
        }
    }
}