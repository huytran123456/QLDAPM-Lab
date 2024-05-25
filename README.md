READ

** LOGIN INFORMATION (username/password): <p>User: user / 123456</p>  <p>Admin: admin / 123456</p> <p>**SETTING</p>

You need to run it locally by following these steps:

1. Download and install Sql Server( for MacOS, your can  use Docker to set up)
2. Open Sql Server
3. Download the source code and open it on your IDE (such as using Visual Studio application(https://visualstudio.microsoft.com/fr/) or Rider(https://www.jetbrains.com/rider/)
4. Open the editor, set up and download the required libraries in the next step
5. You must create namespace Properties
6. Open the terminal you need to run command:<p> cp .launchSettings.example.json Properties/launchSettings.json </p> to to create a new launchSettings.json file and replace @project-name with your project-name
7. At the new window terminal, you need to run command:<p> cp .appsettings.example.json appsettings.json </p>to create a new appsettings.json file needed
8. At the appsettings.json file, must make a connection to the database and set up more add variables and keys for the project environment 
9. Run the following commands:<p> dotnet tool install --global dotnet-ef </p><p> dotnet ef migrations add InitialCreate </p><p> dotnet ef database update </p> 
10. Launch the project server with command: <p> dotnet run Project </p>