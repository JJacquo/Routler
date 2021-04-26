using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routler
{
    //[Route()]
    [RoutlerClass("flsjf", "kdsfj")]
    [RoutlerClass("sljfsf", "fsafkljdsf")]
    public class RoutlerTest
    {
        [RoutlerField("kdsfj")]
        public string MemberTest;
    }


}
