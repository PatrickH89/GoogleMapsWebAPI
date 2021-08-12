# GoogleMapsWebAPI

Here I coded my first Google Maps Web API.  
You will be able to send/receive addresses-data in json-format over http protocol.  
<br/>If you create/update an address, the Web API will send that address to the Google Geocoding API to get latitude and longitude and save all that data in a  local sql database.
The WebAPI contains all CRUD operations to CREATE, READ, UPDATE and DELETE an address from/to the sql database.  
<br/>For safety the Google Geocoding API Key in appsettings.json file is not working. You must replace it with a working one.  
<br/>Here I uploaded a [Frontend](https://github.com/PatrickH89/GoogleMapsWebAPI_Frontend) to consume that WebAPI.  

## Technologies
* ASP.NET Core - version 3.1
* design pattern: MVC 
* Entity Framework Core - version 5.0.8
* IIS + MS SQL Server

## Setup
Before running this WebAPI you will have to delete the Migrations folder and make your own migration for creating your own sql database.  
<br/>And dont forget to use a working API Key in appsettings.json file.  

__Steps to create your own database:__
```markdown
1. Open project
2. Delete 'Migrations' folder and its files
3. Write in Package Manager Console of VS
     add-Migration MyAddressDB 
     update-database 
```

Now you created your own sql db. Thus you can run the WebAPI and writing your first address in the db with e.g. [Postman](https://www.postman.com/) or you click [here](https://github.com/PatrickH89/GoogleMapsWebAPI_Frontend) and use my Frontend.  

## Features
Here are the urls and the HTML body to CREATE, UPDATE, DELETE and READ addresses with Postman/Browser.

__GET ALL ADDRESSES:__
```yml
GET: https://localhost:44369/api/Address/GetAddresses
```

__GET ONE ADDRESS BY ID:__
```yml
GET: https://localhost:44369/api/Address/SelectAddress/2
```

__CREATE A NEW ADDRESS:__
```yml
POST: https://localhost:44369/api/Address/AddAddress  
HTML body:  
   { "street": "Schaumainkai", "streetNumber": "50", "postCode": "60596", "city":"Frankfurt am Main", "country": "Deutschland" }
```

__UPDATE AN ADDRESS BY ID:__
```yml
PUT: https://localhost:44369/api/Address/UpdateAddress/5  
HTML body: 
   { "street": "Theodor-W.-Adorno-Platz", "streetNumber": "1", "postCode": "60323", "city": "Frankfurt", "country": "Deutschland" }
```

__DELETE AN ADDRESS BY ID:__
```yml
DELETE: https://localhost:44369/api/Address/DeleteAddress/3
```

## Status
Project is: _finished_