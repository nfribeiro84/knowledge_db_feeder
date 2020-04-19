CREATE TABLE [dbo].[HT_NomesAlternativos]
(
	[HierarquiasTerritoriaisId]	INT			NOT NULL,
	[NomesId]					INT			NOT NULL,
    CONSTRAINT [PK_HT_NomesAlternativos] PRIMARY KEY CLUSTERED ([HierarquiasTerritoriaisId] ASC, [NomesId] ASC),
	CONSTRAINT [FK_HT_NomesAlternativos_HierarquiasTerritoriais] FOREIGN KEY ([HierarquiasTerritoriaisId]) REFERENCES [dbo].[HierarquiasTerritoriais] ([HierarquiasTerritoriaisId]),
	CONSTRAINT [FK_HT_NomesAlternativos_Nomes] FOREIGN KEY ([NomesId]) REFERENCES [dbo].[Nomes] ([NomesId])
);

GO
CREATE NONCLUSTERED INDEX [IX_HT_NomesAlternativos_1]
    ON [dbo].[HT_NomesAlternativos]([HierarquiasTerritoriaisId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_HT_NomesAlternativos_2]
    ON [dbo].[HT_NomesAlternativos]([NomesId] ASC);
