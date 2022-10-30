SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Walter Pretell
-- Create date: 30/10/2022
-- Description:	Listar todos los Clientes
-- =============================================
CREATE PROCEDURE [dbo].[USP_LISTAR_CLIENTES] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT IdCliente,NombreCompleto,NroDNI,CorreoElectronico,NroCelular,DireccionActiva
		FROM Clientes
		ORDER BY NombreCompleto
END
GO
