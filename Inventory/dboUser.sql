CREATE TABLE [dbo].[User] (
    [Id]        INT            NOT NULL IDENTITY,
    [Username]  NVARCHAR (20)  NOT NULL,
    [Name]      NVARCHAR (50)  NOT NULL,
    [Email]     NVARCHAR (100) NULL,
    [CreatedOn] DATETIME       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

