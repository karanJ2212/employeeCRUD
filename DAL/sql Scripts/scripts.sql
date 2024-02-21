CREATE DATABASE EmployeesDB;

DROP TABLE IF EXISTS Employees;
DROP TABLE IF EXISTS Departments;

CREATE TABLE Departments (
    DepartmentId INT IDENTITY(1,1) PRIMARY KEY,
    DepartmentName NVARCHAR(255) NOT NULL
);



CREATE TABLE Employees (
    EmployeeId INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeName NVARCHAR(255) NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    DepartmentId INT NOT NULL,
    FOREIGN KEY (DepartmentId) REFERENCES Departments(DepartmentId)
);



INSERT INTO Departments (DepartmentName) VALUES ('Sales'), ('Marketing'), ('HR'), ('IT');

INSERT INTO Employees (EmployeeName, Address, DepartmentId) VALUES
('John Doe', '123 Elm St', 1),
('Jane Smith', '456 Maple Ave', 2);