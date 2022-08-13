using ClinicManager.Application.Modules.PatientVitals.Commands;
using ClinicManager.Shared.DTO_s.Patients;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientVitalsController : BaseApiController<PatientVitalsController>
    {

        [HttpPut]
        public async Task<IActionResult> Edit(PatientVitalSignDTO patientVitalSign)
        {
            return Ok(await _mediator.Send(new EditPatientVitalSignCommand
            {
                VitalSignId     = patientVitalSign.VitalSignId,
                Temperature     = patientVitalSign.Temperature,
                LastTime        = patientVitalSign.LastTime,
                BodyMassIndex   = patientVitalSign.BodyMassIndex,
                Weight          = patientVitalSign.Weight,
                Height          = patientVitalSign.Height,
                BloodSaturation = patientVitalSign.BloodSaturation,
                RespitoryRate   = patientVitalSign.RespitoryRate,
                BloodPressure   = patientVitalSign.BloodPressure,
                Pulse           = patientVitalSign.Pulse,
                PatientId       = patientVitalSign.PatientId
            }));
        }

        [HttpPost("AddVisit")]
        public async Task<IActionResult> AddVisit(PatientVitalSignDTO patientVitalSign)
        {
            return Ok(await _mediator.Send(new AddPatientVitalSignCommand
            {
               VitalSignId     = patientVitalSign.VitalSignId,
               Temperature     = patientVitalSign.Temperature,
               LastTime        = patientVitalSign.LastTime,
               BodyMassIndex   = patientVitalSign.BodyMassIndex,
               Weight          = patientVitalSign.Weight,
               Height          = patientVitalSign.Height,
               BloodSaturation = patientVitalSign.BloodSaturation,
               RespitoryRate   = patientVitalSign.RespitoryRate,
               BloodPressure   = patientVitalSign.BloodPressure,
               Pulse           = patientVitalSign.Pulse,  
               PatientId       = patientVitalSign.PatientId
            }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeletePatientVitalSignCommand { Id = id }));
        }
    }
}
