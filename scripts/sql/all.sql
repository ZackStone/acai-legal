CREATE DATABASE AcaiLegal;
GO

USE AcaiLegal;
GO

/*
DROP TABLE PedidoAdicional;
DROP TABLE Pedido;
DROP TABLE Tamanho;
GO 
--*/
CREATE TABLE Tamanho
(
	Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	Label NVARCHAR(30) NOT NULL,
	TamanhoMl INTEGER NOT NULL,
	Preco DECIMAL(9,2) NOT NULL,
	TempoDePreparo INT NOT NULL
);
GO

/*
DROP TABLE Sabor;
GO 
--*/
CREATE TABLE Sabor
(
	Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	Label NVARCHAR(30) NOT NULL,
	TempoDePreparo INT NULL
);
GO


/*
DROP TABLE Adicional;
GO 
--*/
CREATE TABLE Adicional
(
	Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	Label NVARCHAR(30) NOT NULL,
	Preco DECIMAL(9,2) NULL,
	TempoDePreparo INT NULL
);
GO


/*
DROP TABLE PedidoAdicional;
DROP TABLE Pedido;
GO 
--*/
CREATE TABLE Pedido
(
	Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	TamanhoId UNIQUEIDENTIFIER NOT NULL,
    SaborId UNIQUEIDENTIFIER NOT NULL,
    TempoDePreparo INT NOT NULL,
    PrecoTotal DECIMAL(9,2) NOT NULL,

    CONSTRAINT FK_Pedido_Tamanho FOREIGN KEY (TamanhoId) REFERENCES Tamanho(Id),
    CONSTRAINT FK_Pedido_Sabor FOREIGN KEY (SaborId) REFERENCES Sabor(Id)
);
GO

/*
DROP TABLE PedidoAdicional;
GO 
--*/
CREATE TABLE PedidoAdicional
(
	PedidoId UNIQUEIDENTIFIER NOT NULL,
	AdicionalId UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT FK_PedidoAdicional_Pedido FOREIGN KEY (PedidoId) REFERENCES Pedido(Id),
    CONSTRAINT FK_PedidoAdicional_Adicional FOREIGN KEY (AdicionalId) REFERENCES Adicional(Id)
);
GO


INSERT INTO Tamanho (Label, TamanhoMl, Preco, TempoDePreparo) VALUES
('Pequeno', 300, 10, 5),
('Médio', 500, 13, 7),
('Grande', 700, 15, 10);
GO

INSERT INTO Sabor (Label, TempoDePreparo) VALUES
('Banana', NULL),
('Morango', NULL),
('Kiwi', 5);
GO

INSERT INTO Adicional (Label, Preco, TempoDePreparo) VALUES
('Paçoca', 3, 3),
('Leite Ninho', 3, NULL),
('Granola', NULL, NULL);
GO
