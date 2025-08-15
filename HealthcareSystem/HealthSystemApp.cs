using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthcareSystem
{
    public class HealthSystemApp
    {
        private Repository<Patient> _patientRepo;
        private Repository<Prescription> _prescriptionRepo;
        private Dictionary<int, List<Prescription>> _prescriptionMap;
        
        public HealthSystemApp()
        {
            _patientRepo = new Repository<Patient>();
            _prescriptionRepo = new Repository<Prescription>();
            _prescriptionMap = new Dictionary<int, List<Prescription>>();
        }
        
        public void SeedData()
        {
            // Add 2-3 Patient objects
            _patientRepo.Add(new Patient(1, "John Smith", 35, "Male"));
            _patientRepo.Add(new Patient(2, "Sarah Johnson", 28, "Female"));
            _patientRepo.Add(new Patient(3, "Michael Brown", 42, "Male"));
            
            // Add 4-5 Prescription objects with valid PatientIds
            _prescriptionRepo.Add(new Prescription(1, 1, "Aspirin", DateTime.Now.AddDays(-30)));
            _prescriptionRepo.Add(new Prescription(2, 1, "Ibuprofen", DateTime.Now.AddDays(-15)));
            _prescriptionRepo.Add(new Prescription(3, 2, "Amoxicillin", DateTime.Now.AddDays(-20)));
            _prescriptionRepo.Add(new Prescription(4, 2, "Paracetamol", DateTime.Now.AddDays(-10)));
            _prescriptionRepo.Add(new Prescription(5, 3, "Omeprazole", DateTime.Now.AddDays(-5)));
        }
        
        public void BuildPrescriptionMap()
        {
            _prescriptionMap.Clear();
            
            // Loop through all prescriptions and group them by PatientId
            var allPrescriptions = _prescriptionRepo.GetAll();
            
            foreach (var prescription in allPrescriptions)
            {
                if (!_prescriptionMap.ContainsKey(prescription.PatientId))
                {
                    _prescriptionMap[prescription.PatientId] = new List<Prescription>();
                }
                _prescriptionMap[prescription.PatientId].Add(prescription);
            }
        }
        
        public void PrintAllPatients()
        {
            Console.WriteLine("=== All Patients ===");
            var patients = _patientRepo.GetAll();
            
            foreach (var patient in patients)
            {
                Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}, Gender: {patient.Gender}");
            }
            Console.WriteLine();
        }
        
        public void PrintPrescriptionsForPatient(int patientId)
        {
            if (_prescriptionMap.ContainsKey(patientId))
            {
                var prescriptions = _prescriptionMap[patientId];
                var patient = _patientRepo.GetById(p => p.Id == patientId);
                
                if (patient != null)
                {
                    Console.WriteLine($"=== Prescriptions for {patient.Name} (ID: {patientId}) ===");
                    foreach (var prescription in prescriptions)
                    {
                        Console.WriteLine($"Prescription ID: {prescription.Id}, Medication: {prescription.MedicationName}, Date Issued: {prescription.DateIssued:MM/dd/yyyy}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"No prescriptions found for Patient ID: {patientId}");
            }
            Console.WriteLine();
        }
        
        public List<Prescription> GetPrescriptionsByPatientId(int patientId)
        {
            if (_prescriptionMap.ContainsKey(patientId))
            {
                return _prescriptionMap[patientId];
            }
            return new List<Prescription>();
        }
    }
}
