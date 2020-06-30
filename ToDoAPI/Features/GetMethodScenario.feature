Feature: GetMethodScenario
	 Check if the user is able to submit GET request to  ToDo API

Scenario: Request all available Todo
	Given Create Request "/todos" with "GET" method	
	When API request is executed
    Then the response code status should be 200 
	And check if the list count is 200

Scenario: Retrieve single valid  Todo by id
    Given Create Request "/todos/{id}" with "GET" method
    And Create endpoint for "id" with parameter 25
	When  API request is executed
	Then the response code status should be 200 
	And all mandatory fields 
   | userId | id | title                                             | completed |
   | 2      | 25 | voluptas quo tenetur perspiciatis explicabo natus | True      |

Scenario: Retrieve single invalid  Todo by id
    Given Create Request "/todos/{id}" with "GET" method
    And Create endpoint for "id" with parameter 500
	When  API request is executed
	Then the response code status should be 404 