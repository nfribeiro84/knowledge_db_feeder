CREATE TABLE [dbo].[HierarquiasTerritoriais]
(
	[HierarquiasTerritoriaisId]	INT				IDENTITY (1, 1) NOT NULL,
	[NomesId]					INT				NOT NULL,
	[Descricao]					VARCHAR(4000)	NOT NULL,
    CONSTRAINT [PK_HierarquiasTerritoriais] PRIMARY KEY CLUSTERED ([HierarquiasTerritoriaisId] ASC),
    CONSTRAINT [FK_HierarquiasTerritoriais_Nomes] FOREIGN KEY ([NomesId]) REFERENCES [dbo].[Nomes] ([NomesId])
);

GO
CREATE NONCLUSTERED INDEX [IX_HierarquiasTerritoriais_1]
    ON [dbo].[HierarquiasTerritoriais]([NomesId] ASC);
