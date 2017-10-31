IF not exists (select * from sysobjects where name='Persons' and xtype='U')
BEGIN
	CREATE TABLE [dbo].[Persons](
		[PersonID] [int] IDENTITY(1,1) NOT NULL,
		[LastName] [varchar](255) NULL,
		[FirstName] [varchar](255) NULL,
		[Address] [varchar](255) NULL,
		[City] [varchar](255) NULL,
	 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
	(
		[PersonID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO
CREATE proc [dbo].[usp_Get2Person] 
@PersonID1 INT, @PersonID2 INT
as
	set nocount on
	SELECT [PersonID]
			,[LastName]
			,[FirstName]
			,[Address]
			,[City]
		FROM [dbo].[Persons]
		where PersonID = @PersonID1
		;

		SELECT [PersonID]
			,[LastName]
			,[FirstName]
			,[Address]
			,[City]
		FROM [dbo].[Persons]
		where PersonID = @PersonID2
GO
CREATE proc [dbo].[usp_GetPeople] 
as
set nocount on
SELECT [PersonID]
		,[LastName]
		,[FirstName]
		,[Address]
		,[City]
	FROM [dbo].[Persons]
GO
CREATE proc [dbo].[usp_GetPerson] 
@PersonID INT
as
set nocount on
	SELECT [PersonID]
			,[LastName]
			,[FirstName]
			,[Address]
			,[City]
		FROM [dbo].[Persons]
		where PersonID = @PersonID
GO