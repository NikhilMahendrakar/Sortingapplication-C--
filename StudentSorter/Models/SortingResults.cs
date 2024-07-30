using System.Collections.Generic;

namespace StudentSorter.Models
{
    public class SortingResult
    {
        public string Algorithm { get; set; }
        public double Duration { get; set; }
        public int Comparisons { get; set; }
        public int Swaps { get; set; }
        public List<List<string>> SortedData { get; set; }
    }
}
