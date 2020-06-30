Feature: PostMethodScenario
	Check if the user is able to submit a POST request to ToDo API

@mytag
Scenario: post a todo with no body
	Given Create Request "/todos" with "POST" method
	When request body is empty
    And  API request is executed
    Then the response code status should be 201
	And  response body should have id as 201
	

Scenario: post a todo with body
	Given  Create Request "/todos" with "POST" method
	When  user adds the following data
	| userId | id | title    | completed |
	| 2      | 25 | Test Api | True      |
	And  API request is executed
	Then the response code status should be 201
	And response body should have id as 201
