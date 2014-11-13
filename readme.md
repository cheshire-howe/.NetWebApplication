# .Net Web Application

This is an example application that demonstrates a modern MVC application, along with a WebAPI that enables the collected data to be available on all platforms.

This application demonstrates multi-layer architecture with a Model layer, Repository layer, Service layer and UI layer.

The Model layer holds the POCO classes representing entities which are mapped to the database. The POCO classes are built intelligently by inheriting from either the BaseEntity abstract class or AuditableEntity abstract class. Inheriting from the AuditableEntity abstract class will automatically create timestamps and track the user who creates or updates the entity, by way of a modified DbContext.SaveChanges() method. This results in the entity POCO class only having properties representing the business model.

The Repository layer follows both the generic repository pattern and unit of work pattern. The repository exposes methods made available by Entity Framework in a simplified form and keeps the separation of concerns to a maximum. Each repository only has access to one corresponding entity so that data retrieval is highly controlled, and unnecessary hits to the database are minimal. Changes to the database are controlled as well, as the repositories do not have access to the unit of work. The Service layer collects all the data necessary, and uses the unit of work to make changes to the database in a single transaction.

The Service layer has many more responsibilities, also. This layer ties everything together and holds the business logic to coordinate all database interaction. The methods in the Service layer have names that make their purpose clear, and wrap entire transactions with any logic into one neat package. This way, any UI layer that needs to retrieve from or modify the database needs one line of code to get the job done.

There are two individual UI layers.

### MVC
The MVC UI layer uses Microsoft's latest in web design, MVC 5. This layer uses controllers and actions to return Razor views with a reference to only the Service layer for any data that a view may need.

### AngularJS
#### 1
The AngularJS UI uses Microsoft's WebAPI 2.0 to retrieve data and modify the database. This is not built as a separate layer, but uses MVC's capability to return partial views so Angular can switch between pages. The ngResource module is used to interact with the WebApi sending and receiving data in JSON format. The WebAPI also has access to only the Service layer and uses the same methods as MVC to interact with the database.

#### 2
There is a separate project built using AngularJS as well to demonstrate the use of CORS and uses Microsoft's Web Pages as the template. This project is standalone and only requires that the API be running on some server.

## Database Functionality and Entity Framework
This project demonstrates the use of Entity Framework to handle not only basic database interaction, but also one-to-many and many-to-many relationships. The Service layer harnesses the power Entity Framework by encapsulating all logic of the complex relationships so that any UI Layer has simple, easy to understand methods exposed to it which do not require extensive knowledge of Entity Framework in order to use.

## Dependency Injection and Inversion of Control
This sample project uses Autofac to inject dependencies where needed. Therefore any changes that need to be made to repositories, the unit of work or services can be done efficiently without worry and testing is greatly simplified. It is also possible to use a different repository for example in a long running context like a desktop application, with the only modification to existing code occuring in that specific project.
