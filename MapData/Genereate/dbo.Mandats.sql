CREATE TABLE [dbo].[Mandats] (
    [MandatId]     INT      IDENTITY (1, 1) NOT NULL,
    [StartDate]    DATETIME NOT NULL,
    [EndDate]      DATETIME NOT NULL,
    [Ressource_Id] INT      NULL,
    --CONSTRAINT [PK_dbo.Mandats] PRIMARY KEY CLUSTERED ([MandatId] ASC),
    CONSTRAINT [FK_dbo.Mandats_dbo.AspNetUsers_Ressource_Id] FOREIGN KEY ([Ressource_Id]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Ressource_Id]
    ON [dbo].[Mandats]([Ressource_Id] ASC);

