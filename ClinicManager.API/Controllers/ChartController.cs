using ClinicManager.Application.Modules.ChartEntry.Command;
using ClinicManager.Application.Modules.Charts.Commands;
using ClinicManager.Application.Modules.Charts.Queries;
using ClinicManager.Shared.DTO_s.Charts;
using ClinicManager.Shared.DTO_s.Charts.ChartEntry;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : BaseApiController<ChartController>
    {
        [HttpPost("AddBloodOxygenChart")]
        public async Task<IActionResult> AddBloodOxygenChart(BloodOxygenDTO bloodOxygen)
        {
            return Ok(await _mediator.Send(new AddBloodOxygenChartCommand
            {
             BloodOxygenChartId = bloodOxygen.BloodOxygenChartId,
             BloodOxygenChartEntry = bloodOxygen.BloodOxygenChartEntry,
             Time = bloodOxygen.Time,
             PatientId = bloodOxygen.PatientId
            }));
        }

        [HttpPost("AddBloodOxygenChartEntry")]
        public async Task<IActionResult> AddBloodOxygenChartEntry(BloodOxygenChartEntryDTO bloodOxygenEntry)
        {
            return Ok(await _mediator.Send(new AddBloodOxygenChartEntryCommand
            {
                BloodOxygenChartId = bloodOxygenEntry.BloodOxygenChartEntryId,
                BloodOxygenChartEntry = bloodOxygenEntry.BloodOxygenChartEntry
            }));
        }
        

        [HttpPost("AddBloodPressureChart")]
        public async Task<IActionResult> AddBloodPressureChart(BloodPressureDTO bloodPressure)
        {
            return Ok(await _mediator.Send(new AddBloodPressureChartCommand
            {
                BloodPressureChartId = bloodPressure.BloodPressureChartId,
                BloodPressureChartEntry = bloodPressure.BloodPressureChartEntry,
                Time = bloodPressure.Time,
                PatientId = bloodPressure.PatientId
            }));
        }

        [HttpPost("AddHeartRateChart")]
        public async Task<IActionResult> AddHeartRateChart(HeartRateDTO heartRate)
        {
            return Ok(await _mediator.Send(new AddHeartRateChartCommand
            {
                HeartRateChartId = heartRate.HeartRateChartId,
                HeartRateChartEntry = heartRate.HeartRateChartEntry,
                Time = heartRate.Time,
                PatientId = heartRate.PatientId
            }));
        }

        [HttpPost("AddRespitoryRateChart")]
        public async Task<IActionResult> AddRespitoryRateChart(RespitoryChartDTO respitoryChart)
        {
            return Ok(await _mediator.Send(new AddRespitoryRateChartCommand
            {
                RespitoryChartId = respitoryChart.RespitoryChartId,
                RespitoryChartEntry = respitoryChart.RespitoryChartEntry,
                Time = respitoryChart.Time,
                PatientId = respitoryChart.PatientId
            }));
        }

        [HttpPost("AddTemperatureRate")]
        public async Task<IActionResult> AddTemperatureRate(TemperatureRateDTO temperatureRate)
        {
            return Ok(await _mediator.Send(new AddTemperatureRateCommand
            {
                TempRatetId = temperatureRate.TempRatetId,
                TempRateEntry = temperatureRate.TempRateEntry,
                Time = temperatureRate.Time,
                PatientId = temperatureRate.PatientId
            }));
        }

        [HttpGet("GetAllBloodOxygenCharts")]
        public async Task<IActionResult> GetAllBloodOxygenCharts()
        {
            return Ok(await _mediator.Send(new GetAllBloodOxygenChartsQuery { }));
        }

        [HttpGet("GetAllBloodPressureCharts")]
        public async Task<IActionResult> GetAllBloodPressureCharts()
        {
            return Ok(await _mediator.Send(new GetAllBloodPressureChartsQuery { }));
        }

        [HttpGet("GetAllRespitoryCharts")]
        public async Task<IActionResult> GetAllRespitoryCharts()
        {
            return Ok(await _mediator.Send(new GetAllRespitoryChartsQuery { }));
        }

        [HttpGet("GetAllHeartRateCharts")]
        public async Task<IActionResult> GetAllHeartRateCharts()
        {
            return Ok(await _mediator.Send(new GetAllHeartRateChartsQuery { }));
        }

        [HttpGet("GetAllTemperatureCharts")]
        public async Task<IActionResult> GetAllTemperatureCharts()
        {
            return Ok(await _mediator.Send(new GetAllTemperatureChartsQuery { }));
        }

        [HttpGet("GetBloodOxygenChartsById")]
        public async Task<IActionResult> GetBloodOxygenChartsById(int id)
        {
            return Ok(await _mediator.Send(new GetBloodOxygenChartsByIdQuery { Id = id }));
        }

        [HttpGet("GetBloodPressureChartById")]
        public async Task<IActionResult> GetBloodPressureChartById(int id)
        {
            return Ok(await _mediator.Send(new GetBloodPressureChartByIdQuery { Id = id }));
        }

        [HttpGet("GetHeartRateChartById")]
        public async Task<IActionResult> GetHeartRateChartById(int id)
        {
            return Ok(await _mediator.Send(new GetHeartRateChartByIdQuery { Id = id }));
        }

        [HttpGet("GetRespitoryRateChartById")]
        public async Task<IActionResult> GetRespitoryRateChartById(int id)
        {
            return Ok(await _mediator.Send(new GetRespitoryRateChartByIdQuery { Id = id }));
        }

        [HttpGet("GetTemperatureChartById")]
        public async Task<IActionResult> GetTemperatureChartById(int id)
        {
            return Ok(await _mediator.Send(new GetTemperatureChartByIdQuery { Id = id }));
        }
    }
}
