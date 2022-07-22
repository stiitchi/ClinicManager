namespace ClinicManager.Web.Infrastructure.Routes
{
    public class ChartEndpoints
    {
        //Charts
        public static string AddBloodOxygenChart = "api/Chart/AddBloodOxygenChart";
        public static string AddBloodPressureChart = "api/Chart/AddBloodPressureChart";
        public static string AddHeartRateChart = "api/Chart/AddHeartRateChart";
        public static string AddRespitoryRateChart = "api/Chart/AddRespitoryRateChart";
        public static string AddTemperatureRate = "api/Chart/AddTemperatureRate";
        //Chart Entries
        public static string AddBloodOxygenChartEntry = "api/Chart/AddBloodOxygenChartEntry";
        public static string AddBloodPressureChartEntry = "api/Chart/AddBloodPressureChartEntry";
        public static string AddHeartRateChartEntry = "api/Chart/AddHeartRateChartEntry";
        public static string AddRespitoryRateChartEntry = "api/Chart/AddRespitoryRateChartEntry";
        public static string AddTemperatureRateChartEntry = "api/Chart/AddTemperatureRateChartEntry";
        //Get All
        public static string GetAllBloodOxygenCharts = "api/Chart/GetAllBloodOxygenCharts";
        public static string GetAllBloodPressureCharts = "api/Chart/GetAllBloodPressureCharts";
        public static string GetAllRespitoryCharts = "api/Chart/GetAllRespitoryCharts";
        public static string GetAllHeartRateCharts = "api/Chart/GetAllHeartRateCharts";
        public static string GetAllTemperatureCharts = "api/Chart/GetAllTemperatureCharts";
        //Get By ID
        public static string GetBloodOxygenChartsById(int id)
        {
            return $"api/Chart/GetBloodOxygenChartsById?id={id}";
        }

        public static string GetBloodPressureChartById(int id)
        {
            return $"api/Chart/GetBloodPressureChartById?id={id}";
        }

        public static string GetHeartRateChartById(int id)
        {
            return $"api/Chart/GetHeartRateChartById?id={id}";
        }

        public static string GetRespitoryRateChartById(int id)
        {
            return $"api/Chart/GetRespitoryRateChartById?id={id}";
        }

        public static string GetTemperatureChartById(int id)
        {
            return $"api/Chart/GetTemperatureChartById?id={id}";
        }

        //Get Chart Entries By Chart ID

        public static string GetAllBloodOxygenChartEntriesByBloodOxygenId(int bloodOxygenChartId)
        {
            return $"api/Chart/GetAllBloodOxygenChartEntriesByBloodOxygenId?bloodOxygenChartId={bloodOxygenChartId}";
        }

        public static string GetAllBloodPressureChartEntriesByBloodPressureId(int bloodPressureChartId)
        {
            return $"api/Chart/GetAllBloodPressureChartEntriesByBloodPressureId?bloodPressureChartId={bloodPressureChartId}";
        }

        public static string GetAllHeartRateChartEntriesByHeartRateId(int heartRateChartId)
        {
            return $"api/Chart/GetAllHeartRateChartEntriesByHeartRateId?heartRateChartId={heartRateChartId}";
        }

        public static string GetAllRespitoryChartEntriesByRespitoryId(int respitoryRateChartId)
        {
            return $"api/Chart/GetAllRespitoryChartEntriesByRespitoryId?respitoryRateChartId={respitoryRateChartId}";
        }

        public static string GetAllTemperatureChartEntriesByTemperatureId(int temperatureChartId)
        {
            return $"api/Chart/GetAllTemperatureChartEntriesByTemperatureId?temperatureChartId={temperatureChartId}";
        }
    }

}
