using NUnit.Framework;
using System;
using RestSharp;
using RestSharp.Serialization.Json;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow;
using ToDoAPI.Models;
using System.Collections.Generic;


namespace ToDoAPI.StepDefinition
{
    [Binding]
    public class GetMethodScenario
    {

        [Then(@"check if the list count is (.*)")]
        public void Gettodos(int totaltodos)
        {
            //To get  all the todo list from JSON response body
            IRestResponse<List<ResponseObjects>> Response = SharedSteps.apiClient.Get<List<ResponseObjects>>(SharedSteps.apiRequest);
            Assert.AreEqual(totaltodos, Response.Data.Count, "Count not equal to 200");
            Console.WriteLine("Total number of todos is " + Response.Data.Count);

        }


        [Then(@"all mandatory fields")]
        public void ThenAllMandatoryFields(Table table)
        {
            ResponseObjects details = table.CreateInstance<ResponseObjects>();

            // Deserialize JSON response body
            ResponseObjects toDoResponse = new JsonDeserializer().Deserialize<ResponseObjects>(SharedSteps.apiResponse);

            Assert.AreEqual(details.userId, toDoResponse.userId, "UserID is not correct");
            Assert.AreEqual(details.id, toDoResponse.id, "ID is not correct");
            Assert.AreEqual(details.title, toDoResponse.title, "Title is not correct");
            Assert.AreEqual(details.completed, toDoResponse.completed, "Completed status is not correct");
        }




    }
}
