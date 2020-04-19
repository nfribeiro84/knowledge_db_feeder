CREATE TABLE [dbo].[DT_NomesAlternativos]
(
	[DivisoesTerritoriaisId]	INT			NOT NULL,
	[NomesId]					INT			NOT NULL,
    CONSTRAINT [PK_DT_NomesAlternativos] PRIMARY KEY CLUSTERED ([DivisoesTerritoriaisId] ASC, [NomesId] ASC),
	CONSTRAINT [FK_DT_NomesAlternativos_DivisoesTerritoriais] FOREIGN KEY ([DivisoesTerritoriaisId]) REFERENCES [dbo].[DivisoesTerritoriais] ([DivisoesTerritoriaisId]),
	CONSTRAINT [FK_DT_NomesAlternativos_Nomes] FOREIGN KEY ([NomesId]) REFERENCES [dbo].[Nomes] ([NomesId])
);

GO
CREATE NONCLUSTERED INDEX [IX_DT_NomesAlternativos_1]
    ON [dbo].[DT_NomesAlternativos]([DivisoesTerritoriaisId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_DT_NomesAlternativos_2]
    ON [dbo].[DT_NomesAlternativos]([NomesId] ASC);
