using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using ENB.PharmaciesAndPrescriptions.Entities.Repositories;
using ENB.PharmaciesAndPrescriptions.Entities;
using ENB.PharmaciesAndPrescriptions.Infrastructure;
using ENB.PharmaciesAndPrescriptions.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ENB.PharmaciesAndPrescriptions.MVC.Controllers
{
    public class DrugCompanyController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<DrugCompanyController> _logger;
        private readonly IAsyncDrugCompanyRepository _asyncDrugCompanyRepository;
        private readonly IAsyncUnitOfWorkFactory _asyncUnitOfWorkFactory;
        private readonly INotyfService _notyf;
        public DrugCompanyController(IMapper mapper, ILogger<DrugCompanyController> logger,
                                   IAsyncDrugCompanyRepository asyncDrugCompanyRepository,
                                   IAsyncUnitOfWorkFactory asyncUnitOfWorkFactory,
                                   INotyfService notyf)
        {
            _mapper = mapper;
            _logger = logger;
            _asyncDrugCompanyRepository = asyncDrugCompanyRepository;
            _asyncUnitOfWorkFactory = asyncUnitOfWorkFactory;
            _notyf = notyf;
        }

        // GET: DrugCompanyController
        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetDrugCompanyData()
        {
            IQueryable<Drug_company> allDrugcompanies = _asyncDrugCompanyRepository.FindAll();

            var Mpdata = _mapper.Map<List<DisplayDrugCompany>>(allDrugcompanies).ToList();
            await Task.FromResult(Mpdata);
            return Json(new { data = Mpdata });
        }

        // GET: CustomerController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.Id = id;

            _logger.LogError($"Id :{id} of Customer not found");

            Drug_company dbDrug_company = await _asyncDrugCompanyRepository.FindById(id);

            ViewBag.Message = dbDrug_company.Company_name;

            _logger.LogInformation($"Details of DrugCompany: {ViewBag.Message}");

            if (dbDrug_company == null)
            {
                return NotFound();
            }

            var data = _mapper.Map<DisplayDrugCompany>(dbDrug_company);

            return View(data);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAndEditDrugCompany createAndEditDrugCompany)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {

                        Drug_company dbDrug_company = new();

                        _mapper.Map(createAndEditDrugCompany, dbDrug_company);
                        await _asyncDrugCompanyRepository.Add(dbDrug_company);

                        _notyf.Success("Drug_company Created  Successfully! ");

                        return RedirectToAction("Index");
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

        // GET: CustomerController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {



            Drug_company dbDrug_company = await _asyncDrugCompanyRepository.FindById(id);

            if (dbDrug_company == null)
            {
                _logger.LogError($"Drug_company {id} not found");
                return NotFound();
            }
            var data = await Task.FromResult(_mapper.Map<CreateAndEditDrugCompany>(dbDrug_company));

            return View(data);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateAndEditDrugCompany createAndEditDrugCompany)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {

                        Drug_company dbDrug_companyToUpdate = await _asyncDrugCompanyRepository.FindById(createAndEditDrugCompany.Id);

                        _mapper.Map(createAndEditDrugCompany, dbDrug_companyToUpdate, typeof(CreateAndEditDrugCompany), typeof(Drug_company));

                        _notyf.Success("Drug_company Updated  Successfully! ");

                        return RedirectToAction(nameof(Index));
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

        // GET: CustomerController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Drug_company dbDrug_company = await _asyncDrugCompanyRepository.FindById(id);
            ViewBag.Message = dbDrug_company.Company_name;

            if (dbDrug_company == null)
            {
                return NotFound();
            }
            var data = _mapper.Map<DisplayDrugCompany>(dbDrug_company);
            return View(data);
        }

        // POST: CustomerController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Drug_company dbDrug_company = await _asyncDrugCompanyRepository.FindById(id);
            await using (await _asyncUnitOfWorkFactory.Create())
            {
                _asyncDrugCompanyRepository.Remove(dbDrug_company);

                _notyf.Error("Drug_company Removed  Successfully! ");
            }

            return RedirectToAction(nameof(Index)); ;
        }
    }
}
