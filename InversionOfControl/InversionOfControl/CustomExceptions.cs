namespace InversionOfControl
{
    public class SpeakerDoesntMeetRequirementsException : Exception
    {
        public SpeakerDoesntMeetRequirementsException(string message)
            : base(message)
        {
        }

        public SpeakerDoesntMeetRequirementsException(string format, params object[] args) // Kaloyan: possibly another exception could occur here?
            : base(string.Format(format, args)) { }
    }

    public class NoSessionsApprovedException : Exception
    {
        public NoSessionsApprovedException(string message)
            : base(message)
        {
        }
    }
}
