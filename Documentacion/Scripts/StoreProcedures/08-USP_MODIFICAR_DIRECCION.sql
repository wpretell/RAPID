SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Walter Pretell
-- Create date: 30/10/2022
-- Description:	Modificar una dirección a un Cliente
-- =============================================
CREATE PROCEDURE [dbo].[USP_MODIFICAR_DIRECCION]
	@IdDireccion int,
	@IdCliente int,
	@NuevaDireccion varchar(200),
	@Activo bit
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRANSACTION ModificarDireccion
		BEGIN TRY
			IF (@Activo = 1)
			BEGIN
				UPDATE Clientes 
					SET DireccionActiva = @NuevaDireccion 
					WHERE IdCliente = @IdCliente
			END
			UPDATE Direcciones 
				SET DireccionRegistro = @NuevaDireccion 
				WHERE IdDireccion = @IdDireccion
			COMMIT TRANSACTION ModificarDireccion
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION ModificarDireccion
		END CATCH 
END
GO