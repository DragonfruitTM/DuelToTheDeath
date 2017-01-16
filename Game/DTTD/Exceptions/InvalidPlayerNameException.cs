namespace DTTD.Exceptions
{
    using System;
    class InvalidPlayerNameException : ApplicationException
    {

        private const string DefaultMessage = "Player's name is not compatible with it's RaceType \n(Human: HumN_(input), Ork: RazL_(input), Undead: ZomB_(input))";

        public InvalidPlayerNameException() : base(DefaultMessage) { }

        public InvalidPlayerNameException(string message) : base(message) { }

        public InvalidPlayerNameException(string message, Exception innerException) : base(message, innerException) { }

    }
}

