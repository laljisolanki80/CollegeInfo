using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeInfo.Core;
using CollegeInfo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace CollegeInfo.Pages.Colleges
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly ICollegeData collegeData;
        public string SearchTerm { get; set; }
        public IEnumerable<College> Colleges { get; set; }
        public ListModel(IConfiguration config,ICollegeData collegeData)
        {
            this.config = config;
            this.collegeData = collegeData;
        }
        public void OnGet(string SearchTerm)
        {
           Colleges = collegeData.GetCollegeByName(SearchTerm);
            Colleges = collegeData.GetCollegeByCity(SearchTerm);
           //Colleges = collegeData.GetCollegeByDepartment(SearchTerm);
             }
    }
    
}