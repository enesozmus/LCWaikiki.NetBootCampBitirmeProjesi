﻿using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace LCWaikikiFinal.API.Middleware;

public class ErrorHandlerMiddleware
{
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public ErrorHandlerMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
                _next = next;
                _env = env;
        }

        public async Task Invoke(HttpContext context)
        {
                try
                {
                        await _next(context);
                }
                catch (ValidationException ex)
                {
                        var problemDetails = GetBadRequestValidationProblemDetails(ex);

                        var response = context.Response;
                        response.ContentType = "application/json";
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await response.WriteAsync(JsonSerializer.Serialize(problemDetails));
                }
                catch (Exception ex)
                {
                        var response = context.Response;
                        response.ContentType = "application/json";
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        ProblemDetails problemDetails = GetProblemDetails(ex);

                        await response.WriteAsync(JsonSerializer.Serialize(problemDetails));
                }
        }

        private ProblemDetails GetProblemDetails(Exception ex)
        {
                string traceId = Guid.NewGuid().ToString();

                if (_env.EnvironmentName == "Development")
                {
                        return new ProblemDetails
                        {
                                Status = (int)HttpStatusCode.InternalServerError,
                                Type = "https://httpstatuses.com/500",
                                Title = ex.Message,
                                Detail = ex.ToString(),
                                Instance = traceId
                        };
                }
                else
                {
                        return new ProblemDetails
                        {
                                Status = (int)HttpStatusCode.InternalServerError,
                                Type = "https://httpstatuses.com/500",
                                Title = "Something went wrong. Please try after some time",
                                Detail = @"We apologize for inconvenience. Please let us know about the error at support@orion.com. Include traceId: {traceId} in email",
                                Instance = traceId
                        };
                }
        }

        private ValidationProblemDetails GetBadRequestValidationProblemDetails(ValidationException ex)
        {
                string traceId = Guid.NewGuid().ToString();

                var errors = new Dictionary<string, string[]>();
                foreach (var error in ex.Errors)
                {
                        errors.Add(error.PropertyName, new string[] { error.ErrorMessage });
                }

                var validationProblemDetails = new ValidationProblemDetails(errors);

                validationProblemDetails.Status = (int)HttpStatusCode.BadRequest;
                validationProblemDetails.Type = "https://httpstatuses.com/400";
                validationProblemDetails.Title = "Validation failed";
                validationProblemDetails.Detail = "One or more inputs need to be corrected. Check errors for details";
                validationProblemDetails.Instance = traceId;

                return validationProblemDetails;
        }

}
