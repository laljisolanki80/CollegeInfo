using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeInfo.Core;
using CollegeInfo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollegeInfo.Pages.Colleges
{
    public class EditModel : PageModel
    {
        private readonly ICollegeData collegeData;
        private readonly IHtmlHelper htmlHelper;
        public College College { get; set; }
        public IEnumerable<SelectListItem> DepartmentOfCollege { get; set; }

        public EditModel(ICollegeData collegeData,IHtmlHelper htmlHelper)
        {
            this.collegeData = collegeData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? Id)
        {
            DepartmentOfCollege = htmlHelper.GetEnumSelectList<DepartmentOfCollege>();
            if (Id.HasValue)
            {
                College = collegeData.GetCollegeById(Id.Value);
            }
            else
            {
                College = new College();

            }
            if (College == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                DepartmentOfCollege = htmlHelper.GetEnumSelectList<DepartmentOfCollege>();
                return Page();
            }
            if (College.Id > 0)
            {
                collegeData.Update(College);
            }
            else
            {
                collegeData.Add(College);
            }
            TempData["Message"] = "Restaurant is saved!";
            collegeData.Commit();
            return RedirectToPage("./Detail", new { RestaurantId = College.Id });

        }
    }
    }
