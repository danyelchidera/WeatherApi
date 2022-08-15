# WeatherApi
When weather forecast is requested for a particular city, the data is gotten from an external api and save in the database and refreshed every 15min.
Further request for forecast for that city is then send back directly from the db.
Further forecast for other cities can be requested, all these cities forecasts are tracked/stored in the db and refreshed
A city can be removed so that forecast for that city is no longer updated or tracked in the db
