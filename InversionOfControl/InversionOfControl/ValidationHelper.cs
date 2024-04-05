using BusinessLayer;

namespace InversionOfControl
{
    public class ValidationHelper(Speaker speaker)
    {
        public Speaker Speaker { get; set; } = speaker;

        public bool CheckGoodSpeker()
        {
            List<string> badDomains = ["aol.com", "hotmail.com", "prodigy.com", "CompuServe.com"];
            string currentEmailDomain = Speaker.Email.Split('@').Last();

            if (badDomains.Contains(currentEmailDomain))
            {
                return false;
            }

            if (Speaker.Experience > 10 
                || Speaker.HasBlog 
                || Speaker.Certifications.Count > 3 
                || Enum.IsDefined(typeof(Employers), Speaker.Employer))
            {
                return true;
            }
            return false;
        }

        public bool ApproveSessions()
        {
            List<string> technologies = ["Cobol", "Punch Cards", "Commodore", "VBScript"];
            if (
                Speaker.Sessions.Any(session => (technologies.Any(tech => session.Title.Contains(tech)))) 
                || Speaker.Sessions.Any(session => (technologies.Any(tech => session.Description.Contains(tech))))
            )
            {
                return false;
            }
            return true;
        }

        public void ValidateSpeaker()
        {
            if (string.IsNullOrWhiteSpace(Speaker.FirstName) 
                || string.IsNullOrWhiteSpace(Speaker.LastName) 
                || string.IsNullOrWhiteSpace(Speaker.Email))
            {
                throw new ArgumentNullException("First Name, Last Name and Email are required!");
            }

            if (Speaker.Sessions.Count == 0)
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
        }
    }
}
