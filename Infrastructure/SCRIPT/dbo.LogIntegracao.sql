USE [DB_Cint]
GO

/****** Object:  Table [dbo].[LogIntegracao]    Script Date: 15/06/2022 08:21:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LogIntegracao](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[documento] [varchar](50) NULL,
	[pedido] [int] NULL,
	[sucesso] [int] NULL,
	[data] [datetime] NULL,
	[arquivo] [varchar](max) NULL,
	[obs] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


