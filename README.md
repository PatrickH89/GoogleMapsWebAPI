# GoogleMapsWebAPI

## General info
> Here I coded my first Google Maps Web API.  
> You will be able to send/receive addresses-data in json-format over http protocol.  
> <br/>If you create/update an address the Web API will send that address to the Google Geocoding API to get latitude and longitude and save all data in a sql database.  
> It will contain all CRUD operations to create, read, update and delete an address in the sql database.  
> <br/>For safety the Google Geocoding API Key is limited to 100 requests a day.

## Screenshots
<figure>
	<figcaption><strong>Display all Addresses</strong></figcaption>
	<img title="Display all Addresses" src="./NotesWebApp/wwwroot/images/01_Display_all_Addresses.png" alt="Display all Addresses" width="100%" height="100%" >
</figure>

<figure>
	<figcaption><strong>Display one Address</strong></figcaption>
	<img title="Display one Address" src="./NotesWebApp/wwwroot/images/02_Display_One_Address.png" alt="Display one Address" width="100%" height="100%" >
</figure>

<figure>
	<figcaption><strong>Update an Address</strong></figcaption>
	<img title="Update an Address" src="./NotesWebApp/wwwroot/images/03_Update_an_Address.png" alt="Update an Address" width="100%" height="100%" >
</figure>

<figure>
	<figcaption><strong>Create an Address</strong></figcaption>
	<img title="Create an Address" src="./NotesWebApp/wwwroot/images/04_Create_an_Address.png" alt="Create an Address" width="100%" height="100%" >
</figure>


## Technologies
* ASP.NET Core - version 3.1
* design pattern: MVC 
* Entity Framework Core - version 5.0.8
* IIS + MS SQL Server

## Setup
Just download the project und let it run in Visual Studio Community. 
The GoogleMapsWebAPI will be started and a sql db will be created thus you can start writing your first address for example with Postman.

Later on I will explain all urls and an example for json format address to create a new one. Update, Delete, Read ones/all.

## Features
To-do list:
* Display all addresses
* Display one address by Id
* Create an address
* Update an address by Id
* Delete an address by Id

## Status
Project is: _in progress_