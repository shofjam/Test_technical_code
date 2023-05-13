using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using Newtonsoft.Json;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;

namespace TestTechnicalCode.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenerateController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<GenerateController> _logger;

        public GenerateController(ILogger<GenerateController> logger)
        {
            _logger = logger;
        }

        [Route("TaskNumber1")]
        [HttpGet]
        public IActionResult TaskNumber1(string inputText)
        {
            try
            {
                return Ok(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(inputText));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("Triangle")]
        [HttpGet]
        public IActionResult Triangle(string inputText)
        {
            try
            {
                List<string> result = new List<string>();
                for (int i = 0; i < inputText.Length; i++)
                {
                    string resultBuilder = inputText[i].ToString();
                    for (int j = 0; j < i + 1; j++)
                    {
                        resultBuilder += "0";
                    }
                    result.Add(resultBuilder.ToString());
                }
                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("OddNumbers")]
        [HttpGet]
        public IActionResult OddNumbers(int maxNumber)
        {
            try
            {
                List<string> result = new List<string>();
                for (int i = 0; i < maxNumber; i++)
                {
                    if ((i % 2) != 0)
                        result.Add(i.ToString());
                }
                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("PrimeNumbers")]
        [HttpGet]
        public IActionResult PrimeNumbers(int maxNumber)
        {
            try
            {
                List<int> result = new List<int>();
                for (int i = 0; i <= maxNumber; i++)
                {
                    bool isPrime = true; // Move initialization to here
                    for (int j = 2; j < i; j++) // you actually only need to check up to sqrt(i)
                    {
                        if (i % j == 0) // you don't need the first condition
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                    {
                        result.Add(i);
                    }
                    // isPrime = true;
                }

                return Ok(JsonConvert.SerializeObject(result));
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}