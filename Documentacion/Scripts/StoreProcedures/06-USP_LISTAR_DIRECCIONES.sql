SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Walter Pretell
-- Create date: 30/10/2022
-- Description:	Listar todas las direcciones de un Cliente
-- =============================================
CREATE PROCEDURE [dbo].[USP_LISTAR_DIRECCIONES]
	@IdCliente int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT IdDireccion,DireccionRegistro,FechaRegistro,Activo
		FROM Direcciones
		WHERE IdCliente = @IdCliente
		ORDER BY FechaRegistro DESC
END
GO