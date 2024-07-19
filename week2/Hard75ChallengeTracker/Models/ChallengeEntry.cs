namespace ChallengeTracker.Models
{
    public class ChallengeEntry
    {
        // Property to store the date of the entry
        public DateTime Date { get; set; }

        // Property to store the completion status of the challenge
        public bool IsCompleted { get; set; }

        // Property to store any additional notes for the entry
        public string Notes { get; set; }

        // Constructor to initialize a new ChallengeEntry object
        public ChallengeEntry(DateTime date, bool isCompleted, string notes)
        {
            Date = date; // Set the date of the entry
            IsCompleted = isCompleted; // Set the completion status
            Notes = notes; // Set the notes
        }
    }
}
