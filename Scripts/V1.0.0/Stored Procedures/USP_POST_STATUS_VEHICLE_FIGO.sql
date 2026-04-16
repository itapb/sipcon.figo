USE [FIGO]
GO
/****** Object:  StoredProcedure [dbo].[USP_POST_VEHICLES_FIGO]    Script Date: 14/04/2026 10:23:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[USP_POST_STATUS_VEHICLE_FIGO]  
 @DATA VARCHAR(MAX)
AS
/* '===============================================================          
  '   NOMBRE                : 
  '   FECHA CREACIÓN        : 
  '   CREADO POR            : JUAN GUARECUCO
  '   CREADO PARA           : 
  '   FUNCIÓN               :  
  '   VERSIÓN               : 
  '   MODIFICADO EN         : 
  '   MODIFICADO POR        :  
  '   RAZÓN DE MODIFICACIÓN : 
  '===============================================================*/

SET XACT_ABORT ON               
SET NOCOUNT ON
SET LOCK_TIMEOUT 180000

BEGIN

	BEGIN TRY
	     
		  DECLARE @IDUSER INT=1
		  DECLARE @ErrorMessage NVARCHAR(4000)
	
				DECLARE @TDATA AS TABLE
				(
					VVIN VARCHAR(20),
					VESTATUS VARCHAR(15),
					DRECEPTIONDATE DATETIME, -- Corregido: Reception
					VRECEPTIONNUMBER VARCHAR(10),
					IESTATUS INT
				);

				INSERT INTO @TDATA (
					DRECEPTIONDATE, 
					VRECEPTIONNUMBER,
					VESTATUS,
					VVIN
					
				)
				SELECT 
					D.ReceptionDate,
					D.ReceptionNumber,
					D.Estatus,
					D.Vin
				FROM OPENJSON(@DATA)
				WITH (
					ReceptionDate DATETIME,
					ReceptionNumber VARCHAR(10),
					Estatus Varchar(15),
					Vin     VARCHAR(20)
				) AS D;


				DECLARE @IDMODULE INT=[dbo].[UFN_GET_IDMODULE]('VEHICULOS-VEHICULOS')
				DECLARE @InsertedVehicles TABLE (IDVEHICLE INT)
			    
				UPDATE A
						SET A.IESTATUS = V.ID
						FROM @TDATA A
						INNER JOIN ACTION V ON UPPER(V.VNAME) = UPPER(A.VESTATUS)

			 
	            BEGIN TRAN 

				DECLARE @IID INT
				DECLARE @IINSERTED INT
				DECLARE @IUPDATED INT
				

					UPDATE V
					SET
						V.IESTATUS=D.IESTATUS,
						V.DUPDATED = GETDATE(),
						V.VUPDATEDBY = DBO.UFN_GET_LOGIN(@IDUSER)
                    OUTPUT INSERTED.ID INTO @InsertedVehicles(IDVEHICLE)
					FROM VEHICLE V
					INNER JOIN @TDATA D ON V.VVIN=D.VVIN

					SELECT @IUPDATED=@@ROWCOUNT
				
				   IF @IUPDATED>0
				BEGIN
				INSERT INTO AUDIT (IDUSER, IDRECORD, IDMODULE, VCOMMENT, DCREATED, VACTION)
					SELECT 
						@IDUSER,
						IV.IDVEHICLE,
						@IDMODULE,
					    CAST(D.VRECEPTIONNUMBER AS VARCHAR(50)),
						GETDATE(),
						D.VESTATUS 
					FROM @InsertedVehicles IV
					JOIN @TDATA D ON D.VVIN = (SELECT V.VVIN FROM VEHICLE V WITH (NOLOCK) WHERE V.ID = IV.IDVEHICLE)
				END


				SELECT
				ISNULL(@IID,0) AS IID , 
				ISNULL(@IINSERTED,0) AS IINSERTED,
				ISNULL(@IUPDATED,0) AS IUPDATED

 		COMMIT TRAN
	END TRY
	BEGIN CATCH
		IF XACT_STATE() <> 0
			ROLLBACK TRAN
		 
		SELECT  @ErrorMessage = ERROR_PROCEDURE() + ' : ' + ERROR_MESSAGE()
		RAISERROR ( @ErrorMessage , 16,1) 
	END CATCH

END
