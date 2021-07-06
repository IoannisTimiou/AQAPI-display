using System;
using System.Collections.Generic;
using System.Text;

namespace AQAPI_display
{
    //model made to parse the results of the average JSON into a collection
    public class AverageAQResultsModel
    {
        public List<AverageAQModel> Results { get; set; }
    }
}
