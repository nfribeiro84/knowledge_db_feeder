CREATE TABLE [dbo].[UT_NomesAlternativos]
(
	[UnidadesTerritoriaisId]	INT			NOT NULL,
	[NomesId]					INT			NOT NULL,
    CONSTRAINT [PK_UT_NomesAlternativos] PRIMARY KEY CLUSTERED ([UnidadesTerritoriaisId] ASC, [NomesId] ASC),
	CONSTRAINT [FK_UT_NomesAlternativos_UnidadesTerritoriais] FOREIGN KEY ([UnidadesTerritoriaisId]) REFERENCES [dbo].[UnidadesTerritoriais] ([UnidadesTerritoriaisId]),
	CONSTRAINT [FK_UT_NomesAlternativos_Nomes] FOREIGN KEY ([NomesId]) REFERENCES [dbo].[Nomes] ([NomesId])
);

GO
CREATE NONCLUSTERED INDEX [IX_UT_NomesAlternativos_1]
    ON [dbo].[UT_NomesAlternativos]([UnidadesTerritoriaisId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_UT_NomesAlternativos_2]
    ON [dbo].[UT_NomesAlternativos]([NomesId] ASC);
