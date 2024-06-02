namespace WebApplication6.DTO;

public class PrescriptionDetailsResponse
{
    public int IdPrescription { get; set; }
    public DateOnly Date { get; set; }
    public DateOnly DueDate { get; set; }
    public PatientDetails Patient { get; set; }
    public DoctorDetails Doctor { get; set; }
    public List<MedicamentDetails> Medicaments { get; set; }
}