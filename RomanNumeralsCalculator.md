# Roman Numerals Calculator

## Initial Brief

````
Coding Excercise - Roman Numbers Calculator
===

Frameworks to be used

* C#, dotnet 6 or .NET 4.8 framework for backend
* Frontend to be writen in typescript and angular or react.js
* Make use of design patterns and respect SOLID principals
* Unit Tests / TDD
* Test Coverage >= 85%

---

1. *"As a Roman Bookkeeper I want to add Roman numbers because doing it manually is too tedious"*

Given the Roman numerals, (I,V,X,L,C,D,M) which means one, five, ten, fifty, hundred, fivehundred and a thousand respectively), create two numbers and add them. *As we are in Rome there is no such thing as a decimal or int, we need to this working on strings.*

An example would be "XIV" + "LX" = "LXXIV"

There are some rules to a Roman number:

* Numerals can be concatenated to form a larger number ("XX" + "II" = "XXII")
* If a lesser numeral is put before a bigger it means subtraction of the lesser from the bigger ("IV" means four, "CM" means ninehundred)
* If the numeral is I,X or C you cannot have more than three ("II" + "II" = "IV")
* If the numeral is V,L or D you cannot have more than one ("D"+"D" = "M")
* The largest possible number is MMMCMXCIX

2. *"As a Bookkeeper I want to be able to switch the display between decimal and roman numbers because it is easier to understand for me. But do not change the calculation logic, it works perfect for me!"*

More instructions:

* You have respected SOLID so it should be easy to replace the implementation

````

----

## User Experience Requirements

### 1 - "add Roman numbers"
Aim is to 
 - "create two numbers and add them" = provide a simple solution to add two Roman numerals together and see the result. 
 - Note: although called "Roman Numbers Calculator", there is no mention of 
   - additional calculator functionality in the brief (e.g. -, *, / etc.)
   - being able to add more than two numbers in a single operation
 - Each entry and the total 
  - can only contain the values I,V,X,L,C,D,M
  - cannot be greater than MMMCMXCIX (3999)


### 2 - "switch the display between decimal and roman numbers"
Aim is to 
 - provide an interactive UI element to switch the displayed result between decimal and roman numerals. 
 - Note: "it is easier to understand" is mentioned, so to aid understanding will include secondary display of translated values in the UI  (low hanging fruit)

  
----

## Tech stack
No reference is made to any form of data or even state storage, so a client only app would have been the first choice, but reference to frontend and backend leads to the decision to take the following approach: 


### Frontend
Given the choice, will use Typescript/React  

### Backend 
Given the choice, will use .NET 6


  
----

## Design Approach
As we are running a frontend/backend architecture, taking the decision to take a very "light" approach to the frontend functionality, creating a frontend client which is focused on the interaction with the end user - in this case a human (bookkeeper) with keyboard and mouse/touch input.

Client-side functionality will be limited to 
 - providing a user input form
 - validating user inputs before submission
    - allowed roman numerals (or arabic integers) only
    - both input values (numbers to be summed) being present
 - submission of the inputs to the backend API
 - presenting the response from the API
    - positive responses
    - error responses
 - The first iteration will only support an English language UI, roman numerals and integer inputs 
    - Note: Roman numerals (counting) do not include the concept of decimals or fractions, so only integers will be supported



Interaction with the backend will happen via API, using json payloads, allowing the current frontend client (and any future alternative clients) to use the shareed business logic required to add values and "translate" them from roman numerals to decimal and vice versa.

The data exchange and usage are not considered particularly sensitive, or specific to an indvidual bookkeeper, and with no mention of authentication etc, we forego this for the moment. Instead we rely just on https and the use of a secret HTTP Request header to prevent undue abuse of what will (eventually) be a protected but publically accessible API endpoint.


  
----

## Detailed Frontend Design
 - Simple CSS design
 - Input Fields
    - numericInputOne (textbox)
    - numericInputTwo (textbox)
 - CTAs (call to action)
    - 'Add' (button)
 - Labels
     - instructions
     - numericInputOneLabel (text)
     - numericInputOneError (text)
     - numericInputTwoLabel (text)
     - numericInputTwoError (text)
     - numericCalculatedResultLabel (text)
     - numericCalculatedResult (text)
     - translation (text)
     - responseErrorLabel (text)



  
----


