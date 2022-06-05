
# Stock Price Ticker Backend app

## General Setup
The backend code was build using .NET6, as such it is important that the necessary run time exists in the target machine.
Before running any of the serverside code, it is important to run `nuget restore` at solution level.
Once that is completed, it is recommended that the solution is built in Visual Studio.

## API
The API could be run using `dotnet run` command in the StockPriceMonitor.Api project or using Visual Studio and running the mentioned project as a startup project.


# Stock Price Ticker Frontend app

This is the react based frontend app which consumes the api backend. 
The app was scaffolded using the creat-react-app scaffolding tool. 
Please refer to the package.json for a list of other libraries used.

Prior to executing the available scripts, please ensure that `npm install` is run.

## Available Scripts

In the project directory, you can run:

### `npm start`

Runs the app in the development mode.\
Open [http://localhost:3000](http://localhost:3000) to view it in your browser.

The page will reload when you make changes.\
You may also see any lint errors in the console.

### `npm test`

Launches the test runner in the interactive watch mode.\
See the section about [running tests](https://facebook.github.io/create-react-app/docs/running-tests) for more information.