# GoogleMapsWebAPI

Here I coded my first Google Maps Web API.  
You will be able to send/receive addresses-data in json-format over http protocol.  
<br/>If you create/update an address the Web API will send that address to the Google Geocoding API to get latitude and longitude and save all data in a sql database.  
It will contain all CRUD operations to CREATE, READ, UPDATE and DELETE an address from/to the sql database.  
<br/>For safety the Google Geocoding API Key is limited to 100 requests a day.  
<br/>For this WebAPI I will upload one Frontend with ASP.NET CORE MVC and Bootstrap 4 to consume that WebAPI. 

## Technologies
* ASP.NET Core - version 3.1
* design pattern: MVC 
* Entity Framework Core - version 5.0.8
* IIS + MS SQL Server

## Setup
Before running this WebAPI you will have to delete the Migrations folder and make your own migration for creating your own sql database.

Steps to create your own database:
1. Open the project
2. Delete the whole Migrations folder with its two files
3. Go to: Tools -> NuGet Package Manager -> Package Manager Console
4. Write in Console: Add-Migration 
5. With Name: MyAddressDB
6. Migrations folder with two files "number_MyAddressDB" and "...Snapshot" should be created automatically
7. Write in Console: update-database 
8. Check if DB got created: View -> SQL Server ... Eplorer -> localdb -> Databases -> 
   MyAddressesDB -> Tables -> rightclick db Address ... Model -> View Data

Now you created your own sql db. Thus you can run the WebAPI and writing your first address in the db with e.g. Postman.

## Features
Here are the urls and the HTML body to CREATE, UPDATE, DELETE and READ addresses with Postman/Browser.

* GET ALL ADDRESSES:  
https://localhost:44369/api/Address/GetAddresses

* GET ONE ADDRESS BY ID:  
https://localhost:44369/api/Address/SelectAddress/2

* CREATE A NEW ADDRESS:  
https://localhost:44369/api/Address/AddAddress  
HTML body: {"street":"Schaumainkai","streetNumber":"50","postCode":"60596","city":"Frankfurt am Main","country":"Deutschland"}

* UPDATE AN ADDRESS BY ID:  
https://localhost:44369/api/Address/UpdateAddress/5  
HTML body: { "street": "Theodor-W.-Adorno-Platz", "streetNumber": "1", "postCode": "60323", "city": "Frankfurt", "country": "Deutschland" }

* DELETE AN ADDRESS BY ID:  
https://localhost:44369/api/Address/DeleteAddress/3

## Status
Project is: _finisehd_