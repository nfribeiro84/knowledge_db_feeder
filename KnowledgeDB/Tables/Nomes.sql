﻿CREATE TABLE [dbo].[Nomes]
(
	[NomesId]	INT				IDENTITY (1, 1) NOT NULL,
	[Nome]		VARCHAR(500)	NOT NULL,
	[Idioma]	VARCHAR(500)	NOT NULL,
    CONSTRAINT [PK_Nomes] PRIMARY KEY CLUSTERED ([NomesId] ASC)
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [UIX_Nomes_1]
    ON [dbo].[Nomes]([Nome] ASC, [Idioma] ASC);