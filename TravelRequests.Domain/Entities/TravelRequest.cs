using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelRequests.Domain.Entities
{
    public class TravelRequest
    {
        public int Id { get; set; }
        public string Destination { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = "Pending";

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
