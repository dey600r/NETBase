USE BaseDB;  
GO  
CREATE PROCEDURE dbo.InitDB   
    @num_iteration integer
AS   

    SET NOCOUNT ON;  
    SELECT * 
    FROM dbo.Vehicles  
    WHERE Brand = @Brand;  

    --DECLARE @num_iteration INTEGER;
    --SET @num_iteration = 0;
    WHILE @num_iteration < 100 
    BEGIN  

        INSERT INTO [dbo].[Vehicles] (
            [Model], [Brand], [Year], [Km], [IdConfiguration], 
            [IdVehicleType], [KmsPerMonth], [DateKms], [DatePurchase], 
            [Active], [ConfigurationId], [VehicleTypeId], [CreatedDate], [CreatedUser]) VALUES 
            (
                N'Model'+@num_iteration, 
                N'Honda'+@num_iteration, 
                2008, 10000 + @num_iteration, 
                1, RAND(3), RAND(1000), 
            GETDATE(), GETDATE(), 1, 1, 1, 
            N'2023-12-04 10:24:51', N'UserUnknown')
    END  
GO  


EXECUTE dbo.InitDB N'Yamaha'