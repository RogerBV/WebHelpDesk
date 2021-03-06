USE [HelpDeskDb]
GO
/****** Object:  Table [dbo].[Event]    Script Date: 13/11/2020 0:07:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NOT NULL,
	[Description] [varchar](350) NULL,
	[UserId] [int] NOT NULL,
	[RequestId] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[State] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventType]    Script Date: 13/11/2020 0:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](40) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[State] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Module]    Script Date: 13/11/2020 0:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Module](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](80) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[State] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Request]    Script Date: 13/11/2020 0:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](80) NOT NULL,
	[AttentionDate] [datetime] NULL,
	[UserId] [int] NOT NULL,
	[ModuleId] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[State] [int] NOT NULL,
	[AttentionUserId] [int] NULL,
	[GoalDate] [datetime] NULL,
	[LastUpdateUserId] [int] NULL,
	[SourceFile] [varchar](max) NULL,
	[FileName] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestFile]    Script Date: 13/11/2020 0:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestFile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Source] [varchar](max) NOT NULL,
	[RequestId] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[State] [int] NOT NULL,
	[File] [varchar](max) NULL,
	[FileName] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestState]    Script Date: 13/11/2020 0:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestState](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](80) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[State] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 13/11/2020 0:07:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](80) NOT NULL,
	[UserName] [varchar](80) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[State] [int] NOT NULL,
	[UserPassword] [varchar](25) NOT NULL,
	[Type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EventType] ON 

INSERT [dbo].[EventType] ([Id], [Name], [CreateDate], [State]) VALUES (1, N'Create Request', CAST(N'2020-11-03T12:21:29.747' AS DateTime), 1)
INSERT [dbo].[EventType] ([Id], [Name], [CreateDate], [State]) VALUES (2, N'Assign Attention User', CAST(N'2020-11-03T12:21:29.747' AS DateTime), 1)
INSERT [dbo].[EventType] ([Id], [Name], [CreateDate], [State]) VALUES (3, N'Review of Request', CAST(N'2020-11-03T12:21:29.747' AS DateTime), 1)
INSERT [dbo].[EventType] ([Id], [Name], [CreateDate], [State]) VALUES (4, N'Rejected by User', CAST(N'2020-11-03T12:21:29.747' AS DateTime), 1)
INSERT [dbo].[EventType] ([Id], [Name], [CreateDate], [State]) VALUES (5, N'Closed', CAST(N'2020-11-03T12:21:29.747' AS DateTime), 1)
INSERT [dbo].[EventType] ([Id], [Name], [CreateDate], [State]) VALUES (6, N'Rejected by Administrator', CAST(N'2020-11-03T12:21:29.747' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[EventType] OFF
SET IDENTITY_INSERT [dbo].[Module] ON 

INSERT [dbo].[Module] ([Id], [Name], [CreateDate], [State]) VALUES (1, N'Contabilidad', CAST(N'2020-09-24T12:04:04.380' AS DateTime), 1)
INSERT [dbo].[Module] ([Id], [Name], [CreateDate], [State]) VALUES (3, N'Logistica', CAST(N'2020-09-28T16:17:52.337' AS DateTime), 1)
INSERT [dbo].[Module] ([Id], [Name], [CreateDate], [State]) VALUES (4, N'Transportes', CAST(N'2020-09-29T00:47:07.923' AS DateTime), 1)
INSERT [dbo].[Module] ([Id], [Name], [CreateDate], [State]) VALUES (5, N'Finanzas', CAST(N'2020-09-29T10:47:54.587' AS DateTime), 1)
INSERT [dbo].[Module] ([Id], [Name], [CreateDate], [State]) VALUES (6, N'Produccion', CAST(N'2020-11-06T12:45:41.830' AS DateTime), 1)
INSERT [dbo].[Module] ([Id], [Name], [CreateDate], [State]) VALUES (7, N'Proyectos', CAST(N'2020-11-06T12:45:41.830' AS DateTime), 1)
INSERT [dbo].[Module] ([Id], [Name], [CreateDate], [State]) VALUES (8, N'Comercial', CAST(N'2020-11-06T12:45:41.830' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Module] OFF
SET IDENTITY_INSERT [dbo].[RequestState] ON 

INSERT [dbo].[RequestState] ([Id], [Name], [CreateDate], [State]) VALUES (1, N'Pending', CAST(N'2020-10-23T11:02:28.613' AS DateTime), 1)
INSERT [dbo].[RequestState] ([Id], [Name], [CreateDate], [State]) VALUES (2, N'Assigned', CAST(N'2020-10-23T11:02:28.613' AS DateTime), 1)
INSERT [dbo].[RequestState] ([Id], [Name], [CreateDate], [State]) VALUES (3, N'Reviewed', CAST(N'2020-10-23T11:02:28.613' AS DateTime), 1)
INSERT [dbo].[RequestState] ([Id], [Name], [CreateDate], [State]) VALUES (4, N'Rejected by User', CAST(N'2020-10-23T11:02:28.613' AS DateTime), 1)
INSERT [dbo].[RequestState] ([Id], [Name], [CreateDate], [State]) VALUES (5, N'Closed', CAST(N'2020-10-23T11:02:28.613' AS DateTime), 1)
INSERT [dbo].[RequestState] ([Id], [Name], [CreateDate], [State]) VALUES (6, N'Rejected by Administrator', CAST(N'2020-10-27T09:50:22.393' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[RequestState] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [UserName], [CreateDate], [State], [UserPassword], [Type]) VALUES (1, N'Roger Barriga', N'rbarriga', CAST(N'2020-09-29T11:52:32.233' AS DateTime), 1, N'123456', 2)
INSERT [dbo].[User] ([Id], [Name], [UserName], [CreateDate], [State], [UserPassword], [Type]) VALUES (2, N'Gabriela Calderon', N'gcalderon', CAST(N'2020-09-29T11:52:32.233' AS DateTime), 1, N'123456', 1)
INSERT [dbo].[User] ([Id], [Name], [UserName], [CreateDate], [State], [UserPassword], [Type]) VALUES (3, N'Eder Gomez', N'egomez', CAST(N'2020-10-13T10:48:02.530' AS DateTime), 1, N'123456', 1)
INSERT [dbo].[User] ([Id], [Name], [UserName], [CreateDate], [State], [UserPassword], [Type]) VALUES (4, N'Marlon Garcia', N'mgarcia', CAST(N'2020-10-13T10:49:43.937' AS DateTime), 1, N'123456', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[EventType] ADD  DEFAULT ((1)) FOR [State]
GO
ALTER TABLE [dbo].[Request] ADD  DEFAULT ((0)) FOR [LastUpdateUserId]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ('') FOR [UserPassword]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((1)) FOR [Type]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Request] FOREIGN KEY([RequestId])
REFERENCES [dbo].[Request] ([Id])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Request]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_User]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Module] ([Id])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Module]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_User]
GO
ALTER TABLE [dbo].[RequestFile]  WITH CHECK ADD  CONSTRAINT [FK_Request_RequestFile] FOREIGN KEY([RequestId])
REFERENCES [dbo].[Request] ([Id])
GO
ALTER TABLE [dbo].[RequestFile] CHECK CONSTRAINT [FK_Request_RequestFile]
GO
/****** Object:  Trigger [dbo].[st_RegisterRequest]    Script Date: 13/11/2020 0:07:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[st_RegisterRequest] 
	ON [dbo].[Request]
AFTER INSERT 
AS
BEGIN

	SET NOCOUNT ON 

	DECLARE @RequestId INT
	DECLARE @UserId INT

	SELECT @RequestId = inserted.Id FROM inserted

	SELECT @UserId = UserId FROM dbo.Request WHERE Id = @RequestId

	INSERT INTO dbo.[Event]
	([Type],[Description],UserId,RequestId,CreateDate,[State])
	VALUES(1,'Register Request',@UserId,@RequestId,GETDATE(),1)

END
GO
ALTER TABLE [dbo].[Request] ENABLE TRIGGER [st_RegisterRequest]
GO
/****** Object:  Trigger [dbo].[st_UpdatedRequest]    Script Date: 13/11/2020 0:07:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[st_UpdatedRequest] 
	ON [dbo].[Request]
AFTER UPDATE
AS
BEGIN

	SET NOCOUNT ON 

	DECLARE @RequestId INT
	DECLARE @UserId INT

	SELECT @RequestId = Id FROM inserted

	SELECT @UserId = LastUpdateUserId FROM dbo.Request WHERE Id = @RequestId

	IF (SELECT [State] FROM Request WHERE Id = @RequestId) = 2
	BEGIN
		INSERT INTO dbo.[Event]
		([Type],[Description],UserId,RequestId,CreateDate,[State])
		SELECT TOP 1 2,CONCAT('Request Assigned to ',U.[Name])  ,@UserId,@RequestId,GETDATE(),1 FROM Request R
		INNER JOIN dbo.[User] U ON R.AttentionUserId = U.Id
		WHERE R.Id = @RequestId	
	END
	IF (SELECT [State] FROM Request WHERE Id = @RequestId) = 5
	BEGIN
		INSERT INTO dbo.[Event]
		([Type],[Description],UserId,RequestId,CreateDate,[State])
		SELECT R.[State],'Request Closed'  ,@UserId,@RequestId,GETDATE(),1 FROM Request R
		WHERE R.Id = @RequestId	
	END




	

END
GO
ALTER TABLE [dbo].[Request] ENABLE TRIGGER [st_UpdatedRequest]
GO
/****** Object:  Trigger [dbo].[st_RequestFile]    Script Date: 13/11/2020 0:07:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[st_RequestFile]
ON [dbo].[RequestFile]
AFTER INSERT
AS
BEGIN
	DECLARE @RequestId INT
	DECLARE @Source VARCHAR(MAX)
	DECLARE @FileName VARCHAR(MAX)

	select @RequestId = RequestId, @Source = Source, @FileName = FileName from inserted

	UPDATE Request 
	SET [SourceFile] = CONCAT('\RequerimientFiles\',@RequestId,'\', @FileName )
	,[FileName] = @FileName
	WHERE Id = @RequestId
END
GO
ALTER TABLE [dbo].[RequestFile] ENABLE TRIGGER [st_RequestFile]
GO
