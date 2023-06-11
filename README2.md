# TemplateFw Web App Documentation

## Project Overview
TemplateFw is a .NET Core web application that serves as a foundation for building web applications using a template-based approach. It provides a set of common features and functionality to kickstart the development process.

## Architecture
The web app follows a layered architecture pattern with the following layers:

1. **Presentation Layer**:
   - The `TemplateFw.Web` project contains the presentation layer components.
   - It includes controllers, views, and static assets used for rendering web pages.

2. **Business Logic Layer**:
   - The `TemplateFw.Core` project contains the business logic layer.
   - It includes services, models, and utilities used for implementing the application's core functionality.

3. **Data Access Layer**:
   - The `TemplateFw.Data` project contains the data access layer components.
   - It includes repositories, database contexts, and entity models used for interacting with the underlying data store.

## Installation and Setup
To set up the web app locally, follow these steps:

1. **Clone the repository**:

2. **Install the .NET Core SDK**:
- Ensure that you have the .NET Core SDK installed. If not, download and install it from the official .NET Core website.

3. **Restore Dependencies**:
- Open a terminal or command prompt and navigate to the `TemplateFw` directory.
- Run the following command to restore the project dependencies:
  ```
  dotnet restore
  ```

4. **Configure the Database Connection**:
- Open the `appsettings.json` file in the `TemplateFw.Web` project.
- Update the `DefaultConnection` connection string to point to your desired database server.

5. **Run the Application**:
- In the terminal or command prompt, run the following command to start the web app:
  ```
  dotnet run --project TemplateFw.Web
  ```

6. **Access the Web App**:
- Open a web browser and navigate to `http://localhost:5000` to access the running web app.

## Project Structure
The project structure of the repository is as follows:

- `TemplateFw.Web`: Contains the web application's presentation layer components.
- `TemplateFw.Core`: Contains the business logic layer components.
- `TemplateFw.Data`: Contains the data access layer components.
- `TemplateFw.Tests`: Contains unit tests for the application.
- `TemplateFw.sln`: The solution file that includes all the projects.

## Dependencies
The web app relies on the following dependencies:

- ASP.NET Core
- Entity Framework Core
- Microsoft.Extensions.DependencyInjection
- Microsoft.Extensions.Logging
- Newtonsoft.Json


# TemplateFw Web App Documentation

## Introduction
Welcome to the documentation for the TemplateFw web app! TemplateFw is a .NET Core web application designed to provide a solid foundation for building web applications using a template-based approach. It aims to simplify the development process by offering a set of common features and functionality that can be easily customized and extended.

## Purpose
The purpose of TemplateFw is to provide developers with a starting point for creating web applications with .NET Core. It offers a structured architecture, pre-built components, and best practices to accelerate development time and ensure maintainable and scalable applications.

## Features
- **Template-Based Approach:** TemplateFw allows you to create web applications by using templates as building blocks. These templates provide common functionality, such as user authentication, CRUD operations, and data visualization.
- **Layered Architecture:** The web app follows a layered architecture pattern, separating the presentation layer, business logic layer, and data access layer. This promotes code organization, separation of concerns, and testability.
- **Customization and Extension:** TemplateFw is highly customizable and extensible. You can modify the existing templates or create new ones to meet specific requirements. Additionally, you can add new features and integrate with external libraries or APIs.

## Target Audience
TemplateFw is primarily aimed at developers who want to kickstart their web application projects using .NET Core. It is suitable for developers with varying levels of experience, from beginners who want to learn web development to experienced developers who want to leverage the provided foundation for their projects.

## GitHub Repository
The source code for the TemplateFw web app is available on GitHub at [https://github.com/TheAlchimest/TemplateFw](https://github.com/TheAlchimest/TemplateFw). The repository contains the codebase, documentation, and any additional resources related to the project.

In the following sections, you will find detailed information on how to set up the development environment, understand the project structure, utilize the provided features, and deploy the web app.

Let's get started with setting up the development environment!

## Getting Started

To get started with the TemplateFw web app, follow these steps to set up the development environment:

### Prerequisites
Before you begin, ensure that you have the following software installed on your machine:

- .NET Core SDK: [Download and install the latest .NET Core SDK](https://dotnet.microsoft.com/download) suitable for your operating system.

### Step 1: Clone the Repository
1. Open a terminal or command prompt.
2. Change the current directory to the location where you want to clone the project.
3. Run the following command to clone the TemplateFw repository:
git clone https://github.com/TheAlchimest/TemplateFw.git
This will create a local copy of the project on your machine.

### Step 2: Restore Dependencies
1. Navigate to the project's root directory:
cd TemplateFw

2. Restore the project dependencies by running the following command:
dotnet restore

This will download and install all the required dependencies specified in the project's configuration files.

### Step 3: Set Up the Database Connection
1. Open the `appsettings.json` file located in the `TemplateFw.Web` project.
2. Look for the `DefaultConnection` section.
3. Configure the connection string to point to your desired database server. Update the relevant properties such as server address, username, password, and database name.

### Step 4: Build and Run the Web App
1. Navigate to the `TemplateFw.Web` project directory:
cd TemplateFw.Web

2. Build the project by running the following command:
dotnet build

3. Run the web app using the following command:
dotnet run


4. Open a web browser and navigate to `http://localhost:5000` to access the running TemplateFw web app.

Congratulations! You have successfully set up the development environment and launched the TemplateFw web app. You can now start exploring its features and customizing it according to your requirements.

