USE BaseDB;  
GO  
CREATE OR ALTER PROCEDURE dbo.InitDB   
    @iterations integer
AS   
    DECLARE @num_iteration INTEGER;
    SET @num_iteration = 0;
    WHILE @num_iteration < @iterations 
    BEGIN  
        SET NOCOUNT ON; 
        INSERT INTO [dbo].[Configuration] (
            [Name], [Description], [Master], 
            [CreatedUser], [CreatedDate]) VALUES 
            (
                CONCAT(N'CONFIGURATION', @num_iteration),
                CONCAT(N'PRODUCTION_SETUP', @num_iteration), 1, N'UserUnknown', N'2023-08-01 00:00:00');

        INSERT INTO [dbo].[Vehicles] (
            [Model], [Brand], [Year], [Km], 
            [KmsPerMonth], [DateKms], [DatePurchase], 
            [Active], [ConfigurationId], [VehicleTypeId], [CreatedDate], [CreatedUser]) VALUES 
            (
                CONCAT(N'Model', @num_iteration), 
                CONCAT(N'Honda', @num_iteration), 
                2008, 10000 + @num_iteration, 
                FLOOR(RAND()*(1000-100+1))+100, GETDATE(), GETDATE(), 1, 
                FLOOR(RAND()*(@num_iteration-1+1))+1, 
                FLOOR(RAND()*(3-1+1))+1, 
                GETDATE(), N'UserUnknown');

        SET @num_iteration += 1;
    END  
GO  

EXECUTE dbo.InitDB 100000
select * from dbo.Vehicles