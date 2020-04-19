CREATE TABLE [dbo].[Unidades_Divisoes]
(
	[UnidadesDivisoesId]		INT				IDENTITY (1, 1) NOT NULL,
	[UnidadesTerritoriaisId]	INT				NOT NULL,
	[DivisoesTerritoriaisId]	INT				NOT NULL,
    CONSTRAINT [PK_Unidades_Divisoes] PRIMARY KEY CLUSTERED ([UnidadesDivisoesId] ASC),
    CONSTRAINT [FK_Unidades_Divisoes_UnidadesTerritoriais] FOREIGN KEY ([UnidadesTerritoriaisId]) REFERENCES [dbo].[UnidadesTerritoriais] ([UnidadesTerritoriaisId]),
    CONSTRAINT [FK_Unidades_Divisoes_DivisoesTerritoriais] FOREIGN KEY ([DivisoesTerritoriaisId]) REFERENCES [dbo].[DivisoesTerritoriais] ([DivisoesTerritoriaisId])
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [UIX_Unidades_Divisoes_1]
    ON [dbo].[Unidades_Divisoes]([UnidadesTerritoriaisId] ASC, [DivisoesTerritoriaisId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Unidades_Divisoes_1]
    ON [dbo].[Unidades_Divisoes]([DivisoesTerritoriaisId] ASC);
