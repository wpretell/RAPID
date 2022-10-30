SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Walter Pretell
-- Create date: 30/10/2022
-- Description:	Listar todos los Vendedores
-- =============================================
CREATE PROCEDURE [dbo].[USP_LISTAR_VENDEDORES]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT IdVendedor,NombreVendedor,CorreoElectronico,Celular 
		FROM Vendedores
		ORDER BY NombreVendedor
END
GO