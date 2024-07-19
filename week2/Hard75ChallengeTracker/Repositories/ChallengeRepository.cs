using System;
using System.Collections.Generic;
using System.Linq;
using ChallengeTracker.Models;

namespace ChallengeTracker.Repositories
{
    public class ChallengeRepository : IChallengeRepository
    {
        // List to store challenge entries
        private readonly List<ChallengeEntry> _entries = new List<ChallengeEntry>();

        // Add a new entry to the repository
        public void AddEntry(ChallengeEntry entry)
        {
            _entries.Add(entry); // Add the entry to the list
        }

        // Edit an existing entry in the repository
        public void EditEntry(ChallengeEntry entry)
        {
            // Find the existing entry by date
            var existingEntry = GetEntryByDate(entry.Date);
            if (existingEntry != null)
            {
                existingEntry.IsCompleted = entry.IsCompleted; // Update completion status
                existingEntry.Notes = entry.Notes; // Update notes
            }
        }

        // Get an entry by its date
        public ChallengeEntry GetEntryByDate(DateTime date)
        {
            // Find and return the entry that matches the given date
            return _entries.FirstOrDefault(e => e.Date.Date == date.Date);
        }

        // Get all entries for a specific month
        public List<ChallengeEntry> GetEntriesForMonth(int year, int month)
        {
            // Find and return all entries that match the given year and month
            return _entries.Where(e => e.Date.Year == year && e.Date.Month == month).ToList();
        }
    }
}
