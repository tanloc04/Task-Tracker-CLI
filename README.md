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
   git clone [https://github.com/YourUsername/task-tracker-cli.git](https://github.com/YourUsername/task-tracker-cli.git)
   ```
2. Navigate to the project directory:
   ```bash
   cd task-tracker-cli
   ```
3. Build the project:
   ```bash
   dotnet build
   ```