## JSON Payload Definition
The following are initial samples of request/response data exchange using json payloads, and HTTP response behaviour 

### Request
The API should expect the following json payload containing a basic (info/debug) metadata together with the client-side validated user inputs
````
{
    "calculationInput": {
        "metadata": {
            "client": "calc",
            "version": "1234",
            "timestamp": "2022-06-22 14:32:56Z"
        },
        "inputs": { 
            "numericValues": [
                {"numericInput": "value", "culture": "romanNumerals", "notation": "decimal"},
                {"numericInput": "value", "culture": "romanNumerals", "notation": "decimal"}
            ], 
            "requiredCalculation":"addition",
            "requiredOutputFormatCulture":"arabic",
            "requiredOutputFormatNotation":"decimal",
          
        }
    }
}
````
using https://en.wikipedia.org/wiki/List_of_numeral_systems as a design reference





### Successful Calculation
The API should deliver the following json payload response containing a basic (info/debug) metadata together with the calculated result from the backend
````
{
    "calculationOutput": {
        "metadata": {
            "api": "calc",
            "version": "1234",
            "timestamp": "2022-06-22 14:32:58Z"
        },
        "receivedInputs": { 
            "numericValues": [
                {"numericInput": "value", "culture": "romanNumerals", "notation": "decimal"},
                {"numericInput": "value", "culture": "romanNumerals", "notation": "decimal"}
            ], 
            "requiredOutputFormatCulture":"romanNumerals",
            "requiredOutputFormatNotation":"decimal",
          
        },
        "calculatedOutputs": { 
            "numericCalculatedResult": [
                {"numericCalculatedResult": "value", "culture": "romanNumerals", "notation": "decimal"}
            ],
            "responseCode":"000",
          	"responseDescription":"Calculation Successful"
        }
    }
}
````
Result should return a 200 OK HTTP response




### Failed Calculation
The API should deliver the following json payload response containing a basic (info/debug) metadata together with the failed result from the backend
````
{
    "calculationOutput": {
        "metadata": {
            "api": "calc",
            "version": "1234",
            "timestamp": "2022-06-22 14:32:58Z"
        },
        "receivedInputs": { 
            "numericValues": [
                {"numericInput": "value", "culture": "romanNumerals", "notation": "decimal"},
                {"numericInput": "value", "culture": "romanNumerals", "notation": "decimal"}
            ], 
            "requiredOutputFormatCulture":"romanNumerals",
            "requiredOutputFormatNotation":"decimal",
          
        },
        "calculatedOutputs": { 
            "numericCalculatedResult": [
                {"numericCalculatedResult": "", "culture": "", "notation": ""}
            ],
            "responseCode":"500",
          	"responseDescription":"Calculation failed - roman numeral summation exceeds 3999"
        }
    }
}
````
Result should still be returned under a 200 OK response, as the request was correctly handled.


### Technically failed Request/Response
In the event of a technical client (4XX) or API (5XX) failure, the appropriate standard HTTP response codes should be returned.

  
----





----

# Build Approach
The following are the key highlights from the application build process

Pre-requisites:
 - node (https://nodejs.org/en/download/ and restart VS Code if needed)


 - open a new Terminal in VS Code
 - create a new dir and within it, run
 ````
 dotnet new react
 ````  
  - then
 ````
 dotnet run
 ````  
and the result is a running React app (using Node?), together with developerment server integration.

Stop the app (Ctrl+C) and then run

 ````
 dotnet publish
 ```` 
to populate the /publish directory

Then we can create a dockerfile in the 'sample001' project root with:
 ````
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY ./bin/Debug/net6.0/publish /app/

ENTRYPOINT ["dotnet","sample001.dll"]
 ```` 

and then we can build the docker image 
 - either 'docker build -t sample001:latest .' in the project root directory
 - or using VSCode, select the dockerfile, right click and 'build image ...'

and to prove it is complete, run ''docker images' and the image shoud be there at the top of the chronological list

Then run a container based on the image using
 ````
docker run -p 4000:80 sample001:latest
 ```` 

and you can visit the resulting containerized app at http://localhost:4000/

With a basic working solution we now want to productionize it by 

1, changing the csproj file
 - comment out/remove the "<Target Name="PublishRunWebpack" .... />" section 
 - update to wwwroot in the "<SpaRoot>wwwroot\</SpaRoot>" section 

2, updating the dockerfile to use the production dotnet sdk image, and the node image

 ````
FROM mcr.microsoft.com/dotnet/sdk:6.0 as dotnet-build
WORKDIR /src
COPY . /src
RUN dotnet restore "sample001.csproj"
RUN dotnet build "sample001.csproj" -c Release -o /app/build

FROM dotnet-build AS dotnet-publish
RUN dotnet publish "sample001.csproj" -c Release -o /app/publish

FROM node AS node-builder
WORKDIR /node
COPY ./ClientApp /node
RUN npm install
RUN npm build

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY ./bin/Debug/net6.0/publish /app/

ENTRYPOINT ["dotnet","sample001.dll"]
 ```` 

Note: Once these changes are made, to build the project using docker commands within the container, running 'dotnet build' and 'dotnet publish' on locally on the host will fail saying 'wwwroot' cannot be found




There is still the slight drawback that this is running on standard http:80, sot it would be nice to move to a non-standard port which can then be exposed on the container - so let us go with 5050.  To implement this, we need to tell the .net core Kestrl webserver to use 5050

FROM:
 ````
{
  "Logging": {
      "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
      }
    },
"AllowedHosts": "*"
}
 ```` 


