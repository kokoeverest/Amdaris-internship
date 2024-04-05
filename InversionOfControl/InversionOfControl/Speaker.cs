using BusinessLayer;

namespace InversionOfControl
{
    /// <summary>
    /// Represents a single speaker
    /// </summary>
    public class Speaker(
        string firstName,
        string lastName,
        string email,
        string blogUrl,
        List<string> certifications,
        string employer,
        List<Session> sessions
        ) : User(firstName, lastName, email)

    {
        //private ushort _registrationFee;
        public ushort Experience { get; set; } = 0;
        public string BlogUrl { get; } = blogUrl;
        public List<string> Certifications { get; } = certifications;
        public string Employer { get; } = employer;
        public List<Session> Sessions { get; } = sessions;
        public bool HasBlog => !string.IsNullOrEmpty(BlogUrl);

        public ushort RegistrationFee
        {
            get 
            {
                return Experience switch
                {
                    > 9 => 0,
                    >= 6 => 50,
                    >= 4 => 100,
                    >= 2 => 250,
                    _ => 500,
                };
            }
        }

        public void Register(IRepository repository)
        {
            /// <summary>
            /// Register a speaker
            /// </summary>
            ValidationHelper validationHelper = new (this);

            try
            {
                validationHelper.ValidateSpeaker();
                Id = repository.SaveSpeaker(this);
                Console.WriteLine("Speaker registered successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}