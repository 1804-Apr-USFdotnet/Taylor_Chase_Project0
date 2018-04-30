create database CodingChallenge;
use CodingChallenge;

create table Products (ProductID int Identity(1,1), PName Varchar(50), Price money,
Primary key(ProductID));

create table Customers (CustomerID int Identity(1,1), FName Varchar(50), LName Varchar(50), CardNumber numeric, Primary Key(CustomerID));

Create table Orders (OrderID int Identity(1,1), ProductID int, CustomerID int, Primary Key(OrderID), 
Foreign key(ProductID) References Products(ProductID),
foreign key(CustomerID) references Customers(CustomerID));

Insert Into Products (PName, Price) Values ('Twix', 2.00);
Insert Into Products (PName, Price) Values ('Snicker', 2.50);
Insert Into Products (PName, Price) Values ('WhatchaMaCallIt', 3.00);

Insert Into Customers (FName, LName, CardNumber) Values ('Chase', 'Taylor', 5587);
Insert Into Customers (FName, LName, CardNumber) Values ('Mike', 'Martin', 9981);
Insert Into Customers (FName, LName, CardNumber) Values ('Shane', 'Johnston', 4421);

Insert Into Orders(ProductID, CustomerID) Values (1, 3);
Insert Into Orders(ProductID, CustomerID) Values (2, 1);
Insert Into Orders(ProductID, CustomerID) Values (3, 2);

Insert Into Products(PName, Price) Values ('IPhone', 200);
Insert Into Customers(FName, LName, CardNumber) Values ('Tina', 'Smith', 1234);

Insert Into Orders(ProductID, CustomerID) Values (4, 4);

Select * From Orders where CustomerID = 4;

Select Price from Products where PName = 'IPhone';

Update Products  Set Price = 250 where PName = 'IPhone';



