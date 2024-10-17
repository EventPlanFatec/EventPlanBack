using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.DTOs
{
    public class SalesReportDto
    {
        public decimal TotalRevenue { get; set; }
        public int VipTicketsSold { get; set; }
        public int GeneralTicketsSold { get; set; }
        public int TotalTicketsSold { get; set; }
    }
}
