-- CREATE DB
IF DB_ID('TEST_DB') IS NULL
    CREATE DATABASE TEST_DB;
GO



-- CREATE TABLE EMPLOYEE
CREATE TABLE EMPLOYEE (
    Emp_ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Emp_FirstName VARCHAR(255) NOT NULL,
    Emp_LastName VARCHAR(255) NOT NULL,
    Emp_Age INT NOT NULL,
    Emp_BuildingID INT
);
GO 

-- CREATE TABLE BUILDING
CREATE TABLE BUILDING (
    Building_ID INT NOT NULL PRIMARY KEY,
    Building_Name VARCHAR(255) NOT NULL,
    Building_Short VARCHAR(255) NOT NULL
);
GO 



-- INSERT DATA
-- DATA INTO TABLE EMPLOYEE
INSERT INTO EMPLOYEE 
    (Emp_FirstName, Emp_LastName, Emp_Age, Emp_BuildingID)
VALUES
    ('First', 'Last', 20, 1),
    ('Harris', 'Adni', 25, 2),
    ('Haniff', 'Adni', 23, 3);
GO

SELECT * FROM EMPLOYEE;
GO

-- DATA INTO TABLE BUILDING
INSERT INTO BUILDING
    (Building_ID, Building_Name, Building_Short)
VALUES
    (1, 'Kulim 1', 'KM1'),
    (2, 'Kulim 2', 'KM2'),
    (3, 'Penang 12', 'PG12');
GO

SELECT * FROM BUILDING;
GO

