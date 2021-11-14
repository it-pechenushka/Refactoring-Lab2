using System;

namespace Server.Exceptions
{
    public class TrackNotFoundException : Exception
    {
        public TrackNotFoundException(string? message) : base(message)
        {
        }
    }
}