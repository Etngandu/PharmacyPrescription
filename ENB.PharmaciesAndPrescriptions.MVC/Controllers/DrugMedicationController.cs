using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using ENB.PharmaciesAndPrescriptions.Entities;
using ENB.PharmaciesAndPrescriptions.Entities.Repositories;
using ENB.PharmaciesAndPrescriptions.Infrastructure;
using ENB.PharmaciesAndPrescriptions.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ENB.PharmaciesAndPrescriptions.MVC.Controllers
{
    public class DrugMedicationController : Controller
    {       
        private readonly IAsyncDrugCompanyRepository _asyncDrugCompanyRepository;
        private readonly IAsyncUnitOfWorkFactory _asyncUnitOfWorkFactory;
        private readonly ILogger<DrugMedicationController> _logger;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyf;


        public DrugMedicationController(IAsyncDrugCompanyRepository asyncDrugCompanyRepository,
                           IAsyncUnitOfWorkFactory asyncUnitOfWorkFactory, 
                           ILogger<DrugMedicationController> logger, 
                           IMapper mapper,
                           INotyfService notyf)
        {
            _asyncDrugCompanyRepository = asyncDrugCompanyRepository;
            _asyncUnitOfWorkFactory = asyncUnitOfWorkFactory;
            _logger = logger;
            _mapper = mapper;
            _notyf= notyf;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List(int Drug_companyId)
        {
            ViewBag.IdDrgcp = Drug_companyId;
            var drug_Company = await _asyncDrugCompanyRepository.FindById(Drug_companyId);

            ViewBag.Message = drug_Company.Company_name;

            return View();
        }


        public async Task<IActionResult> GetDrugs_Medication(int Drug_companyId)
        {

            var drug_Company = await _asyncDrugCompanyRepository.FindById(Drug_companyId, x => x.Drug_Medications);

            ViewBag.Message = drug_Company.Company_name;

            var Mpdata = new List<DisplayDrugAndMedication>();

            _mapper.Map(drug_Company.Drug_Medications, Mpdata);

            return Json(new { data = Mpdata });


        }

        [HttpGet]
        public async Task<IActionResult> Create(int Drug_companyId)
        {
            ViewBag.drgcpId = Drug_companyId;

            var drug_Company = await _asyncDrugCompanyRepository.FindById(Drug_companyId);

            ViewBag.Message = drug_Company.Company_name;

            return View();
        }

        // POST: LawyerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAndEditDrugAndMedication createAndEditDrugAndMedication,
                                                  int Drug_companyId)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {
                        var drug_company = await _asyncDrugCompanyRepository.FindById(Drug_companyId);                       

                        Drug_medication drug_Medication = new();

                        _mapper.Map(createAndEditDrugAndMedication, drug_Medication);

                        drug_company.Drug_Medications.Add(drug_Medication);                       

                           _notyf.Success("Lawyer event Added  Successfully! ");

                        return RedirectToAction(nameof(List), new { Drug_companyId });
                    }
                }
                catch (ModelValidationException mvex)
                {
                    foreach (var error in mvex.ValidationErrors)
                    {
                        ModelState.AddModelError(error.MemberNames.FirstOrDefault() ?? "", error.ErrorMessage!);
                    }
                }
            }
            return View();
        }



        public async Task<IActionResult> Edit(int Drug_companyId, int id)
        {

            var drug_company = await _asyncDrugCompanyRepository.FindById(Drug_companyId);
            ViewBag.Message = drug_company.Company_name;
            ViewBag.DrugcpId = Drug_companyId;
            ViewBag.Id = id;

            var drug_medication = await _asyncDrugCompanyRepository.FindById(Drug_companyId, x=>x.Drug_Medications);

            if (drug_medication == null)
            {
                return NotFound();
            }

            CreateAndEditDrugAndMedication data = new CreateAndEditDrugAndMedication();



            _mapper.Map(drug_company.Drug_Medications.Single(x => x.Id == id), data);

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateAndEditDrugAndMedication createAndEditDrugAndMedication, int Drug_companyId)
        {

            ViewBag.DrgcpId = Drug_companyId;
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {

                        var drug_company = await _asyncDrugCompanyRepository.FindById(Drug_companyId, x => x.Drug_Medications);
                        var drug_medication = await Task.FromResult(drug_company.Drug_Medications.Single(x => x.Id == createAndEditDrugAndMedication.Id));

                        _mapper.Map(createAndEditDrugAndMedication, drug_medication);

                          _notyf.Success("Drug_Medication  updated Successfully");

                        return RedirectToAction(nameof(List), new { Drug_companyId });
                    }
                }
                catch (ModelValidationException mvex)
                {
                    foreach (var error in mvex.ValidationErrors)
                    {
                        ModelState.AddModelError(error.MemberNames.FirstOrDefault() ?? "", error.ErrorMessage!);
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> Details(int Drug_companyId, int id)
        {

            var drug_company = await _asyncDrugCompanyRepository.FindById(Drug_companyId);
           
            ViewBag.DrugcpId = Drug_companyId;
            ViewBag.Id = id;

            // var bldaprt = await _asyncApartBuildingRepository.FindById(apbldid, apbl => apbl.Apartments);

            var bldaprt = from a in _asyncDrugCompanyRepository.FindAll().Where(drgcp => drgcp.Id == Drug_companyId).SelectMany(drgmd => drgmd.Drug_Medications)
                          join drgcp in _asyncDrugCompanyRepository.FindAll() on a.Drug_companyId equals drgcp.Id
                          select new DisplayDrugAndMedication
                          {
                              Id = a.Id,
                              Drug_companyId = drgcp.Id,
                              Namecompany = drgcp.Company_name,
                              Drug_name = a.Drug_name,
                              Drug_cost = a.Drug_cost,
                              Drug_generic = a.Drug_generic,
                              DateCreated = a.DateCreated,
                              DateModified = a.DateModified,
                              Drug_available_date = a.Drug_available_date,
                              Drug_Withdrawn_date=a.Drug_Withdrawn_date,
                              Drug_description=a.Drug_description,
                              Other_drug_details=a.Other_drug_details,

                          };


            if (bldaprt == null)
            {
                return NotFound();
            }
            var data = new DisplayDrugAndMedication();

            var mydrug_medication = _mapper.Map(bldaprt.Single(x => x.Id == id), data);
            ViewBag.Message = mydrug_medication.Drug_name;
            // sglevent.Color = Enum.GetName(typeof(EventStatus), Int32.Parse(sglevent.Color));
            return View(mydrug_medication);
        }


        // GET: ApartmentController/Delete/5
        public async Task<IActionResult> Delete(int Drug_companyId, int id)
        {
            var drug_company = await _asyncDrugCompanyRepository.FindById(Drug_companyId);
            ViewBag.Message = drug_company.Company_name;
            ViewBag.DrugcpId = Drug_companyId;
            ViewBag.Id = id;

            // var bldaprt = await _asyncApartBuildingRepository.FindById(apbldid, apbl => apbl.Apartments);

            var bldaprt = from a in _asyncDrugCompanyRepository.FindAll().Where(drgcp => drgcp.Id == Drug_companyId).SelectMany(drgmd => drgmd.Drug_Medications)
                          join drgcp in _asyncDrugCompanyRepository.FindAll() on a.Drug_companyId equals drgcp.Id
                          select new DisplayDrugAndMedication
                          {
                              Id = a.Id,
                              Drug_companyId = drgcp.Id,
                              Namecompany = drgcp.Company_name,
                              Drug_name = a.Drug_name,
                              Drug_cost = a.Drug_cost,
                              Drug_generic = a.Drug_generic,
                              DateCreated = a.DateCreated,
                              DateModified = a.DateModified,
                              Drug_available_date = a.Drug_available_date,
                              Drug_Withdrawn_date = a.Drug_Withdrawn_date,
                              Drug_description = a.Drug_description,
                              Other_drug_details = a.Other_drug_details,

                          };


            if (bldaprt == null)
            {
                return NotFound();
            }
            var data = new DisplayDrugAndMedication();

            var mydrug_medication = _mapper.Map(bldaprt.Single(x => x.Id == id), data);

            // sglevent.Color = Enum.GetName(typeof(EventStatus), Int32.Parse(sglevent.Color));
            return View(mydrug_medication);
        }

        // POST: ApartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DisplayDrugAndMedication displayDrugAndMedication, int Drug_companyId)
        {
            // ViewBag.Case_Id = caseid;
            await using (await _asyncUnitOfWorkFactory.Create())
            {
                var drug_company = await _asyncDrugCompanyRepository.FindById(Drug_companyId, x => x.Drug_Medications);
                var drug_medication = drug_company.Drug_Medications.Single(x => x.Id == displayDrugAndMedication.Id);

                
                drug_company.Drug_Medications.Remove(drug_medication);

                 _notyf.Error("Drug_medication  removed  Successfully");
            }
            return RedirectToAction(nameof(List), new { Drug_companyId });
        }

    }
}
