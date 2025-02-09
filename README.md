# Company Management System

## 📌 Overview
The **Company Management System** is a simple web application built using **ASP.NET Core MVC** that provides essential CRUD (Create, Read, Update, Delete) operations for managing employees and departments. It also includes authentication and role-based access control to manage user permissions effectively.

## 🎯 Features
- **Employee Management**: Add, update, delete, and list employees.
- **Department Management**: Assign employees to departments and manage department records.
- **User Authentication**: Secure login and registration system.
- **Role-Based Access Control**: Admin, Manager, and Employee roles with different permissions.
- **Validation & Error Handling**: Ensures data integrity and prevents invalid inputs.
- **Responsive UI**: Clean and simple design for better user experience.

## 🛠 Technologies Used
- **.NET 8 (ASP.NET Core MVC)**
- **Entity Framework Core (EF Core) 8**
- **SQL Server** (Database)
- **Identity Framework** (For authentication and authorization)
- **Bootstrap** (For UI styling)

## ⚙️ Installation & Setup

### 1️⃣ Prerequisites
- .NET 8 SDK installed
- SQL Server installed and running
- Visual Studio or VS Code with C# extensions

### 2️⃣ Clone the Repository
```sh
git clone https://github.com/your-username/company-management-system.git
cd company-management-system
```

### 3️⃣ Configure Database
1. Update the **appsettings.json** file with your SQL Server connection string:
```json
"ConnectionStrings": {
    "defaultConnection": "server=YOUR_SERVER;database=CompanyDB;trusted_connection=true;MultipleActiveResultSets=true"
}
```
2. Run database migrations:
```sh
dotnet ef database update
```

### 4️⃣ Run the Application
```sh
dotnet run
```
Open **http://localhost:5000** in your browser.

## 👥 User Roles & Permissions
| Role    | Permissions |
|---------|------------|
| Admin   | Manage users, roles, departments, employees |
| Manager | Manage employees, view reports |
| Employee | View personal profile, update basic details |

## 📌 API Endpoints (For Future Expansion)
- `GET /employees` - Retrieve all employees
- `POST /employees` - Add a new employee
- `PUT /employees/{id}` - Update employee details
- `DELETE /employees/{id}` - Delete an employee

## 🛠 Future Enhancements
- 🌍 Multi-language support
- 📊 Advanced reporting and analytics
- 🔐 Two-factor authentication (2FA)
- 📧 Email notifications for employee updates

## 🤝 Contributing
1. Fork the repository.
2. Create a feature branch: `git checkout -b feature-name`
3. Commit your changes: `git commit -m 'Add new feature'`
4. Push to the branch: `git push origin feature-name`
5. Submit a pull request.

## 📜 License
This project is licensed under the **MIT License**.

---

🔥 **Developed by Kiro** 🚀

