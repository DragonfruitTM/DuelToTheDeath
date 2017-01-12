namespace DTTD.Exceptions
{
    using System;
    class InvalidPlayerNameException : ApplicationException
    {

        private const string DefaultMessage = "Player's name is not compatible with it's RaceType!";

        public InvalidPlayerNameException() : base(DefaultMessage) { }

        public InvalidPlayerNameException(string message) : base(message) { }

        public InvalidPlayerNameException(string message, Exception innerException) : base(message, innerException) { }

    }
}

