# School Grading System

A C# console application that processes student scores from text files, assigns letter grades, and generates comprehensive grade reports with robust exception handling.

## Features

- **File Processing**: Reads student data from comma-separated text files
- **Grade Calculation**: Automatically assigns letter grades (A-F) based on score ranges
- **Exception Handling**: Comprehensive error handling for various file and data issues
- **Report Generation**: Creates detailed grade reports with statistics
- **Data Validation**: Ensures data integrity and proper format validation

## Architecture

### Core Components

#### Student Class
- **Fields**: `Id`, `FullName`, `Score`
- **Methods**: `GetGrade()` - Returns letter grade based on score ranges
- **Grading Scale**:
  - A: 80-100
  - B: 70-79
  - C: 60-69
  - D: 50-59
  - F: Below 50

#### Custom Exceptions
- **InvalidScoreFormatException**: Thrown when score cannot be parsed as integer
- **MissingFieldException**: Thrown when student record has incomplete data
- Both inherit from base `Exception` class with custom messages

#### StudentResultProcessor Class
- **ReadStudentsFromFile()**: Reads and validates student data from input file
- **WriteReportToFile()**: Generates comprehensive grade reports
- **File Handling**: Uses `using` statements with `StreamReader` and `StreamWriter`
- **Data Validation**: Comprehensive validation of all input fields

## Key Features Implemented

### 1. File Processing
- **Input Format**: Comma-separated values (ID, Name, Score)
- **Output Format**: Formatted grade report with statistics
- **Stream Management**: Proper resource disposal with `using` statements

### 2. Data Validation
- **Field Count**: Ensures exactly 3 fields per line
- **Score Parsing**: Validates score can be converted to integer
- **Score Range**: Ensures scores are between 0-100
- **Data Integrity**: Trims whitespace and validates all fields

### 3. Exception Handling
- **FileNotFoundException**: Handles missing input files
- **InvalidScoreFormatException**: Handles malformed score data
- **MissingFieldException**: Handles incomplete student records
- **General Exception**: Catches any unforeseen errors

### 4. Report Generation
- **Student Details**: Individual student scores and grades
- **Grade Distribution**: Statistical breakdown of grades
- **Timestamp**: Report generation date and time
- **Summary Statistics**: Total student count and processing details

## Input File Format

```
101,Alice Smith,84
102,Bob Johnson,72
103,Carol Davis,95
104,David Wilson,58
105,Eva Brown,67
```

## Output Report Format

```
=== Student Grade Report ===
Generated on: 2025-08-15 13:30:00
Total Students: 5

Alice Smith (ID: 101): Score = 84, Grade = A
Bob Johnson (ID: 102): Score = 72, Grade = B
Carol Davis (ID: 103): Score = 95, Grade = A
David Wilson (ID: 104): Score = 58, Grade = D
Eva Brown (ID: 105): Score = 67, Grade = C

=== Grade Distribution ===
Grade A: 2 student(s)
Grade B: 1 student(s)
Grade C: 1 student(s)
Grade D: 1 student(s)
```

## How to Run

1. Ensure you have .NET 9.0 SDK installed
2. Navigate to the project directory
3. Run the following commands:

```bash
dotnet build
dotnet run
```

## Sample Data

The system automatically creates a sample input file (`students_input.txt`) if none exists, containing 8 sample student records with various scores to demonstrate the grading system.

## Error Handling Examples

- **Missing File**: Graceful handling of non-existent input files
- **Invalid Score**: Proper error messages for non-numeric scores
- **Missing Fields**: Clear indication of incomplete data records
- **Out of Range**: Validation of score boundaries (0-100)

## Design Patterns Used

- **Exception Handling Pattern**: Comprehensive error management
- **File I/O Pattern**: Proper resource management with `using` statements
- **Data Validation Pattern**: Input sanitization and validation
- **Report Generation Pattern**: Structured output formatting
