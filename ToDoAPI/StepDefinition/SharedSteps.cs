using RestSharp;
using System.Configuration;
using RestSharp.Serialization.Json;
using TechTalk.SpecFlow;
using System;
using NUnit.Framework;

namespace ToDoAPI.StepDefinition
{
    [Binding]
    public class SharedSteps
    {
        //region Define Public Variables
        public static RestClient apiClient = new RestClient(ConfigurationManager.AppSettings["ApiUrl"]);
        public static RestRequest apiRequest;
        public static IRestResponse apiResponse;
        //endregion

        [Given(@"Create Request ""(.*)"" with ""(.*)"" method")]
        public void GivenCreateRequestWithMethod(string request, Method method)
        {
            apiRequest = new RestRequest(request, method);
            apiRequest.RequestFormat = DataFormat.Json;
            Console.WriteLine("Request Created");
        }

        [When(@"API request is executed")]
        [Given(@"API request is executed")]
        public void APIRequesIsExecuted()
        {
            apiResponse = apiClient.Execute(apiRequest);
        }

        [Then(@"the response code status should be (.*)")]
        public void ThenResponseCodeStatusShouldBe(int status)
        {
            int responseCode = (int)apiResponse.StatusCode;
            Console.WriteLine("Response code is: " + responseCode);
            Assert.AreEqual(status, responseCode, "Response code is " + responseCode);
        }

        [Given(@"Create endpoint for ""(.*)"" with parameter (.*)")]
        public void GivenCreateEndpointForWithParameter(string apiSegment, string searchParameter)
        {

            apiRequest.AddUrlSegment(apiSegment, searchParameter);

        }
    }

}
