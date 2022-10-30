SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Walter Pretell
-- Create date: 30/10/2022
-- Description:	Listar un solo Cliente
-- =============================================
CREATE PROCEDURE [dbo].[USP_LISTAR_CLIENTE]
	@IdCliente int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT IdCliente,NombreCompleto,NroDNI,CorreoElectronico,NroCelular,DireccionActiva
		FROM Clientes
		WHERE IdCliente = @IdCliente
END
GO