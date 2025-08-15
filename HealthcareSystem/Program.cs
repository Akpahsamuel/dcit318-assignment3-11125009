using System;

namespace HealthcareSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Healthcare System ===");
            Console.WriteLine();
            
            // i. Instantiate HealthSystemApp
            var healthSystem = new HealthSystemApp();
            
            // ii. Call SeedData()
            Console.WriteLine("Seeding data...");
            healthSystem.SeedData();
            Console.WriteLine("Data seeded successfully!");
            Console.WriteLine();
            
            // iii. Call BuildPrescriptionMap()
            Console.WriteLine("Building prescription map...");
            healthSystem.BuildPrescriptionMap();
            Console.WriteLine("Prescription map built successfully!");
            Console.WriteLine();
            
            // iv. Print all patients
            healthSystem.PrintAllPatients();
            
            // v. Select one PatientId and display all prescriptions for that patient
            Console.WriteLine("Selecting Patient ID 2 to display prescriptions...");
            healthSystem.PrintPrescriptionsForPatient(2);
            
            // Bonus: Show prescriptions for another patient
            Console.WriteLine("Showing prescriptions for Patient ID 1...");
            healthSystem.PrintPrescriptionsForPatient(1);
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
