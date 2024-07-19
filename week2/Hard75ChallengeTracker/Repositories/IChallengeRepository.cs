using System;
using System.Collections.Generic;
using ChallengeTracker.Models;

namespace ChallengeTracker.Repositories
{
    public interface IChallengeRepository
    {
        // Method to add a new entry to the repository
        void AddEntry(ChallengeEntry entry);

        // Method to edit an existing entry in the repository
        void EditEntry(ChallengeEntry entry);

        // Method to get an entry by its date
        ChallengeEntry GetEntryByDate(DateTime date);

        // Method to get all entries for a specific month
        List<ChallengeEntry> GetEntriesForMonth(int year, int month);
    }
}
