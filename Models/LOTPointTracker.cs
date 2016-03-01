using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class LOTPointTracker
    {
        public int LOTPointTrackerID { get; set; }

        public int StudentID { get; set; }

        [Display(Name = "Session Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LOTMeetingDate { get; set; }

        [Display(Name = "Present?")]
        public bool AttendanceConfirmed { get; set; }

        [Display(Name = "On Time?")]
        public bool OnTimeConfirmed { get; set; }

        [Display(Name = "Current Event?")]
        public bool CurrentEventsConfirmed { get; set; }

        [Display(Name = "Participation?")]
        public bool ParticipationConfirmed { get; set; }

        [Display(Name = "Outside Event?")]
        public bool OutsideEventConfirmed { get; set; }

        [Display(Name = "Binder?")]
        public bool BinderConfirmed { get; set; }

        public virtual Student LOTStudent { get; set; }



    }
}