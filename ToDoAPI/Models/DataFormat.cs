using RestSharp.Serialization.Json;
using ToDoAPI.StepDefinition;

namespace ToDoAPI.Models
{
    public class DataFormat
    {

        //To serialize request body 
        public static  string Serializedata(ResponseObjects body)
        {           
            JsonSerializer serializer = new JsonSerializer();
            string jsonBody = serializer.Serialize(body);

            return (SharedSteps.apiRequest.AddJsonBody(jsonBody)).ToString();
        }
    }
}
