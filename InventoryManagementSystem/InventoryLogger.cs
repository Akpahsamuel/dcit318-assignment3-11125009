using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace InventoryManagementSystem
{
    public class InventoryLogger<T> where T : IInventoryEntity
    {
        private List<T> _log;
        private string _filePath;
        
        public InventoryLogger(string filePath)
        {
            _log = new List<T>();
            _filePath = filePath;
        }
        
        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Item cannot be null");
                
            _log.Add(item);
        }
        
        public List<T> GetAll()
        {
            return new List<T>(_log);
        }
        
        public void SaveToFile()
        {
            try
            {
                using (var writer = new StreamWriter(_filePath))
                {
                    foreach (var item in _log)
                    {
                        // Save as JSON for better data preservation
                        string jsonLine = JsonSerializer.Serialize(item);
                        writer.WriteLine(jsonLine);
                    }
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new InvalidOperationException($"Directory not found for file path: {_filePath}", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new InvalidOperationException($"Access denied to file: {_filePath}", ex);
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException($"I/O error occurred while saving to file: {_filePath}", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Unexpected error while saving to file: {_filePath}", ex);
            }
        }
        
        public void LoadFromFile()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    throw new FileNotFoundException($"Inventory file not found: {_filePath}");
                }
                
                _log.Clear();
                
                using (var reader = new StreamReader(_filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            try
                            {
                                // Deserialize from JSON
                                var item = JsonSerializer.Deserialize<T>(line);
                                if (item != null)
                                {
                                    _log.Add(item);
                                }
                            }
                            catch (JsonException ex)
                            {
                                // Log the error but continue processing other lines
                                Console.WriteLine($"Warning: Could not deserialize line: {line}. Error: {ex.Message}");
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new InvalidOperationException($"Inventory file not found: {_filePath}", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new InvalidOperationException($"Access denied to file: {_filePath}", ex);
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException($"I/O error occurred while loading from file: {_filePath}", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Unexpected error while loading from file: {_filePath}", ex);
            }
        }
        
        public void ClearLog()
        {
            _log.Clear();
        }
        
        public int GetItemCount()
        {
            return _log.Count;
        }
    }
}
