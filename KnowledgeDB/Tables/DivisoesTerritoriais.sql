CREATE TABLE [dbo].[DivisoesTerritoriais]
(
	[DivisoesTerritoriaisId]	INT				IDENTITY (1, 1) NOT NULL,
	[NomesId]					INT				NOT NULL,
	[UnidadesTerritoriaisId]	INT				NULL,
	[Descricao]					VARCHAR(4000)	NOT NULL,
    CONSTRAINT [PK_DivisoesTerritoriais] PRIMARY KEY CLUSTERED ([DivisoesTerritoriaisId] ASC),
    CONSTRAINT [FK_DivisoesTerritoriais_Nomes] FOREIGN KEY ([NomesId]) REFERENCES [dbo].[Nomes] ([NomesId]),
    CONSTRAINT [FK_DivisoesTerritoriais_UnidadesTerritoriais] FOREIGN KEY ([UnidadesTerritoriaisId]) REFERENCES [dbo].[UnidadesTerritoriais] ([UnidadesTerritoriaisId])
);

GO
CREATE NONCLUSTERED INDEX [IX_DivisoesTerritoriais_1]
    ON [dbo].[DivisoesTerritoriais]([NomesId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_DivisoesTerritoriais_2]
    ON [dbo].[DivisoesTerritoriais]([UnidadesTerritoriaisId] ASC);
