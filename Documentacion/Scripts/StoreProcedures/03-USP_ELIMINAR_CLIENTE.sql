SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Walter Pretell
-- Create date: 30/10/2022
-- Description:	Eliminar un Cliente
-- =============================================
CREATE PROCEDURE [dbo].[USP_ELIMINAR_CLIENTE]
      @IdCliente int
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRANSACTION EliminarCliente
		BEGIN TRY
			DELETE Direcciones 
				WHERE IdCliente = @IdCliente
			DELETE Clientes
				WHERE IdCliente = @IdCliente
			COMMIT TRANSACTION EliminarCliente
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION EliminarCliente
		END CATCH 
END
GO