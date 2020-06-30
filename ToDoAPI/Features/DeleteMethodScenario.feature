Feature: DeleteMethodScenario
   Check if the user is able to delete a todo using delete request 

@mytag
Scenario: Delete a todo 
	Given Create Request "/todos/{id}" with "DELETE" method	
	And Create endpoint for "id" with parameter <id>
	When  API request is executed
	Then the response code status should be <value> 
Examples: 
| id  | value |
| 25  | 200   |  
| 258 | 200   |
|     | 404   |