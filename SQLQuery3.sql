USE [BdDefinitiva]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[guardarORDENES]
		@VENDEDOR = N'ASASA',
		@FECHA_ENTREGA = N'16/09/2020',
		@CLIENTES_COD = 13,
		@EMPLEADOS_CODIGO = 14

SELECT	@return_value as 'Return Value'

GO
