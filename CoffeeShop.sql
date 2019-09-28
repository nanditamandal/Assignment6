CREATE DATABASE CoffeeShop
USE CoffeeShop

CREATE TABLE Customers(
ID INT IDENTITY(1,1),
Name VARCHAR(50) UNIQUE NOT NULL,
Address VARCHAR(50)NOT NULL,
Contact CHAR(11) NOT NULL ,
PRIMARY KEY (ID)
)
SELECT * FROM Customers

CREATE TABLE Items(
ID INT IDENTITY(1,1),
ItemName VARCHAR(50) UNIQUE NOT NULL,
Price DECIMAL(3,2) NOT NULL ,
PRIMARY KEY (ID)
)
SELECT * FROM Items

CREATE TABLE Orders(
ID INT IDENTITY(1,1),
Quantity INT NOT NULL,
Name VARCHAR(50) FOREIGN KEY REFERENCES Customers(Name),
ItemName VARCHAR(50) FOREIGN KEY REFERENCES Items(ItemName),
PRIMARY KEY (ID)
)

SELECT * FROM Orders
SELECT Orders.ID,Orders.Name,Orders.ItemName,Orders.Quantity,Orders.Quantity*Items.Price AS Totalprice, Customers.Address, Customers.Contact, Items.Price FROM Orders, Customers, Items WHERE Orders.Name=Customers.Name AND Orders.ItemName=Items.ItemName