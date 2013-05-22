using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ServiceRequest
    {
        public Guid Id { get; set; }
        public string PickupPhoneNumber { get; set; }
        public string PickupLocation { get; set; }
        public ServiceRequestStatus Status { get; set; }
        public string Taxi { get; set; }

        public ServiceRequest(string phone, string location)
        {
            Id = Guid.NewGuid();
            PickupLocation = location;
            PickupPhoneNumber = phone;
            Status = ServiceRequestStatus.Pending;
        }

        public void Cancel()
        {
            Status = ServiceRequestStatus.Canceled;
        }

        public void Open()
        {
            Status = ServiceRequestStatus.Open;
        }

        public void Close()
        {
            Status = ServiceRequestStatus.Closed;
        }
    }

    public enum ServiceRequestStatus { 
        Pending,
        Canceled,
        Assigned,
        Open,
        Closed
    }
}
