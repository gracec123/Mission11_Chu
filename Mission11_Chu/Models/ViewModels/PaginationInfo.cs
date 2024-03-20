﻿namespace Mission11_Chu.Models.ViewModels
{
    // Model to store pagination information
    public class PaginationInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        // Calculated property to determine the total number of pages
        public int TotalNumPages => (int) (Math.Ceiling((decimal)TotalItems / ItemsPerPage));
    }
}
