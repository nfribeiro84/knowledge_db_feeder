CREATE TABLE [dbo].[Unidades_Divisoes_Hierarquias]
(
	[UnidadesDivisoesHierarquiasId]		INT		IDENTITY (1, 1) NOT NULL,
	[HierarquiasTerritoriaisId]			INT		NOT NULL,
	[UnidadesDivisoesId]				INT		NOT NULL,
	[ParentId]							INT		NULL,
    CONSTRAINT [PK_Unidades_Divisoes_Hierarquias] PRIMARY KEY CLUSTERED ([UnidadesDivisoesHierarquiasId] ASC),
    CONSTRAINT [FK_Unidades_Divisoes_Hierarquias_HierarquiasTerritoriais] FOREIGN KEY ([HierarquiasTerritoriaisId]) REFERENCES [dbo].[HierarquiasTerritoriais] ([HierarquiasTerritoriaisId]),
    CONSTRAINT [FK_Unidades_Divisoes_Hierarquias_Unidades_Divisoes] FOREIGN KEY ([UnidadesDivisoesId]) REFERENCES [dbo].[Unidades_Divisoes] ([UnidadesDivisoesId]),
    CONSTRAINT [FK_Unidades_Divisoes_Hierarquias_Unidades_Divisoes_Parent] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[Unidades_Divisoes] ([UnidadesDivisoesId])
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [UIX_Unidades_Divisoes_Hierarquias_1]
    ON [dbo].[Unidades_Divisoes_Hierarquias]([HierarquiasTerritoriaisId] ASC, [UnidadesDivisoesId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Unidades_Divisoes_Hierarquias_1]
    ON [dbo].[Unidades_Divisoes_Hierarquias]([UnidadesDivisoesId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_Unidades_Divisoes_Hierarquias_2]
    ON [dbo].[Unidades_Divisoes_Hierarquias]([ParentId] ASC);
