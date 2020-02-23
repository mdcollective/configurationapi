SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Configurations](
    [Name] [nvarchar](50) NOT NULL,
    [Value] [nvarchar](500) NOT NULL,
    [Object] [nvarchar](50) NOT NULL,
    [ObjectId] [int] NOT NULL,
    [ClientToken] [uniqueidentifier] NOT NULL,
    [DateCreated] [datetime] NOT NULL,
    [DateModified] [datetime] NULL,
    [Id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Configurations] ADD  CONSTRAINT [DF_Configurations_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO