# Task Tracker CLI

A simple and efficient Command Line Interface (CLI) application to track and manage tasks. Built entirely from scratch using vanilla C# to demonstrate solid software architecture and native file system operations.

This project is a solution to the [Task Tracker CLI project](https://roadmap.sh/projects/task-tracker) on roadmap.sh.

## Features

- Add a new task with a description.
- Update an existing task's description.
- Delete a task by its ID.
- Mark a task's status as `in-progress` or `done`.
- List all tasks.
- List tasks filtered by status (`todo`, `in-progress`, `done`).

## Tech Stack & Architecture

- **Language:** C# (.NET)
- **Data Storage:** Native File System (`System.IO`) and JSON (`System.Text.Json`).
- **Architecture Highlights:**
  - **Command Design Pattern:** Replaced complex `switch-case` statements with a scalable Command Pattern and Dictionary-based routing.
  - **Pure Dependency Injection:** Implemented manual dependency injection via constructors to adhere to the Dependency Inversion Principle.
  - **SOLID Principles:** Ensured the Open/Closed Principle (OCP) by making the application open for new commands but closed for modification.

## Getting Started

### Prerequisites

- .NET SDK installed on your machine.

### Installation

1. Clone the repository:
   ```bash
   git clone [https://github.com/tanloc04/task-tracker-cli.git](https://github.com/tanloc04/task-tracker-cli.git)
   ```
2. Navigate to the project directory:
   ```bash
   cd task-tracker-cli
   ```
3. Build the project:
   ```bash
   dotnet build
   ```
### Usage
You can run the application directly using the executable file generated in the `bin/Debug/netX.0` folder, or via the `dotnet run` command.

Assuming the executable is named `task-cli`:
### Adding a new task
```bash
task-cli add "Buy groceries"
```
### Updating a task
```bash
task-cli update 1 "Buy groceries and cook dinner"
```
### Deleting a task
```bash
task-cli delete 1
```
### Marking a task as in progress or done
```bash
task-cli mark-in-progress 1
task-cli mark-done 1
```
### Listing all tasks
```bash
task-cli list
```
### Listing tasks by status
```bash
task-cli list done
task-cli list todo
task-cli list in-progress
```
### Data Structure
Tasks are stored locally in a `tasks.json` file in the same directory as the executable. Each task follows this structure:
```bash
{
  "Id": 1,
  "Description": "Buy groceries",
  "Status": "todo",
  "CreatedAt": "2026-05-08T22:14:43.4677619+07:00",
  "UpdatedAt": "2026-05-08T22:14:43.4677914+07:00"
}
```
### Author
**Nguyen Tan Loc** Web Developer & C# Backend Developer
**Email:** [tanloc040403@gmail.com]
