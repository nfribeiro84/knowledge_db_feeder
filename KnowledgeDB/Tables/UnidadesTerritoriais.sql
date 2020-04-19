CREATE TABLE [dbo].[UnidadesTerritoriais]
(
	[UnidadesTerritoriaisId]	INT				IDENTITY (1, 1) NOT NULL,
	[NomesId]					INT				NOT NULL,
	[LandArea]					geography		NULL,
    CONSTRAINT [PK_UnidadesTerritoriais] PRIMARY KEY CLUSTERED ([UnidadesTerritoriaisId] ASC),
    CONSTRAINT [FK_UnidadesTerritoriais_Nomes] FOREIGN KEY ([NomesId]) REFERENCES [dbo].[Nomes] ([NomesId])
);

GO
CREATE NONCLUSTERED INDEX [IX_UnidadesTerritoriais_1]
    ON [dbo].[UnidadesTerritoriais]([NomesId] ASC);