TO:
 ````
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "Kestrel": {
    "Endpoints": {
      "Http":{
        "Url": "http://*:5050"
      }
    }
  }
}
 ```` 

by changing the root appsettings.json, saving and then run

 ````
dotnet publish
 ````


Once the appsettings.json(s) is updated/saved and the container image is rebuilt! 


then we can actually see the results by running:

 ````
docker run -p 4000:5050 sample001:latest
 ````
with the output 

 ````
MSBuild version 17.3.0+92e077650 for .NET
  Determining projects to restore...
  All projects are up-to-date for restore.
  sample002 -> C:\Users\maclennanj\Documents\jobs\dennemeyer\exercise\sample002\bin\Debug\net6.0\sample001.dll
  
  up to date, audited 1403 packages in 3s

  182 packages are looking for funding
    run `npm fund` for details

  7 high severity vulnerabilities

  To address issues that do not require attention, run:
    npm audit fix

  To address all issues (including breaking changes), run:
    npm audit fix --force

  Run `npm audit` for details.

  > sample001@0.1.0 build
  > react-scripts build

  Creating an optimized production build...
  Compiled successfully.

  File sizes after gzip:

    88.21 kB  build\static\js\main.5de0d5af.js
    24.44 kB  build\static\css\main.4b7a0b41.css
    1.78 kB   build\static\js\787.5486deb8.chunk.js

  The project was built assuming it is hosted at /.
  You can control this with the homepage field in your package.json.

  The build folder is ready to be deployed.
  You may serve it with a static server:

    npm install -g serve
    serve -s build

  Find out more about deployment here:

    https://cra.link/deployment

  sample001 -> C:\Users\maclennanj\Documents\jobs\dennemeyer\exercise\sample001\bin\Debug\net6.0\publish\
PS C:\Users\maclennanj\Documents\jobs\dennemeyer\exercise\sample001> docker run -p 4000:5050 sample002:latest
warn: Microsoft.AspNetCore.DataProtection.Repositories.FileSystemXmlRepository[60]
      Storing keys in a directory '/root/.aspnet/DataProtection-Keys' that may not be persisted outside of the container. Protected data will be unavailable when container is destroyed.
warn: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager[35]
      No XML encryptor configured. Key {765d4dec-c243-4b9e-8f22-b348d516deb7} may be persisted to storage in unencrypted form.
warn: Microsoft.AspNetCore.Server.Kestrel[0]
      Overriding address(es) 'http://+:80'. Binding to endpoints defined via IConfiguration and/or UseKestrel() instead.
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://[::]:5050
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /app/
 ````

where you can see the info "Now listening on: http://[::]:5050", so we are free to test at http://localhost:4000 (remember we exposed port 5050, and we want to see 5050 via the host's 4000 )

## Enabling for Typescript Development
At this point it is important to point out, that the "dotnet new react" scaffolding supports only javascript, and not Typescript. To add Typescript support we need to do the following:

 - in the ClientApp folder run:
 ````
