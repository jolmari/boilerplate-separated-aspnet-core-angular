# Separated ASP.NET Core & Angular SPA boilerplate

A boilerplate used in Angular & ASP.NET Core solutions with a desire for separation of concerns.

## What is it about

This boilerplate demonstrates how to separate your ASP.NET Core backend and Angular frontend using [@angular/cli](https://github.com/angular/angular-cli)

Storing the scripts inside ASP.NET Core Web App projects proves tricky when there is a need to share modules/components/services between 
multiple Angular applications, or the developer needs to transpile one or multiple Angular applications to different
ASP.NET Core backends.

## Pre-requisites
1. [Node](https://nodejs.org/en/) 6.9.5 or higher, [NPM](https://www.npmjs.com/get-npm) 3 or higher
2. Global @angular/cli [installation](https://github.com/angular/angular-cli#installation)
3. Visual Studio 2017 with [ASP.NET Core development dependencies](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc)

## Quick start
1. Open the Backend.sln solution in Visual Studio 2017
2. Open command line & navigate to .\apps\sample-app
3. Execute "ng build" on the command line. Wait until build is finished.
4. Ctrl + F5 in visual studio
