// Migration Instructions and commands:

Reminder, this commands only applicable for  => CLI Commands ( Not the package manager console)

Before start to write commands you should have ef-core design tools /Check it => [ dotnet-ef ]

if you dont have you can download => [ dotnet tool install --global dotnet-ef ]

0) Change you current directory to DataAccess / OR You can the flag --project DataAccess 

1) [ dotnet ef migrations add MyFirstMigration ]

2) [ dotnet ef database update ]

3) [ dotnet ef migrations remove ] =>  The command will remove the last migration and revert the model snapshot to the previous migration.

4) [ dotnet ef migrations script ] => The script command will include a script for all the migrations by default. 

You can specify a range of migrations by using the -to and -from options.

5) In design time you need add connection string as an literal string into todocontext
instead of configuration helper,Otherwise you'll get type initializer error .