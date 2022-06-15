USE [DB_Cint]
GO

/****** Object:  Table [dbo].[PEDIDO]    Script Date: 15/06/2022 08:20:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PEDIDO](
	[Pedido] [int] IDENTITY(1,1) NOT NULL,
	[chave_NFE] [varchar](50) NULL,
	[numeroNF] [varchar](20) NULL,
	[serieNFE] [varchar](20) NULL,
	[tpNF] [varchar](20) NULL,
	[cod_Mun] [varchar](20) NULL,
	[dataNF] [varchar](50) NULL,
	[data_Inclusao] [datetime] NULL,
	[Documento] [varchar](50) NULL,
	[remetenteCNPJ] [varchar](50) NULL,
	[remetenteIE] [varchar](50) NULL,
	[remetenteRazaoSocial] [varchar](50) NULL,
	[remetenteEndereco] [varchar](50) NULL,
	[remetenteNumero] [varchar](50) NULL,
	[remetenteBairro] [varchar](50) NULL,
	[remetenteMunicipio] [varchar](50) NULL,
	[remetenteCEP] [varchar](50) NULL,
	[remetenteUF] [varchar](50) NULL,
	[destinatarioIE] [varchar](50) NULL,
	[destinatarioCPF] [varchar](50) NULL,
	[destinatarioCNPJ] [varchar](50) NULL,
	[destinatarioRazaoSocial] [varchar](50) NULL,
	[destinatarioEndereco] [varchar](50) NULL,
	[destinatarioMunicipioID] [int] NULL,
	[destinatarioMunicipio] [varchar](50) NULL,
	[destinatarioCEP] [varchar](50) NULL,
	[destinatarioUF] [varchar](50) NULL,
	[InformacaoAdicional] [varchar](200) NULL,
	[valor] [float] NULL,
	[volume] [varchar](10) NULL,
	[peso] [float] NULL,
	[destinatarioBairro] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Pedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


