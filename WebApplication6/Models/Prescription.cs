using System;
using System.Collections.Generic;

namespace WebApplication6.Models;

public partial class Prescription
{
    public int IdPrescription { get; set; }

    public DateOnly Date { get; set; }

    public DateOnly DueDate { get; set; }

    public int IdPatient { get; set; }

    public int IdDoctor { get; set; }

    public virtual Doctor IdDoctorNavigation { get; set; } = null!;

    public virtual Patient IdPatientNavigation { get; set; } = null!;

    public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; } = new List<PrescriptionMedicament>();
}
