/*
 * DotAAS Part 2 | HTTP/REST | Entire API Collection
 *
 * The entire API collection as part of Details of the Asset Administration Shell Part 2
 *
 * OpenAPI spec version: V1.0RC03
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using IO.Swagger.V1RC03.Attributes;

using Microsoft.AspNetCore.Authorization;
using IO.Swagger.V1RC03.ApiModel;


namespace IO.Swagger.V1RC03.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class DescriptorApiController : ControllerBase, IDescriptorApiController
    { 
        /// <summary>
        /// Returns the self-describing information of a network resource (Descriptor)
        /// </summary>
        /// <response code="200">Requested Descriptor</response>
        /// <response code="0">Default error handling for unmentioned status codes</response>
        [HttpGet]
        [Route("/descriptor")]
        [ValidateModelState]
        [SwaggerOperation("GetDescriptor")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Descriptor>), description: "Requested Descriptor")]
        [SwaggerResponse(statusCode: 0, type: typeof(Result), description: "Default error handling for unmentioned status codes")]
        public virtual IActionResult GetDescriptor()
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<Descriptor>));

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0, default(Result));
            string exampleJson = null;
            exampleJson = null;
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<List<Descriptor>>(exampleJson)
                        : default(List<Descriptor>);            //TODO: Change the data returned
            return new ObjectResult(example);
        }
    }
}
