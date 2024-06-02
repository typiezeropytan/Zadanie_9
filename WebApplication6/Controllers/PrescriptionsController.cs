using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Context;
using WebApplication6.DTO;

namespace WebApplication6.Controllers;

[Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly MasterContext _context;

        public PrescriptionsController(MasterContext context)
        {
            _context = context;
        }

        // GET: api/Prescriptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrescriptionDetailsResponse>> GetPrescription(int id)
        {
            var prescription = await _context.Prescriptions
                .Include(p => p.IdPatientNavigation)
                .Include(p => p.IdDoctorNavigation)
                .Include(p => p.PrescriptionMedicaments)
                    .ThenInclude(pm => pm.IdMedicamentNavigation)
                .FirstOrDefaultAsync(p => p.IdPrescription == id);

            if (prescription == null)
            {
                return NotFound();
            }

            var response = new PrescriptionDetailsResponse
            {
                IdPrescription = prescription.IdPrescription,
                Date = prescription.Date,
                DueDate = prescription.DueDate,
                Patient = new PatientDetails
                {
                    IdPatient = prescription.IdPatientNavigation.IdPatient,
                    FirstName = prescription.IdPatientNavigation.FirstName,
                    LastName = prescription.IdPatientNavigation.LastName,
                    Birthdate = prescription.IdPatientNavigation.Birthdate
                },
                Doctor = new DoctorDetails
                {
                    IdDoctor = prescription.IdDoctorNavigation.IdDoctor,
                    FirstName = prescription.IdDoctorNavigation.FirstName,
                    LastName = prescription.IdDoctorNavigation.LastName,
                    Email = prescription.IdDoctorNavigation.Email
                },
                Medicaments = prescription.PrescriptionMedicaments.Select(pm => new MedicamentDetails
                {
                    IdMedicament = pm.IdMedicamentNavigation.IdMedicament,
                    Name = pm.IdMedicamentNavigation.Name,
                    Description = pm.IdMedicamentNavigation.Description,
                    Type = pm.IdMedicamentNavigation.Type,
                    Dose = pm.Dose,
                    Details = pm.Details
                }).ToList()
            };

            return response;
        }
    }