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
