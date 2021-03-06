# Paylocity Benefits Calculator

The Paylocity Benefits Calculator is a simple web application that allows users to input and track employee benefits costs based of themselves and their dependents. Users can add, update, and remove employees and dependents and can also see up-to-date benefits calculations based off their most recent changes.

## Installation

Required to run:
  - NodeJs
  - VueJs
  - MS SQL Server LocalDb
  - C#/.NET Core 3.1

After installation, run:
  'npm install'
in the client-app directory. This should install all necessary node packages for the front end.

You may also need to set up the local database with the necessary tables. The BenefitsCalculator.SQLDatabase project should give the necessary scripts and tables needed to successfuly run the project. The Project is configured to use the '(localdb)\MSSQLLocalDB' local database. This configuration can be changed in the appsettings.json file.

## Potential Future Additions
 - User authenitication/login
 - True SPA layout, with App.vue managing flow and state between pages/actions
 - Proper pagination and/or table library integration
 - Unit and load testing
