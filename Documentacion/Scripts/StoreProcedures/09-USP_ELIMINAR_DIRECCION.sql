SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Walter Pretell
-- Create date: 30/10/2022
-- Description:	Eliminar una dirección a un Cliente
-- =============================================
CREATE PROCEDURE [dbo].[USP_ELIMINAR_DIRECCION]
	@IdDireccion int,
	@IdCliente int,
	@Activo bit
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @NuevaDireccion varchar(200) = ''
	BEGIN TRANSACTION EliminarDireccion
		BEGIN TRY
			IF (@Activo = 1)
			BEGIN
				SELECT TOP (1) @NuevaDireccion = DireccionRegistro
					FROM Direcciones
					ORDER BY [FechaRegistro] DESC				
				UPDATE Clientes 
					SET DireccionActiva = @NuevaDireccion 
					WHERE IdCliente = @IdCliente
			END
			DELETE Direcciones 
				WHERE IdDireccion = @IdDireccion
			COMMIT TRANSACTION EliminarDireccion
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION EliminarDireccion
		END CATCH 
END
GO