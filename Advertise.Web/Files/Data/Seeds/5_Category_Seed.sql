USE [AdvertiseDB]
GO
INSERT [dbo].[AD_Categories] (
[Category_Id],
[Category_Code],
[Category_Title],
[Category_Description],
[Category_ImageFileName],
[Category_HasChild],
[Category_IsActive],
[Category_MetaTitle],
[Category_MetaDescription],
[Category_ParentId],
[Category_CreatedOn],
[Category_ModifiedOn],
[Category_CreatorIp],
[Category_ModifierIp],
[Category_IsModifyLock],
[Category_IsDelete],
[Category_ModifierAgent],
[Category_CreatorAgent],
[Category_Version],
[Category_Audit],
[Category_ModifiedById],
[Category_CreatedById])
VALUES (N'666c3824-0105-9e5b-b86b-0226a45db0d2',
N'10612',
N'دسته',
NULL,
NULL,
0,
1,
N'دسته',
NULL,
NULL,
CAST(N'2016-12-24 23:42:27.700' AS DateTime),
CAST(N'2016-02-06 17:46:15.970' AS DateTime),
NULL,
NULL,
0,
0,
NULL,
NULL,
1,
1,
N'9d2b0228-4d0d-4c23-8b49-01a698857709',
N'9d2b0228-4d0d-4c23-8b49-01a698857709')
