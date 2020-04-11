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