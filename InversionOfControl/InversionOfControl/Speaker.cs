// Kaloyan: unused usings should be removed
using System.Runtime.InteropServices.ComTypes;

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
        string employer
        ) : User(firstName, lastName, email) // Kaloyan: add a constructor and inherit from the base User class
    {
        // Kaloyan: should make a class IUser which will be used as a blueprint to the Speaker class

        private ushort _registrationFee;
        public ushort? Experience { get; set; } // Kaloyan: Exp changed to Experience and the value type to ushort
        public string BlogURL { get; set; } = blogUrl; // Kaloyan: add a parameter in the constructor
        public bool HasBlog { get => (BlogURL == string.Empty); }
        public WebBrowser? Browser { get; set; }
        public List<string> Certifications { get; set; } = certifications; // Kaloyan: add certifications in the constructor
        public string Employer { get; set; } = employer;
        public List<BusinessLayer.Session>? Sessions { get; set; }

        public ushort RegistrationFee
        {
            get => _registrationFee;

            set
            {

                if (Experience <= 1)
                {
                    _registrationFee = 500;
                }
                else if (Experience >= 2 && Experience <= 3)
                {
                    _registrationFee = 250;
                }
                else if (Experience >= 4 && Experience <= 5)
                {
                    _registrationFee = 100;
                }
                else if (Experience >= 6 && Experience <= 9)
                {
                    _registrationFee = 50;
                }
                else
                {
                    _registrationFee = 0;
                }
            }
        }
        
        public bool CheckGoodSpeker()
        {
            //DEFECT #5274 DA 12/10/2012
            //We weren't filtering out the prodigy domain so I added it.
            var domains = new List<string>() { "aol.com", "hotmail.com", "prodigy.com", "CompuServe.com" };
            string emailDomain = Email.Split('@').Last();

            if (domains.Contains(emailDomain) && ((Browser.Name == WebBrowser.BrowserName.InternetExplorer && Browser.MajorVersion < 9)))
            {
                return false;
            }
            //DFCT #838 Jimmy 
            //We're now requiring 3 certifications so I changed the hard coded number. Boy, programming is hard.
            if (Experience > 10 || HasBlog || Certifications.Count > 3 || Enum.IsDefined(typeof(Employers), Employer)) // Kaloyan: removing the brackets and add Emplyees enum check
            {
                return true;
            }
            return false;

        }

        public bool ApproveSessions()
        {
            var ot = new List<string>() { "Cobol", "Punch Cards", "Commodore", "VBScript" };

            foreach (var session in Sessions)
            {

                foreach (var tech in ot)
                {
                    if (session.Title.Contains(tech) || session.Description.Contains(tech))
                    {
                        session.Approved = false;
                        return false;
                    }
                    else
                    {
                        session.Approved = true;
                    }
                }
            }
            return true;

        }
        public void Register(IRepository repository)
        {
        /// <summary>
        /// Register a speaker
        /// </summary>

            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(Email))
            {
                throw new ArgumentNullException("First Name, Last Name and Email are required!");
            }

            if (Sessions.Count == 0)
            {
                throw new ArgumentException("Can't register speaker with no sessions to present.");
            }

            if (!CheckGoodSpeker())
            {
                throw new SpeakerDoesntMeetRequirementsException("Speaker doesn't meet our abitrary and capricious standards.");
            }

            if (!ApproveSessions())
            {
                throw new NoSessionsApprovedException("No sessions approved.");
            }

            try
            {
                Id = repository.SaveSpeaker(this);
            }
            catch (Exception e)
            {
                //in case the db call fails 
                Console.WriteLine(e.Message); // Kaloyan: added this print instead of nothing
            }
        }
        // Kaloyan: moving the custom Exceptions in a separate class
    }
}