# NLayeredPro7
GENERAL INFO-------------------------------------
This program aims to make a list for products.
Enterprise architecture principles applied through the program.

Northwind was used in this program. 
It includes CRUD (create, read, update, delete) operations.
Validation operation was achieved by Fluent Validation and Ninject used for dependancy resolver. (NuGet Packages)

BUGS AND OTHER ISSUES---------------------------- 
Some products related with database can't remove. But if you add new product, you can remove it. I don't know how to handle this issue. 
The exception is: System.Data.Entity.Infrastructure.DbUpdateException: 'An error occurred while updating the entries. See the inner exception for details.'
