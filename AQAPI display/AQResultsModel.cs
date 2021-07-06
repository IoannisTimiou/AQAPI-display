using System;
using System.Collections.Generic;
using System.Text;

namespace AQAPI_display
{
    //model made to parse the results of the measurements JSON into a collection
    public class AQResultsModel
    {
        public List<MeasurementModel> Results { get; set; }
    }
}
