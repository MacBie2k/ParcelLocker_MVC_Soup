using ParcelLocker.Models.Entities;

namespace ParcelLocker.Models.ModelViews
{
    public enum Status
    {
        nadana,wyslana,dostarczona,odebrana,zwrocona
    }

    public class ParcelVM
    {
        public string ParcelNumber { get; set; }
        public string PickupCode { get; set; }
        public string SenderPhone { get; set; }
        public string SenderEmail { get; set; }
        public string ReceiverPhone { get; set; }
        public string ReceiverEmail { get; set; }
        public Status Status { get; set; }
        public string LockerCode { get; set; }
    }

}
