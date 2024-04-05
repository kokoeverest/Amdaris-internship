namespace InversionOfControl
{
    internal class SpeakerRepository : IRepository
    {
        private List<Speaker> Repository { get; set; } = [];

        public int SaveSpeaker(Speaker speaker)
        {
            Repository.Add(speaker);

            return Repository.IndexOf(speaker) + 1;
        }
    }
}
