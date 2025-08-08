# Test_150 C# find product
You are tasked with creating an application that can query two databases representing inventory data of two supermarket stores. Each database contains a table named "Products" with the fields: ProductName, ProductCode, ManufactureDate, and Origin. Your goal is to create an application that can determine if a specific product is available in both stores. Use abstract ADO.NET model classes and the DataSet to facilitate unified cross-database operations.
This program first creates connections to two different databases based on the connection strings provided in the configuration file. It then uses abstract ADO.NET model classes and a DataSet to query the "Products" table in both stores for the specified product. If the product is found in both stores, it outputs a message confirming its availability; otherwise, it indicates that the product is not available in both stores.
Please note that you need to configure the connection strings and other app settings in the configuration file (app.config or web.config) before running the program. Also, you would need to have the corresponding database providers installed and configured.

+ Program.cs: Main C# program, prompts the user to enter the product name and checks the availability of the product in both stores.

+ App.config The configuration file contains the connection string for two databases.
  + add your correct connectionString

```bash
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
	<connectionStrings>
		<add name="Store1Connection"
			 connectionString="Data Source=VNHNLEXVM\MSSQLSERVER1;Initial Catalog=Company;Integrated Security=True"
			 providerName="System.Data.SqlClient" />
		<add name="Store2Connection"
			 connectionString="Data Source=VNHNLEXVM\MSSQLSERVER1;Initial Catalog=HR;Integrated Security=True"
			 providerName="System.Data.SqlClient" />
	</connectionStrings>
</configuration>

```
# dataSLQ
+ SQLQuery7, SQLQuery9
add in SQL server

# After setup
run 
```bash
"Start" code c# in visual
```

# Result
+ True
```bash
Enter product name to search: Pen
✅ The product 'Pen' is available in BOTH stores.
```
+ False
```bash
Enter product name to search: coca
❌ The product 'coca' is NOT available in any store.
```
