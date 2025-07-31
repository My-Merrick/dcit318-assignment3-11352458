using System;

namespace HealthcareSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new HealthSystemApp();
            app.SeedData();
            app.BuildPrescriptionMap();
            app.PrintAllPatients();

            Console.Write("\nEnter a Patient ID to view prescriptions: ");
            if (int.TryParse(Console.ReadLine(), out int patientId))
            {
                app.PrintPrescriptionsForPatient(patientId);
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

            Console.ReadKey();
        }
    }
}
