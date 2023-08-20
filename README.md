# VatCalculatorFrontend

This frontend project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 16.2.0.

## Development server

Run `npm install` to install all the dependencies.

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The application will automatically reload if you change any of the source files.

## VatCalculatorBackend

This backend project was developed in .NET7 (core).

## Development server

Due to troubleshooting complications during the development on Mac, and to deliver the code in a timely manner, please run the application in development mode from Visual Studio. The frontend application also points at the port configured in that mode.

## Behind the scenes of the implementation

The idea behind the backend APIs is to simulate the existance of an internal company dashboard the uses the CRUD operations to manage the countries and their VAT rates. To avoid requiring to call the POST endpoint a set amount of times to populate the InMemory store, the GetAll endpoint has a workaround the returns a mocked enum until the POST endpoint is used.

