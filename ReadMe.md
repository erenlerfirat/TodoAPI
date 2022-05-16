
![Application layer](https://github.com/erenlerfirat/TodoAPI/blob/master/AppLayer.jpg) <br />
<p align="center">
 1)Application Layers:Business,DataAccess,Entity,Api. <br />
2)Entity layer has two models:Todo,Category. <br />
3)Data Access connects the application with the MsSql server. <br />
4)Business layer role is making communication and logic between Data Access and Api. <br />
5)In Api there is a controller TodoController with CRUD methods with 5 endpoints. <br />
6)In the Api layer there is a Middleware for logging requests (logging the request body and method). <br />
Tools and Setup : <br />
.Net 6.0 <br />
Data Access=EntityFramework core. <br />
Logging= Serilog.</p>
