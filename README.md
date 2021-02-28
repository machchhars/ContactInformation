**Welcome to Contact Information Management**
------------

This is a ASP.NET Core WEBAPI which is used to manage your contact information.

**Getting Started - Explanation of Structure**
------------
- **ContactInformationManagement**
	- This project is an actual WEBAPI
- **ContactInformationManagement.Common**
	- This is a common library which is accessible by all the project present in the ContactInformationManagement solution
- **ContactInformationManagement.Business**
	- This is a Business library which contains repository
	- This library will connect to the Data access layer to perform the CURD operation and also the business logic that we want.
- **ContactInformationManagement.DAL**
	- This is a Data Access Layer which is used to connect with the database for CURD operation.
- **ContactInformationManagement.UnitTest**
	- This project contains the UnitTest for the WEBAPI

**Getting Started - Configuration**
------------
- Open the solution file present in the ContactInformationManagement folder
- Update the connection string of SQL server in the appsettings.json file key would be "ContactInformationManagementSQL"
- Build the application

**Getting Started - How to test**
------------
- You can use the swagger to test the api by accessing the url as "**DomainName**/swagger"
- You can run the test cases present in the "ContactInformationManagement.UnitTest"

**Getting Started - API URL Format**
------------
- GET => "/api/contact" => This URL will get all the contact list
- POST => "/api/contact" => This URL will add new contact
- GET => "/api/contact/{id}" => This URL will get single contact based on the Id
- DELETE => "/api/contact/{id}" => This URL will delete the contact based on the Id
- PUT => "/api/contact/Update/{id}" => This URL will update the contact based on the Id

**Author**
------------
[Smit Machchhar](https://www.linkedin.com/in/smit-machchhar-161a58121/ "Smit Machchhar")
