
CREATE TABLE [dbo].[Stores]
(
	[StoreId] INT NOT NULL PRIMARY KEY, 
	[Name] NVARCHAR(255) NULL
)

CREATE TABLE [dbo].[Albums] (
	[Id]       INT            NOT NULL,
	[Title]    NVARCHAR (255) NULL,
	[Artist]   NVARCHAR (255) NULL,
	[Genre]    NVARCHAR (255) NULL,
	[Year]     INT            NULL,
	[CoverURL] NVARCHAR (MAX) NULL,
	[StoreId] INT NOT NULL, 
	PRIMARY KEY CLUSTERED ([Id] ASC), 
	CONSTRAINT [FK_Albums_Stores] FOREIGN KEY ([StoreId]) REFERENCES [Stores]([StoreId])
);

CREATE TABLE [dbo].[Tracks] (
	[Number]    INT           NOT NULL,
	[SongTitle] VARCHAR (255) NULL,
	[Length]    TIME (0)      NULL,
	[AlbumID] INT NOT NULL, 
	PRIMARY KEY CLUSTERED ([Number] ASC), 
	CONSTRAINT [FK_Tracks_Albums] FOREIGN KEY ([AlbumID]) REFERENCES [Albums]([Id])
);


