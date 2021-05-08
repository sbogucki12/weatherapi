1. Clone project. 
2. Run project from Visual Studio. 
3. Open Postman. 
4. Send POST Request to https://localhost:44338/authenticate
	- JSON Body should include keys of username and password. 
5. Try username value that is anything besides the reverse of the password value. 
	- Authentication should fail.  Status code = 401. 
6. Try username value that is reverse of password value. 
	- Authentication should be successful. Status code = 200.
	- Server returns token value. 
7. Copy token value. 
8. Prepare GET request to https://localhost:44338/weather
	- Do not enter any authorization value. 
	- Response should be unsuccessful. Status code = 401 Unauthorized. 
9. Prepare GET request to https://localhost:44338/weather
	- Paste token value in Authorization tab as type "Bearer Token". No quotes on the token value. 
	- Response should be successful.  Status code = 200.   Response = list of weather. 
