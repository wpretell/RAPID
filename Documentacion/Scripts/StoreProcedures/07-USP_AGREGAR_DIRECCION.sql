SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Walter Pretell
-- Create date: 30/10/2022
-- Description:	Agregar una dirección a un Cliente
-- =============================================
CREATE PROCEDURE [dbo].[USP_AGREGAR_DIRECCION]
	@IdCliente int,
	@NuevaDireccion varchar(200)
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRANSACTION AgregarDireccion
		BEGIN TRY
			UPDATE Clientes 
				SET DireccionActiva = @NuevaDireccion 
				WHERE IdCliente = @IdCliente
			UPDATE Direcciones 
				SET Activo = 0 
				WHERE IdCliente = @IdCliente
			INSERT INTO Direcciones (IdCliente,DireccionRegistro,FechaRegistro,Activo)
				VALUES (@IdCliente,@NuevaDireccion,GETDATE(),1)
			COMMIT TRANSACTION AgregarDireccion
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION AgregarDireccion
		END CATCH 
END
GO