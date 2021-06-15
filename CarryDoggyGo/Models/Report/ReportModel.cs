using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarryDoggyGo.Models.Report
{
    public class ReportModel
    {
        public int ReportId { get; set; }
        public string Description { get; set; }
        public int DogWalkId { get; set; }
    }
}
