# sample-weather-app
This is a sample project that I created to learn about Angular, .net10 WebApi and .NET Aspire. It is a simple web application that shows a city's weather details.

# how to run the app
1. This project use .NET Aspire to run all services and web app.
2. In ..\webApp\src (Angular project), open terminal and run `npm install` (requires Node.js.)
3. Then, move to ..\WeatherServiceAppHost and run `dotnet run WeatherServiceAppHost.csproj`
4. This will run the Aspire project and a url link will be provided. Copy the link and paste
   it in web browser. Both app named `weather-app` and `weather-api` will shown as running.
5. Open another browser and paste this link. `http://localhost:4200/weather`. Then, enter a city name to test it. Eg: Johor Bahru
6. Make sure not to change the port number. Changing it will cause the application fail to run 