npm install --save typescript @types/node @types/react @types/react-dom @types/jest
 ````
 - then take a copy of the files to be restored:
   -  .env 
   -  aspnetcore-https.js 
   -  aspnetcore-react.js
 - then from the root folder, run 
 ````
 rm -r ClientApp
 npx create-react-app clientapp --template typescript
 mv clientapp ClientApp
 ````
 (note the last command is to reintroduce the captial letters in the name, and dependinng on the OS behaviour and approach taken the details may vary slightly e.g. if using VSCode on Windows it may be easier to right-click and rename from the UI and accept the updates to the react 'import' statements )


- then return the copied files to the (new) ClientApp folder
- then in ClientApp\package.json add the following line inside "scripts:{}"
 ````
 "prestart": "node aspnetcore-https && node aspnetcore-react",
 ````


To check that the inclusion of Typescript was successful, run
````
dotnet publish

````
then rebuild the container image and run a docker container from it 
````
docker run -p 4000:5050 sample002:latest
````
and then browse http://localhost:4000.

This time, browsing will not show the previous sample dotnet page , but instead should show the Typescript page stating "Edit src/App.tsx and save to reload" plus the "Learn React" link to "https://reactjs.org/"

Then, if all is well, we can continue to focus on the specifics of the required "Roman Numbers Calculator"


----

# Application Design Approach
The aim is to produce a lightweight frontend for the application, and the decision was to produce a simple SPA (Single Page App) accessible from the root url.

Supporting the SPA, are a series of APIs available from the same host, which are differentiated using routes. For the sake of simplicity, the routes are currently limited to the design brief of 'addition' of numbers.



----




# Application Development Approach
With a suitable build process in place providing a satisfactory output, we are now ready to develop and test the application functionality required.

Note: dotnet's "dotnet new react" scaffolding approach with subsequent "npx create-react-app clientapp --template typescript" used above allows a fast, repeatable, standard approach for the basis of our required application, but it comes with sample "Weather Forecast" functionality which is a useful sample but is not required. More on removing this later.

As this is the first version of our application, with the possibility of future functionality, we define a specific route for our Roman Numerals Calculator' addition behaviour as "http://localhost:4000/api/1.0/addition". To introduce this, we do the following:




## Application Backend API Development
First we need to derive our API behaviour as outlined above.

We want to POST the values from the React SPA to the API http://localhost:4000/api/1.0/addition, and receive the corresponding response based on the submitted values and the required number system.

So it makes sense to being with an "API-first" development approach before moving to develop the SPA. 


The following steps are taken to create our backend API
1. we create a set of classes containing the attributes of our 'addition' request json and 'addition' response json.
2. we create a new controller to handle the our actual /addition API, which 
   1. expects to receive the POST request containing the 'addition' request json
   2. validates the json payload is correct in terms of desired action (match 'requiredCalculation' value with API route)
   3. validates the supplied numeric values are correct for the desired action
   4. then calculate and return the 'addition' response json
3. As well we introduce an Error controller just to provide a decent error handling experience and keep things DRY

Whilst the API design can expanded to cover other calculations (routes) beyond 'addition' and other number systems (requests/responses), we keep the demo to the following

 - input of two (or more) numeric values
 - in either romanNumeral or arabic cultures
 - supporting only decimal notation
 - providing an output with metadata, confirmation of the inputs received and the results in the requested culture and notation
 - we already introduce versioning with /1.0/ (although not strictly necessary for such a demo)


## Application Backend API Testing

As a prerequisite for this, we ensure we have a suitable approach for testing our basic API functionality. Whilst Curl would do, we can use Postman, as a more feature rich API testing tool with nice functionality to store/organize test cases (basically creating a series of collections, each containing the required requests to test the API). 

Having Postman available at the start of the development process allows us to capture and record the basic (unit) test cases as development progresses.







## Application Frontend Development
From the design outline above we want to have a simple React SPA with the required labels, fields and button CTA which looks nice, so this section covers meeting these requirements.

We already have a working API to interact with, so we have the basic API foundation to build the SPA against together with the basic UX and design sections already provided (above).  

 - First note 
   - the prior installation of Typescript with 'npm install --save typescript @types/node @types/react **@types/react-dom** @types/jest'
   - our classic React index.js is replaced with index.tsx
 - Our frontend development activity should be focused in dir '\ClientApp' where npm can be run from during development
 - We create a src/components directory and create specifc .tsx files per UI components
 - 


----
# TO BE CONTINUED
----






