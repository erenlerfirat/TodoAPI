
![Application layer](https://github.com/erenlerfirat/TodoAPI/blob/master/AppLayer.jpg)
1)Application Layers:Business,DataAccess,Entity,Api.
2)Entity layer has two models:Todo,Category.
3)Data Access connects the application with the MsSql server.
4)Business layer role is making communication and logic between Data Access and Api.
5)In Api there is a controller TodoController with CRUD methods with 5 endpoints.
6)In the Api layer there is a Middleware for logging requests (logging the request body and method).
Tools and Setup :
.Net 5.0
Data Access=EntityFramework core.
Logging= Serilog.
