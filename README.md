# StudentSorter

A web application built with C# and .NET Core to upload, sort, and display student data using various sorting algorithms. The application allows users to upload a CSV file, select a column to sort by, and view the sorted results using different sorting algorithms. This application is built to analyse different sorting algorithms and how they perform on different types of Data.

## Features

- Upload a CSV file with student data
- Select a column to sort the data by
- View sorting results using different algorithms:
  - Insertion Sort
  - Selection Sort
  - Bubble Sort
  - Merge Sort
  - Quick Sort

## Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) (version 3.1 or later)

## Setup

1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/StudentSorter.git
    cd StudentSorter
    ```

2. Build the project:
    ```bash
    dotnet build
    ```

3. Run the project:
    ```bash
    dotnet run
    ```

4. Open your browser and navigate to the local uri that is given in the output (in Terminal).

## Usage

1. On the homepage, upload a CSV file with any data.
2. Enter the number of columns in the CSV file and click "Upload".
3. Select the column to sort the data by and click "Sort Data".
4. View the sorted results using different algorithms.

### Example CSV File

The example CSV file called the student.csv is provided for you to download and test it. 

**students.csv**
```csv
ID,Name,Age,Grade
1,John Doe,20,A
2,Jane Smith,22,B
3,Emily Davis,21,A-
4,Michael Brown,23,C+
5,Chris Green,20,B+
