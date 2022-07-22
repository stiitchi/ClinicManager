using ClinicManager.Shared.DTO_s.Charts;
using ClinicManager.Shared.DTO_s.Charts.ChartEntry;
using ClinicManager.Shared.Wrappers;

namespace ClinicManager.Web.Infrastructure.Services.Chart
{
    public interface IChartService
    {
        Task<IResult<int>> AddBloodOxygenChart(BloodOxygenDTO request);
        Task<IResult<int>> AddBloodPressureChart(BloodPressureDTO request);
        Task<IResult<int>> AddHeartRateChart(HeartRateDTO request);
        Task<IResult<int>> AddRespitoryRateChart(RespitoryChartDTO request);
        Task<IResult<int>> AddTemperatureRate(TemperatureRateDTO request);

        Task<IResult<int>> AddBloodOxygenChartEntry(BloodOxygenChartEntryDTO request);

        Task<IResult<List<BloodOxygenDTO>>> GetAllBloodOxygenChart();
        Task<IResult<List<BloodPressureDTO>>> GetAllBloodPressureChart();
        Task<IResult<List<HeartRateDTO>>> GetAllHeartRateChart();
        Task<IResult<List<RespitoryChartDTO>>> GetAllRespitoryRateChart();
        Task<IResult<List<TemperatureRateDTO>>> GetAllTemperatureRate();


        Task<IResult<BloodOxygenDTO>> GetBloodOxygenChartById(int id);
        Task<IResult<BloodPressureDTO>> GetBloodPressureChartById(int id);
        Task<IResult<HeartRateDTO>> GetHeartRateChartById(int id);
        Task<IResult<RespitoryChartDTO>> GetRespitoryChartById(int id);
        Task<IResult<TemperatureRateDTO>> GetTemperatureRateById(int id);


    }
}
