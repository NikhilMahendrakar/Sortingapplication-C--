using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using StudentSorter.Models;
using StudentSorter.Utilities;
using StudentSorter.ViewModels;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace StudentSorter.Controllers
{
    public class StudentController : Controller
    {
        private static List<List<string>> data;
        private static int numColumns;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile file, int numColumns)
        {
            if (file == null || file.Length == 0)
                return Content("File not selected");

            data = new List<List<string>>();
            StudentController.numColumns = numColumns;

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',').ToList();
                    data.Add(values);
                }
            }

            var model = new SelectFieldsViewModel
            {
                NumColumns = numColumns
            };

            return View("SelectFields", model);
        }

        [HttpPost]
        public IActionResult SortData(SelectFieldsViewModel model)
        {
            var sortColumn = model.SortColumn;

            var sortingResults = new List<SortingResult>
            {
                SortingAlgorithms.InsertionSort(data, sortColumn),
                SortingAlgorithms.SelectionSort(data, sortColumn),
                SortingAlgorithms.BubbleSort(data, sortColumn),
                SortingAlgorithms.MergeSort(data, sortColumn),
                SortingAlgorithms.QuickSort(data, sortColumn)
            };

            var resultsViewModel = new SortingResultsViewModel
            {
                SortingResults = sortingResults,
                NumColumns = numColumns
            };

            return View("Results", resultsViewModel);
        }
    }
}
