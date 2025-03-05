# DunktonPublicLibraryApp
## About
Welcome to the Dunkton Public Library!

We have over one hundred materials in circulation, including books, magazines, and VHS tapes

Our book and magazine catalog includes materials in the categories of cookbooks and recipes, tractor repair, romantic fiction, animal husbandry, and Spanish poetry

Our catalog of VHS tapes is best described as eclectic

<em>NEW!!</em> We just cut the ribbon on our Junior Readers catalog, with materials for kids grade 4 to grade 7!

Sign up as a cardholder today to browse our catalogs and place holds on the materials that strike your fancy!
## Objectives
+ Complete an 'intermediate' level project
+ Complete a project with more complex domains than past projects
+ Complete a project that balances best practices against practicalities
## Use cases
### Admins
+ Checkin material
+ Checkout material
+ Register
+ View admin summary
+ View checkouts
+ View holds
+ View unpaid fines
### Cardholders
+ Extend checkout
+ Make payment
+ Place hold
+ Register
+ Remove hold
+ View cardholder summary
### Common
+ Browse catalog
+ Change password
+ Login
+ Logout
+ View checkout history
+ View fine history
## App architecture (evolving)
+ App (API)
	+ Use cases
		+ Requests
		+ Handlers
		+ Responses
	+ Identity (password hashing and token generating)
	+ Infrastructure (data access)
+ Domain (models)
	+ Entities
	+ Value objects
+ Services (common to all tiers)
	+ Validation with FluentValidation
	+ Current user state
## Built with
+ NET 9/ C# 13
+ Microsoft Visual Studio Community 2022
+ ASP.NET Core
+ EF Core
+ MediatR (https://www.nuget.org/packages/MediatR)
+ FluentValidation (https://www.nuget.org/packages/FluentValidation)
