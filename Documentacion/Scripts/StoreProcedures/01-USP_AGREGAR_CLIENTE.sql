SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Walter Pretell
-- Create date: 30/10/2022
-- Description:	Agregar un Cliente
-- =============================================
CREATE PROCEDURE [dbo].[USP_AGREGAR_CLIENTE]
      @NombreCompleto varchar(200),
      @NroDNI varchar(8),
      @CorreoElectronico varchar(200),
      @NroCelular varchar(9),
      @DireccionActiva varchar(200)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @IdCliente INT
	BEGIN TRANSACTION AgregarCliente
		BEGIN TRY
			INSERT INTO Clientes
				(NombreCompleto,NroDNI,CorreoElectronico,NroCelular,DireccionActiva)
				VALUES (@NombreCompleto, @NroDNI, @CorreoElectronico, @NroCelular, @DireccionActiva)
			SELECT @IdCliente = SCOPE_IDENTITY()
			INSERT INTO Direcciones
				(IdCliente, DireccionRegistro, FechaRegistro, Activo)
				VALUES (@IdCliente, @DireccionActiva, GETDATE(), 1)

			COMMIT TRANSACTION AgregarCliente
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION AgregarCliente
		END CATCH 
END
GO