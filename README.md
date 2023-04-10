# Employee Scheduling App

## Overview
The Employee Scheduling App is a software application designed to parse input files containing employee schedules and generate pairs of employees and how often they have coincided in the office. It provides a simple and efficient way to track and analyze employee overlaps in their schedules for businesses or organizations.

## Architecture
The Employee Scheduling App follows a simple and modular architecture with the following components:

1. Models: This component includes the Employee class, which represents an employee with their schedule information, and the TimeRange class, which represents a time range in the schedule.

2. Parsers: This component includes the ScheduleParser class, which is responsible for parsing input files. It reads the input file line by line and extracts employee names and their schedules.

3. ScheduleChecker: This component includes the ScheduleChecker class, which is responsible for checking coincidences between employees schedules. 

4. Example Files: This component includes example1.txt and example2.txt, which are sample input files containing employee schedules for testing and demonstration purposes.

The EmployeeSchedulingTests project includes unit tests for the components in the EmployeeSchedulingApp project, along with sample input files (input.txt, invalid_input.txt, invalid_dayofweek_input.txt) used for testing.

## Approach and Methodology
The approach used in the Employee Scheduling App is to provide a simple and efficient solution for tracking employee overlaps in their schedules.

The methodology followed for development includes:

1. Requirement analysis: Understanding the requirements of the application, including parsing input files, processing employee schedules, and couting coincidences between employees schedules.

2. Design and implementation: Developing the ScheduleParser and ScheduleChecker components using efficient data structures and algorithmss.

3. Testing: Writing unit tests to ensure code quality and reliability. Tests cover various scenarios, including valid and invalid input files, different schedule formats, and edge cases.

4. Refactoring: Reviewing and refactoring the code to improve performance, maintainability, and error handling.

## Instructions for Running the Program Locally
To run the Employee Scheduling App locally, follow these steps:

1. Clone the repository to your local machine.

2. Open the solution in Microsoft Visual Studio or any other compatible C# IDE.

3. Build the solution to ensure that all dependencies are resolved.

4. Run the unit tests to verify the functionality of the components.

5. Run the application.

## Conclusion
The Employee Scheduling App provides a simple and efficient solution for tracking employee overlaps in their schedules. It follows a straightforward architecture, uses standard coding practices, and includes comprehensive unit tests to ensure code quality and reliability. By following the instructions provided, you can easily run the program locally and integrate it into your own application. If you encounter any issues or have questions, please refer to the documentation or contact the development team for assistance.

