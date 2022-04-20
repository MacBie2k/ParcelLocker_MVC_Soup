using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ParcelLocker.Models.ViewModels
{
    public class ComplaintReasonVM
    {
        public ComplaintVM Complaint { get; set; }
        public IEnumerable<ReasonVM> Reasons { get; set; }
        public List<SelectListItem> SelectedReasons { get; set; }

    }
}
