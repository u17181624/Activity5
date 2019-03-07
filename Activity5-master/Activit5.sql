use master
go
create database Activity5
go

use Activity5
go

create table EmployeeType(
ID int Identity(1,1) Primary Key,
name varchar(20)
)
go


create table Employee(
empID int Identity(1,1) Primary Key,
name varchar(20),
ID int
CONSTRAINT FK_Employee FOREIGN KEY (ID)
REFERENCES EmployeeType(ID)
)
go
create table Customer(
CusID int Identity(1,1) Primary Key,
name varchar(20),
surname varchar(20)

)
go
create Table Sales(
SaleID int Identity(1,1) Primary Key,
CusID int,
empID int
CONSTRAINT FK_Sales1 FOREIGN KEY (empID)
REFERENCES Employee(empID),
CONSTRAINT FK_Sales2 FOREIGN KEY (CusID)
REFERENCES Customer(CusID)
)
go

--use master
--go
--drop database Activity5
--go

INSERT INTO EmployeeType(name) values ('Manager'),
('Administrator'), ('Clerk');

INSERT INTO Employee(name,Id) VALUES ('Jason',1),
('Uyanda',2);

INSERT INTO Customer(name,surname) VALUES ('Ben','James'),
('Jack','Kruger');

INSERT INTO Sales(CusID,empID) VALUES (1,1)
INSERT INTO Sales(CusID,empID) VALUES (2,2)
select *
from Sales
