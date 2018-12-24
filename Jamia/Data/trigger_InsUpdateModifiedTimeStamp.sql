CREATE TRIGGER [Identity].[trigger_InsUpdateModifiedTimeStamp] ON [Identity].[Users]
AFTER UPDATE
AS 
BEGIN
	UPDATE [Identity].[Users]
    SET [ModifiedTimeStamp] = GETDATE()
    WHERE [Identity].[Users].Id IN (SELECT Id FROM INSERTED);
END;