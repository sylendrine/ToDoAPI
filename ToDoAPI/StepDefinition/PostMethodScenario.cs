
using NUnit.Framework;
using RestSharp.Serialization.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ToDoAPI.Models;
using ToDoAPI.Util;


namespace ToDoAPI.StepDefinition
{
    [Binding]
    class PostMethodScenario
    {

        [When(@"request body is empty")]
        public void WhenRequestBodyIsEmpty()
        {
            var body = new ResponseObjects()
            {
                //empty body
            };

            DataFormat.Serializedata(body);
        }

        [When(@"user adds the following data")]
        public void WhenUserAddsTheFollowingData(Table table)
        {
            ResponseObjects details = table.CreateInstance<ResponseObjects>();

            var body = new ResponseObjects()
            {
                userId = details.userId,
                id = details.id,
                title = details.title,
                completed = details.completed
            };

            DataFormat.Serializedata(body);

        }

        [Then(@"response body should have id as (.*)")]
        public void ThenResponseBodyShouldHaveIdAs(string newid)
        {

            ResponseObjects postResponse = new JsonDeserializer().Deserialize<ResponseObjects>(SharedSteps.apiResponse);

            Assert.AreEqual(newid, postResponse.id, "ID is not correct");
        }



    }
}
