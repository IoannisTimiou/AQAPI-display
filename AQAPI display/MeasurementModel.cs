using System;
using System.Collections.Generic;
using System.Text;

namespace AQAPI_display
{
    //model made to parse the results collection of the measurements JSON
    public class MeasurementModel
    {
        public string country { get; set; }
        public string city { get; set; }
        public int value { get; set; }
    }
}
