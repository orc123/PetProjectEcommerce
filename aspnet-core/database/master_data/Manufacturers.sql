

INSERT INTO [dbo].[AppManufacturer]
           ([Id]
           ,[Name]
           ,[Code]
           ,[Slug]
           ,[CoverPicture]
           ,[Visibility]
           ,[IsActive]
           ,[Country]
           ,[ExtraProperties]
           ,[ConcurrencyStamp]
           ,[CreationTime]
           ,[CreatorId])
     VALUES
            (newid()
           ,N'Apple'
           ,'M1'
           ,'apple'
           ,null
           ,1
           ,1
           ,'US'
           ,null
           ,null
           ,getdate()
           ,null)



INSERT INTO [dbo].[AppManufacturer]
           ([Id]
           ,[Name]
           ,[Code]
           ,[Slug]
           ,[CoverPicture]
           ,[Visibility]
           ,[IsActive]
           ,[Country]
           ,[ExtraProperties]
           ,[ConcurrencyStamp]
           ,[CreationTime]
           ,[CreatorId])
     VALUES
            (newid()
           ,N'Microsoft'
           ,'M2'
           ,'microsoft'
           ,null
           ,1
           ,1
           ,'US'
           ,null
           ,null
           ,getdate()
           ,null)
