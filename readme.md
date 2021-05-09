1. Clone project. 
2. Run project from Visual Studio. 
3. Create an environment variable with the key "secret" and any value you wish.
	- To create an environment variable, in Visual Studio Solution Explorer, right click the solution name "WeatherAPI", open "Properties", select "Debug" from the side menu, and using the "Add" button next to "Environment Variables" input box, enter the key "secret" and your desired value. 
4. Open Postman. 

## To Test Auth

1. Using Postman, send POST request to https://localhost:44338/weather. 
	- Body should include key/values for date, lat, lon, city, state, and temperature.
2. Postman return status 403, Forbidden. 
3. Using Postman, send POST request to https://localhost:44338/authenticate.
	- For body, use key/values for username and password.  In this case, ensure that the password is anything *BUT the reverse of the username*. 
4. Postman returns 401 Unauthorized, with JSON message value, "User or password invalid".
5. Using Postman, send POST request to https://localhost:44338/authenticate.
	- For body, use key/values for username and password.  In this case, ensure that the password is *the reverse of the username*. 
6. Postman return status 200 OK.  The body includes a token key with a string value. 
7. Copy and save the token value. 
8. Using Postman, send POST request to https://localhost:44338/weather.
	- Body should include key/values for date, lat, lon, city, state, and temperature.
	- In the Authorization tab, for type "Bearer Token", paste in the token value, not including quotation marks. 
9. Postman returns status code 200 OK, adds a unique ID to your weather object and adds it to the list of weather objects, and returns your weather object in the JSON body. 
10. If you send a GET request to https://localhost:44338/weather, Postman response includes array of weather objects, including your new weather objected, sorted by ID in ascending order. 


## To Get List of Weather Objects without Authenticating

1. Using Postman, send GET request to https://localhost:44338/weather
	- Postman returns status 200 OK with array of weather objects in the JSON response, sorted by ID in ascending order. 
	- This should be successful without bearer token value. 


## To Get Single Weather Object by ID without Authenticating

1. Using Postman, send GET request to https://localhost:44338/weather/0
	- Postman returns response with status code 200 OK and the weather object with 'id' of 0. 
2. Using Postman, send GET request to https://localhost:44338/weather/6 
	- Postman returns response with status code 404 Not Found because no weather object with 'id' of value 0 exists in the list. 

## To Delete a Weather Object by ID

1. Using Postman, send DELETE request to https://localhost:44338/weather/0 (or any other existing Id)
	- If no valid value exists for the Bearer Token, Postman provides response 403 Forbidden. 
2. If valid value exists for the Bearer Token, Postman provides response 204 No Content. 
3. Using Postman, send GET request to https://localhost:44338/weather/
4. Postman response includes list of weather objects, without the deleted weather object. 
6. Using Postman, send DELETE request to https://localhost:44338/weather/3435 (or any other nonexistent Id)
7. If valid value exists for the Bearer Token, Postman provides response 404 Not Found, because that Id is not valid in the list of weathers. 
