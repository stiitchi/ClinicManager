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
        Task<IResult<int>> AddBloodPressureChartEntry(BloodPressureChartEntryDTO request);
        Task<IResult<int>> AddHeartRateChartEntry(HeartRateChartEntryDTO request);
        Task<IResult<int>> AddRespitoryRateChartEntry(RespitoryRateChartEntryDTO request);
        Task<IResult<int>> AddTemperatureRateChartEntry(TemperatureRateEntryDTO request);

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


        Task<IResult<List<BloodOxygenChartEntryDTO>>> GetAllBloodOxygenChartEntriesByBloodOxygenId(int bloodOxygenChartId);
        Task<IResult<List<BloodPressureChartEntryDTO>>> GetAllBloodPressureChartEntriesByBloodPressureId(int bloodPressureChartId);
        Task<IResult<List<HeartRateChartEntryDTO>>> GetAllHeartRateChartEntriesByHeartRateId(int heartRateChartId);
        Task<IResult<List<RespitoryRateChartEntryDTO>>> GetAllRespitoryChartEntriesByRespitoryId(int respitoryRateChartId);
        Task<IResult<List<TemperatureRateEntryDTO>>> GetAllTemperatureChartEntriesByTemperatureId(int temperatureChartId);

    }
}
