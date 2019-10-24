using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertTime
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime ssDateTime= TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
            Console.WriteLine("now in utc:" + ssDateTime);
            string ssSourceTimeZoneId = "UTC";
            string ssDestTimeZoneId = "Romance Standard Time";
            DateTime ssOutDateTime;
            ssDateTime = DateTime.SpecifyKind(ssDateTime, DateTimeKind.Unspecified);
            ssOutDateTime = ssDateTime;

            TimeZoneInfo src = TimeZoneInfo.FindSystemTimeZoneById(ssSourceTimeZoneId);
            TimeZoneInfo dest = TimeZoneInfo.FindSystemTimeZoneById(ssDestTimeZoneId);

            ssOutDateTime = TimeZoneInfo.ConvertTime(ssDateTime, src, dest);
            Console.WriteLine("now in madrid:"+ssOutDateTime);
        }
    }
}
