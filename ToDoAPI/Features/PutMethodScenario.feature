Feature: PutMethodScenario
	Check if the user is able to update data using PUT request 

@mytag
Scenario: update a todo with with valid id
	Given Create Request "/todos/{id}" with "PUT" method	
	And Create endpoint for "id" with parameter 25
	When  user adds the following data
	| userId | id | title      | completed |
	| 2      | 25 | Update Api | True      |
	And  API request is executed
	Then the response code status should be 200 
	And response body should have id as 25

Scenario: update a todo with with invalid id
	Given Create Request "todos/{id}" with "PUT" method	
	And Create endpoint for "id" with parameter <todoid>
	When  user adds the following data
	| userId | id | title      | completed |
	| 2      | 25 | Update Api | True      |
	And  API request is executed
	Then the response code status should be <value>	
Examples: 
| todoid | value |
| 900    | 500   |
|        | 404   |
	
