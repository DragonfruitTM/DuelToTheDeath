using System;

namespace DuelToTheDeath.Exceptions
{
    class InadequateManaPointsException : ApplicationException
    {

        private const string DefaultMessage = "Player {0} has inadequate Mana points";

        public InadequateManaPointsException(string playerName)
            : base(string.Format(DefaultMessage, playerName))
        {

        }

        public InadequateManaPointsException (string playerName, Exception innerException) 
            : base(string.Format(DefaultMessage, playerName), innerException)
        {

        }

    }
}
