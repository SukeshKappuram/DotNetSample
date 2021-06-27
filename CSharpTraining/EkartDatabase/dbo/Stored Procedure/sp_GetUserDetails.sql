CREATE PROCEDURE [dbo].[sp_GetUserDetails]
@Username NVARCHAR(50),  
@Password NVARCHAR(50)  
AS  
BEGIN  
 DECLARE @UserId INT = 0;  
   
 --UserName is correct   
 SELECT TOP 1 @UserId = Id FROM Users WHERE EmailAddress = @UserName;  
   
 IF NOT EXISTS(SELECT TOP 1 * FROM Users WHERE EmailAddress = @UserName AND Password = @Password)  
 BEGIN  
  --@UserId = 0   
  SELECT @UserId AS Id, null AS EmailAddress    
 END  
 ELSE  
 BEGIN  
  SELECT TOP 1 @UserId AS Id,FirstName,LastName,MobileNumber,EmailAddress FROM Users WHERE EmailAddress = @UserName AND Password = @Password  
  SELECT RoleId,RoleName,HasAccess FROM UserRoles WHERE UserId = @UserId;  
 END  
END  