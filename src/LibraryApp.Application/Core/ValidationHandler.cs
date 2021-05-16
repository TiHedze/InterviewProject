namespace LibraryApp.Application.Core
{
    using FluentValidation;
    using FluentValidation.Results;
    using LibraryApp.Application.Contract.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Text.Json;

    public static class ValidationHandler
    {
        public static (int code, string error) Handle(Exception exception)
        {
            if (exception is NotFoundException)
            {
                return (404, "Not found.");
            }

            if (exception is ValidationException validationException)
            {
                Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

                foreach (ValidationFailure error in validationException.Errors)
                {
                    if (dictionary.ContainsKey(error.PropertyName))
                    {
                        dictionary[error.PropertyName].Add(error.ErrorMessage);
                    }
                    else
                    {
                        dictionary.Add(error.PropertyName, new List<string>() { error.ErrorMessage });
                    }
                }

                return (400, JsonSerializer.Serialize(dictionary));
            }

            return (500, JsonSerializer.Serialize(new { error = "An unexpected error occurred." }));
        }
    }
}