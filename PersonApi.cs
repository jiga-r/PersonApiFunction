using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace PersonDetails
{
    public static class PersonApi
    {
        [FunctionName("PersonApi")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            using (TextReader reader = new StringReader(requestBody))
            {
                var person = (Person)serializer.Deserialize(reader);
                return new OkObjectResult(person);
            }
        }
    }
}
