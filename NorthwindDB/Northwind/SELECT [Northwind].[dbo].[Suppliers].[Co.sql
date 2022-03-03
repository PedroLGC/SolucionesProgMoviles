SELECT [Northwind].[dbo].[Suppliers].[CompanyName], [Northwind].[dbo].[Suppliers].[ContactName], [Northwind].[dbo].[Suppliers].[Phone], [Northwind].[dbo].[Products].[SupplierID]
FROM [Northwind].dbo.[Products] INNER JOIN [Northwind].[dbo].[Suppliers]
on [Northwind].[dbo].[Suppliers].[SupplierID] = [Northwind].[dbo].[Products].[SupplierID];