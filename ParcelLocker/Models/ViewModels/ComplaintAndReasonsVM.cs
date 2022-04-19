using System.Collections.Generic;

namespace ParcelLocker.Models.ViewModels
{
    public class ComplaintAndReasonsVM
    {
        public ComplaintVM Complaint { get; set; }
        public IEnumerable<ComplaintReasonVM> Reasons { get; set; }

    }
}
