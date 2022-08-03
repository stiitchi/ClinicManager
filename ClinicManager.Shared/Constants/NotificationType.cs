using System.ComponentModel;

namespace ClinicManager.Shared.Constants
{
    public enum NotificationType
    {
        [Description("Missed Record")]
        MissedRecord,
        [Description("Record Added")]
        RecordAdded,
        [Description("Scheduled Request")]
        ScheduledRequest,
        [Description("Patient Admitted")]
        PatientAdmitted,
        [Description("Patient Discharged")]
        PatientDischarged,
        [Description("Changes")]
        Changes,
    }
}
