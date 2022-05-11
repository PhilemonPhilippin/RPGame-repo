CREATE TABLE [dbo].[Hero]
(
	[Id] INT NOT NULL IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Stamina] FLOAT NOT NULL,
	[MaxHealth] FLOAT NOT NULL,
	[MaxMana] FLOAT NOT NULL,
	[ManaPotion] INT NOT NULL,
	[Strength] FLOAT NOT NULL,
	[Block] FLOAT NOT NULL,
	[Experience] FLOAT NOT NULL,
	[Level] INT NOT NULL,
	[Incarnation] INT NOT NULL,
	[Gold] INT NOT NULL,
    [Race] VARCHAR(50) NOT NULL,
	[Leather] INT NOT NULL, 
    CONSTRAINT PK_Hero PRIMARY KEY ([Id])
)
