using Routler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    [RoutlerClass("api/ThisIsTest1", "Testing")]
    [RoutlerClass("api/ThisIsTest2", "Live")]
    public class RoutlerTestingClass
    {
    }
}