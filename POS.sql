/*USERS*/
INSERT INTO [dbo].[Users] ([Email], [Password], [Name], [IsAdmin]) VALUES (N'admin@abc.com', N'123456', N'ADMIN', 1)
INSERT INTO [dbo].[Users] ([Email], [Password], [Name], [IsAdmin]) VALUES (N'employee@abc.com', N'123456', N'EMPLOYEE', 0)

/*Transactions*/
SET IDENTITY_INSERT [dbo].[Transactions] ON
INSERT INTO [dbo].[Transactions] ([Id], [Amount_Total], [Method_Of_Payment], [Date]) VALUES (1, 100, 1, N'2017-01-01 00:00:00')
INSERT INTO [dbo].[Transactions] ([Id], [Amount_Total], [Method_Of_Payment], [Date]) VALUES (2, 200, 2, N'2017-03-04 00:00:00')
INSERT INTO [dbo].[Transactions] ([Id], [Amount_Total], [Method_Of_Payment], [Date]) VALUES (3, 400, 3, N'2017-04-06 00:00:00')
INSERT INTO [dbo].[Transactions] ([Id], [Amount_Total], [Method_Of_Payment], [Date]) VALUES (4, 200, 3, N'2018-01-21 00:00:00')
INSERT INTO [dbo].[Transactions] ([Id], [Amount_Total], [Method_Of_Payment], [Date]) VALUES (5, 600, 3, N'2018-01-24 03:00:00')
INSERT INTO [dbo].[Transactions] ([Id], [Amount_Total], [Method_Of_Payment], [Date]) VALUES (6, 700, 2, N'2018-01-22 02:00:00')
INSERT INTO [dbo].[Transactions] ([Id], [Amount_Total], [Method_Of_Payment], [Date]) VALUES (7, 400, 1, N'2018-01-22 09:00:00')
SET IDENTITY_INSERT [dbo].[Transactions] OFF

/*Products*/
SET IDENTITY_INSERT [dbo].[Products] ON
INSERT INTO [dbo].[Products] ([Id], [product_name], [product_price], [stock_remaining], [stock_flag], [stock_max]) VALUES (2, N'Product Two', 23.99, 8, 5, 10)
INSERT INTO [dbo].[Products] ([Id], [product_name], [product_price], [stock_remaining], [stock_flag], [stock_max]) VALUES (3, N'Product One', 12, 10, 5, 10)
INSERT INTO [dbo].[Products] ([Id], [product_name], [product_price], [stock_remaining], [stock_flag], [stock_max]) VALUES (4, N'Product Three', 44, 2, 2, 4)
SET IDENTITY_INSERT [dbo].[Products] OFF

/*TransProd*/
SET IDENTITY_INSERT [dbo].[TransProds] ON
INSERT INTO [dbo].[TransProds] ([Id], [ProductId], [TransactionId], [ProductQuantity]) VALUES (2, 2, 1, 2)
INSERT INTO [dbo].[TransProds] ([Id], [ProductId], [TransactionId], [ProductQuantity]) VALUES (3, 3, 1, 4)
INSERT INTO [dbo].[TransProds] ([Id], [ProductId], [TransactionId], [ProductQuantity]) VALUES (4, 4, 1, 6)
INSERT INTO [dbo].[TransProds] ([Id], [ProductId], [TransactionId], [ProductQuantity]) VALUES (5, 2, 2, 3)
INSERT INTO [dbo].[TransProds] ([Id], [ProductId], [TransactionId], [ProductQuantity]) VALUES (6, 4, 2, 4)
INSERT INTO [dbo].[TransProds] ([Id], [ProductId], [TransactionId], [ProductQuantity]) VALUES (7, 3, 3, 2)
INSERT INTO [dbo].[TransProds] ([Id], [ProductId], [TransactionId], [ProductQuantity]) VALUES (8, 2, 3, 5)
INSERT INTO [dbo].[TransProds] ([Id], [ProductId], [TransactionId], [ProductQuantity]) VALUES (9, 2, 4, 4)
INSERT INTO [dbo].[TransProds] ([Id], [ProductId], [TransactionId], [ProductQuantity]) VALUES (10, 4, 1, 5)
INSERT INTO [dbo].[TransProds] ([Id], [ProductId], [TransactionId], [ProductQuantity]) VALUES (11, 2, 5, 6)
INSERT INTO [dbo].[TransProds] ([Id], [ProductId], [TransactionId], [ProductQuantity]) VALUES (12, 4, 5, 7)
INSERT INTO [dbo].[TransProds] ([Id], [ProductId], [TransactionId], [ProductQuantity]) VALUES (13, 2, 5, 8)
INSERT INTO [dbo].[TransProds] ([Id], [ProductId], [TransactionId], [ProductQuantity]) VALUES (17, 2, 6, 1)
INSERT INTO [dbo].[TransProds] ([Id], [ProductId], [TransactionId], [ProductQuantity]) VALUES (18, 4, 4, 8)
SET IDENTITY_INSERT [dbo].[TransProds] OFF