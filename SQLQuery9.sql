USE HR;
GO

CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    Price DECIMAL(10, 2)
);

INSERT INTO Products (Name, Price)
VALUES 
('Pen', 1.50),
('Notebook', 3.00),
('Pencil', 0.75);
