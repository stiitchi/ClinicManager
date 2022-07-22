using ClinicManager.Shared.DTO_s.Charts;
using ClinicManager.Shared.DTO_s.Charts.ChartEntry;
using ClinicManager.Shared.Wrappers;
using ClinicManager.Web.Infrastructure.Extensions;
using ClinicManager.Web.Infrastructure.Services.State;
using System.Net.Http.Json;

namespace ClinicManager.Web.Infrastructure.Services.Chart
{
    public class ChartService : BaseService, IChartService
    {
        public ChartService(HttpClient httpClient, IStateService stateService) : base(httpClient, stateService)
        {
        }

        public async Task<IResult<int>> AddBloodOxygenChart(BloodOxygenDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.ChartEndpoints.AddBloodOxygenChart, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddBloodOxygenChartEntry(BloodOxygenChartEntryDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.ChartEndpoints.AddBloodOxygenChartEntry, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddBloodPressureChart(BloodPressureDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.ChartEndpoints.AddBloodPressureChart, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddHeartRateChart(HeartRateDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.ChartEndpoints.AddHeartRateChart, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddRespitoryRateChart(RespitoryChartDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.ChartEndpoints.AddRespitoryRateChart, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddTemperatureRate(TemperatureRateDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.ChartEndpoints.AddTemperatureRate, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<BloodOxygenDTO>>> GetAllBloodOxygenChart()
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.ChartEndpoints.GetAllBloodOxygenCharts);
            return await response.ToResult<List<BloodOxygenDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<BloodPressureDTO>>> GetAllBloodPressureChart()
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.ChartEndpoints.GetAllBloodPressureCharts);
            return await response.ToResult<List<BloodPressureDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<HeartRateDTO>>> GetAllHeartRateChart()
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.ChartEndpoints.GetAllHeartRateCharts);
            return await response.ToResult<List<HeartRateDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<RespitoryChartDTO>>> GetAllRespitoryRateChart()
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.ChartEndpoints.GetAllRespitoryCharts);
            return await response.ToResult<List<RespitoryChartDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<TemperatureRateDTO>>> GetAllTemperatureRate()
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.ChartEndpoints.GetAllTemperatureCharts);
            return await response.ToResult<List<TemperatureRateDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<BloodOxygenDTO>> GetBloodOxygenChartById(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.ChartEndpoints.GetBloodOxygenChartsById(id));
            return await response.ToResult<BloodOxygenDTO>();
        }

        public async Task<IResult<BloodPressureDTO>> GetBloodPressureChartById(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.ChartEndpoints.GetBloodPressureChartById(id));
            return await response.ToResult<BloodPressureDTO>();
        }

        public async Task<IResult<HeartRateDTO>> GetHeartRateChartById(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.ChartEndpoints.GetHeartRateChartById(id));
            return await response.ToResult<HeartRateDTO>();
        }

        public async Task<IResult<RespitoryChartDTO>> GetRespitoryChartById(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.ChartEndpoints.GetRespitoryRateChartById(id));
            return await response.ToResult<RespitoryChartDTO>();
        }

        public async Task<IResult<TemperatureRateDTO>> GetTemperatureRateById(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.ChartEndpoints.GetTemperatureChartById(id));
            return await response.ToResult<TemperatureRateDTO>();
        }
    }
}
