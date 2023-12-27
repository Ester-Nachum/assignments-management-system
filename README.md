# Assignments Management System

## Overview

This project involves the development of a task management system. The system will display a list of tasks and allow users to create, update, or delete tasks.

## Exercise Description

### Task Definition

A task can fall into one of three categories:
- Personal Task
- Work Task
- Learning Task

Additionally, a task can be either recurring or one-time. It must have a start time, and it may or may not have a specified end date. Each task must have a name, and a description is optional. Tasks can be marked as "completed."

### Project Structure

The exercise comprises two projects:

1. **Assignments.API** - ASP.Net Core Project (using .Net Core 2.2 and above)
2. **Assignments.Client** - Angular Project (using Angular 10 and above)

### Assignments.API Highlights

1. **Service Requirements:**
   - Create a new task service.
   - Update a task status as "completed."
   - Delete a task.
   - Retrieve all relevant tasks in descending order of dates.
   - Retrieve a specific task.
   - Retrieve task types.

2. **Implementation Details:**
   - Utilize Entity Framework Core + Migrations.
   - Pay attention to clean C# coding, design patterns, and interfaces.
   - Consider using SQL Server Express as the DB provider (free download).

3. **Bonus:**
   - Implement Paged List for the service retrieving all tasks.

### Assignments.Client Highlights

1. **Dependencies:**
   - Use PrimeNg library for UI components.

2. **Screens to Build:**

   - **Task Table Screen:**
     - Display relevant tasks in a grid.
     - Include columns for:
       - Unique task ID
       - Task type
       - Task name
       - Task description
       - Start date
       - End date
       - Recurring indicator
       - Checkbox for marking tasks as completed
       - Button for updating task status based on the checkbox
       - Button for deleting a task
     - Include a button above the table leading to the "Create New Task" screen.

   - **New Task Form Screen:**
     - Include a back button to return to the previous screen.
     - Create a request form using Reactive Forms with validation.
     - Use text, date, and dropdown components for selection fields.
     - Include a "Submit" button at the end of the form, enabled only after passing validation.
     - After submitting, return to the task table screen to view the new task.

3. **Implementation Details:**
   - Use RxJs.
   - Communicate with the API.
   - Utilize PrimeNg library capabilities.
   - Leverage TypeScript features.
   - Focus on a clear and organized structure rather than elaborate design.

4. **Bonus:**
   - Implement column sorting in the table, allowing ascending and descending order based on column headers.

## Instructions

1. Clone the repository.
2. Set up and run the Assignments.API project.
3. Set up and run the Assignments.Client project.
4. Test the functionality of task creation, update, and deletion.

Feel free to reach out for any clarifications or assistance!
