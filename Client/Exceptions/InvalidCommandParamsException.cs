#nullable enable
using System;

namespace Client.Exceptions
{
    public class InvalidCommandParamsException : Exception
    {
        public InvalidCommandParamsException(string? message) : base(message)
        {
        }
    }
}