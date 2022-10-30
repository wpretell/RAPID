SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Walter Pretell
-- Create date: 30/10/2022
-- Description:	Modificar un Cliente
-- =============================================
CREATE PROCEDURE [dbo].[USP_MODIFICAR_CLIENTE]
	@IdCliente int,
	@NombreCompleto varchar(200),
	@NroDNI varchar(8),
	@CorreoElectronico varchar(200),
	@NroCelular varchar(9)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Clientes
		SET NombreCompleto = @NombreCompleto,
			NroDNI = @NroDNI,
			CorreoElectronico = @CorreoElectronico,
			NroCelular = @NroCelular
		WHERE IdCliente = @IdCliente
END
GO