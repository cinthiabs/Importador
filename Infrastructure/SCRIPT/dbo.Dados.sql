USE [DB_Cint]
GO

/****** Object:  Table [dbo].[Dados]    Script Date: 15/06/2022 08:22:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Dados](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Integracao] [varchar](50) NULL,
	[webservice] [varchar](100) NULL,
	[token] [varchar](100) NULL,
	[diretorioEntrada] [varchar](100) NULL,
	[diretorioSaida] [varchar](100) NULL,
	[TabelaLog] [varchar](100) NULL,
	[ativo] [int] NULL,
	[informacao1] [varchar](100) NULL,
	[informacao2] [varchar](100) NULL,
	[informacao3] [varchar](100) NULL,
	[informacao4] [varchar](100) NULL,
	[Intervalo] [varchar](100) NULL,
	[UltimaExecucao] [datetime] NULL,
	[ProximaExecucao] [datetime] NULL,
	[diretorioErro] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


