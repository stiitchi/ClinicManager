namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Observations
{ 
    public class NeurovascularEntity : EntityBase
    {
    public NeurovascularEntity()
    { }
    public NeurovascularEntity(DateTime time, int frequency, string signature, string recordType, PatientEntity patient)
    {
        _neuroVascularTime = time;
        _neuroVascularFrequency = frequency;
        _neuroVascularSignature = signature;
        _recordType = recordType;
        _patientId = patient.Id;
    }

    private DateTime _neuroVascularTime;
    public DateTime NeuroVascularTime => _neuroVascularTime;

    private int _neuroVascularFrequency;
    public int NeuroVascularFrequency => _neuroVascularFrequency;

    private string _neuroVascularSignature;
    public string NeuroVascularSignature => _neuroVascularSignature;


    private string _recordType;
    public string RecordType => _recordType;

    public PatientEntity Patient;
    private int _patientId;
    public int PatientId => _patientId;
    }
}
