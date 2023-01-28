using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using ENB.PharmaciesAndPrescriptions.Entities.Repositories;
using ENB.PharmaciesAndPrescriptions.Entities;
using ENB.PharmaciesAndPrescriptions.Infrastructure;
using ENB.PharmaciesAndPrescriptions.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ENB.PharmaciesAndPrescriptions.MVC.Controllers
{
    public class PhysicianController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<PhysicianController> _logger;
        private readonly IAsyncPhysicianRepository _asyncPhysicianRepository;
        private readonly IAsyncUnitOfWorkFactory _asyncUnitOfWorkFactory;
        private readonly INotyfService _notyf;
        public PhysicianController(IMapper mapper, ILogger<PhysicianController> logger,
                                   IAsyncPhysicianRepository asyncPhysicianRepository,
                                   IAsyncUnitOfWorkFactory asyncUnitOfWorkFactory,
                                   INotyfService notyf)
        {
            _mapper = mapper;
            _logger = logger;
            _asyncPhysicianRepository = asyncPhysicianRepository;
            _asyncUnitOfWorkFactory = asyncUnitOfWorkFactory;
            _notyf = notyf;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetPhysicianData()
        {
            IQueryable<Physician> allPhysician = _asyncPhysicianRepository.FindAll();

            var Mpdata = _mapper.Map<List<DisplayPhysician>>(allPhysician).ToList();
            await Task.FromResult(Mpdata);
            return Json(new { data = Mpdata });
        }

        // GET: CustomerController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.Id = id;

            _logger.LogError($"Id :{id} of Customer not found");

            Physician dbPhysician = await _asyncPhysicianRepository.FindById(id);

            ViewBag.Message = dbPhysician.FullName;

            _logger.LogInformation($"Details of Physician: {ViewBag.Message}");

            if (dbPhysician == null)
            {
                return NotFound();
            }

            var data = _mapper.Map<DisplayPhysician>(dbPhysician);

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
        public async Task<IActionResult> Create(CreateAndEditPhysician createAndEditPhysician)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {

                        Physician dbPhysician = new();

                        _mapper.Map(createAndEditPhysician, dbPhysician);
                        await _asyncPhysicianRepository.Add(dbPhysician);

                        _notyf.Success("Physician Created  Successfully! ");

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

           

            Physician dbPhysician = await _asyncPhysicianRepository.FindById(id);

            if (dbPhysician == null)
            {
               _logger.LogError($"Physician {id} not found");
                return NotFound();
            }
            var data = await Task.FromResult(_mapper.Map<CreateAndEditPhysician>(dbPhysician));

            return View(data);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateAndEditPhysician createAndEditPhysician)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {

                        Physician dbPhysicianToUpdate = await _asyncPhysicianRepository.FindById(createAndEditPhysician.Id);

                        _mapper.Map(createAndEditPhysician, dbPhysicianToUpdate, typeof(CreateAndEditPhysician), typeof(Physician));

                        _notyf.Success("Physician Updated  Successfully! ");

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
            Physician dbPhysician = await _asyncPhysicianRepository.FindById(id);
            ViewBag.Message = dbPhysician.FullName;

            if (dbPhysician == null)
            {
                return NotFound();
            }
            var data = _mapper.Map<DisplayPhysician>(dbPhysician);
            return View(data);
        }

        // POST: CustomerController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Physician dbPhysician = await _asyncPhysicianRepository.FindById(id);
            await using (await _asyncUnitOfWorkFactory.Create())
            {
                _asyncPhysicianRepository.Remove(dbPhysician);

                _notyf.Error("Customer Removed  Successfully! ");
            }

            return RedirectToAction(nameof(Index)); ;
        }
    }
}
