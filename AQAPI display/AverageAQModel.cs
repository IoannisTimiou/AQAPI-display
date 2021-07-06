using System;
using System.Collections.Generic;
using System.Text;

namespace AQAPI_display
{
    //model made to parse the results collection of the average JSON
    public class AverageAQModel
    {
        public string name { get; set; }
        public double average { get; set; }
    }
}
