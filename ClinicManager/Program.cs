using ClinicManager.Web.Infrastructure.Services.Admission;
using ClinicManager.Web.Infrastructure.Services.Bed;
using ClinicManager.Web.Infrastructure.Services.Chart;
using ClinicManager.Web.Infrastructure.Services.DayFees;
using ClinicManager.Web.Infrastructure.Services.Doctor;
using ClinicManager.Web.Infrastructure.Services.ICDCode;
using ClinicManager.Web.Infrastructure.Services.Nurses;
using ClinicManager.Web.Infrastructure.Services.Patient;
using ClinicManager.Web.Infrastructure.Services.PatientRecords;
using ClinicManager.Web.Infrastructure.Services.State;
using ClinicManager.Web.Infrastructure.Services.Ward;
using MudBlazor.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
const string ClientName = "ClinicManager.API";

var config = builder.Configuration;

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor().AddHubOptions(config => config.MaximumReceiveMessageSize = 1048576);
builder.Services.AddMudServices();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddScoped<IAdmissionService, AdmissionService>();
builder.Services.AddScoped<IBedService, BedService>();
builder.Services.AddScoped<IDayFeesService, DayFeesService>();
builder.Services.AddScoped<IICDCodeService, ICDCodeService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<INurseService, NurseService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IChartService, ChartService>();
builder.Services.AddScoped<IPatientRecordService, PatientRecordService>();
builder.Services.AddScoped<IWardService, WardService>();
builder.Services.AddScoped(sp => sp
             .GetRequiredService<IHttpClientFactory>()
             .CreateClient(ClientName))
             .AddHttpClient(ClientName, client =>
             {
                 client.DefaultRequestHeaders.AcceptLanguage.Clear();
                 client.DefaultRequestHeaders.AcceptLanguage.ParseAdd(CultureInfo.DefaultThreadCurrentCulture?.TwoLetterISOLanguageName);
                 client.BaseAddress = new Uri(config.GetSection("Url").Value);
             });



var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseExceptionHandler("/Error");
app.UseHsts();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
});


app.Run();
