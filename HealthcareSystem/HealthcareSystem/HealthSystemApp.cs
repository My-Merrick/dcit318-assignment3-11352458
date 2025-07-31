using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthcareSystem
{
    public class HealthSystemApp
    {
        private Repository<Patient> _patientRepo = new Repository<Patient>();
        private Repository<Prescription> _prescriptionRepo = new Repository<Prescription>();
        private Dictionary<int, List<Prescription>> _prescriptionMap = new Dictionary<int, List<Prescription>>();

        public void SeedData()
        {
            // Add Patients
            _patientRepo.Add(new Patient(1, "Alice Smith", 30, "Female"));
            _patientRepo.Add(new Patient(2, "Bob Johnson", 45, "Male"));
            _patientRepo.Add(new Patient(3, "Clara Daniels", 29, "Female"));

            // Add Prescriptions
            _prescriptionRepo.Add(new Prescription(1, 1, "Amoxicillin", DateTime.Now.AddDays(-10)));
            _prescriptionRepo.Add(new Prescription(2, 1, "Paracetamol", DateTime.Now.AddDays(-5)));
            _prescriptionRepo.Add(new Prescription(3, 2, "Ibuprofen", DateTime.Now.AddDays(-7)));
            _prescriptionRepo.Add(new Prescription(4, 3, "Cetirizine", DateTime.Now.AddDays(-2)));
            _prescriptionRepo.Add(new Prescription(5, 3, "Omeprazole", DateTime.Now.AddDays(-1)));
        }

        public void BuildPrescriptionMap()
        {
            var prescriptions = _prescriptionRepo.GetAll();
            _prescriptionMap = prescriptions
                .GroupBy(p => p.PatientId)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public void PrintAllPatients()
        {
            Console.WriteLine("\nAll Patients:");
            foreach (var patient in _patientRepo.GetAll())
            {
                Console.WriteLine(patient);
            }
        }

        public void PrintPrescriptionsForPatient(int patientId)
        {
            if (_prescriptionMap.ContainsKey(patientId))
            {
                Console.WriteLine($"\nPrescriptions for Patient ID {patientId}:");
                foreach (var prescription in _prescriptionMap[patientId])
                {
                    Console.WriteLine(prescription);
                }
            }
            else
            {
                Console.WriteLine($"No prescriptions found for Patient ID {patientId}.");
            }
        }
    }
}
