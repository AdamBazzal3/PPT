﻿using CsvHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using PPT.Models;
using PPT.Repositories;
using System.Configuration;
using System.Globalization;

namespace PPT.Pages
{
    [Authorize(Roles = "Administrator")]
    public class ImportdataModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<User> _userManager;
        private readonly IRepository<Doctor> _doctorRepository;

        public ImportdataModel(IWebHostEnvironment environment, UserManager<User> userManager, IRepository<Doctor> doctorRepository)
        {
            _environment = environment;
            _userManager = userManager;
            _doctorRepository = (SqlServerRepository<Doctor>)doctorRepository;
        }

        [BindProperty]
        public IFormFile UploadFile { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FileContent { get; set; }
        public List<Doctor>? Doctors { get; set; } = new List<Doctor>();


        public void OnGet(String _FileContent)
        {
            FileContent = _FileContent;
        }
        public IActionResult OnPost()
        {
            if (UploadFile == null || UploadFile.Length <= 0)
            {
                ModelState.AddModelError(string.Empty, "الملف فارغ أو غير موجود");
                return Page();
            }
            if (UploadFile != null && UploadFile.Length > 0)
            {
                using (var reader = new StreamReader(UploadFile.OpenReadStream()))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    while (csv.Read())
                    {
                        if (!int.TryParse(csv.GetField<string>(0), out _))
                        {
                            FileContent += "��� �� ����� ��������� �� ��� �����";
                            FileContent += "\n";
                            continue;
                        }
                        Doctor doctor = new Doctor();
                        doctor.UniversityId = csv.GetField<string>(2);
                        doctor.Name = csv.GetField<string>(1);
                        doctor.IsContracted = bool.Parse(csv.GetField<string>(3));
                        doctor.DepartmentID = int.Parse(csv.GetField<string>(4));
                        Doctors.Add(doctor);
                        FileContent = FileContent + "�� ����� ��� ���� ������� " + doctor.Name;
                        FileContent += "\n";
                    }
                    _doctorRepository.InsertAllAsync(Doctors).GetAwaiter().GetResult();

                }
            }
            return RedirectToPage("Importdata", new { _FileContent = FileContent });

        }
    }
}