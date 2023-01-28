using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using ENB.PharmaciesAndPrescriptions.Entities.Repositories;
using ENB.PharmaciesAndPrescriptions.Entities;
using ENB.PharmaciesAndPrescriptions.Infrastructure;
using ENB.PharmaciesAndPrescriptions.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using ENB.PharmaciesAndPrescriptions.Entities.Collections;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ENB.PharmaciesAndPrescriptions.MVC.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly IAsyncCustomerRepository _asyncCustomerRepository;
        private readonly IAsyncPhysicianRepository _asyncPhysicianRepository;
        private readonly IAsyncUnitOfWorkFactory _asyncUnitOfWorkFactory;
        private readonly ILogger<PrescriptionController> _logger;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyf;


        public PrescriptionController(IAsyncCustomerRepository asyncCustomerRepository,
                              IAsyncPhysicianRepository asyncPhysicianRepository,
                           IAsyncUnitOfWorkFactory asyncUnitOfWorkFactory,
                           ILogger<PrescriptionController> logger,
                           IMapper mapper,
                           INotyfService notyf)
        {
            _asyncCustomerRepository = asyncCustomerRepository;
            _asyncPhysicianRepository= asyncPhysicianRepository;
            _asyncUnitOfWorkFactory = asyncUnitOfWorkFactory;
            _logger = logger;
            _mapper = mapper;
            _notyf = notyf;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List(int CustomerId)
        {
            ViewBag.Idcustm = CustomerId;
            var customer = await _asyncCustomerRepository.FindById(CustomerId);

            ViewBag.Message = customer.FullName;

            return View();
        }


        public async Task<IActionResult> GetPrescriptions(int CustomerId)
        {

            var customer = await _asyncCustomerRepository.FindById(CustomerId, x => x.Prescriptions);

            ViewBag.Message = customer.FullName;

            var Mpdata = new List<DisplayPrescription>();

            _mapper.Map(customer.Prescriptions, Mpdata);

            return Json(new { data = Mpdata });


        }

        [HttpGet]
        public async Task<IActionResult> Create(int CustomerId)
        {
            ViewBag.Idcustm = CustomerId;

            var data = new CreateAndEditPrescription()
            {
               
                ListPhysicians = _asyncPhysicianRepository.FindAll()
                      .Select(d => new SelectListItem
                      {
                          Text = d.FullName,
                          Value = d.Id.ToString(),
                          Selected = true

                      }).Distinct().ToList()

            };

            var customer = await _asyncCustomerRepository.FindById(CustomerId);

            ViewBag.Message = customer.FullName;

            return View(data);
        }

        // POST: LawyerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAndEditPrescription createAndEditPrescription,
                                                  int CustomerId)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {
                        var customer = await _asyncCustomerRepository.FindById(CustomerId);
                        
                        Prescription prescription= new();

                        _mapper.Map(createAndEditPrescription, prescription);

                        customer.Prescriptions.Add(prescription);

                        _notyf.Success("Prescription  Added  Successfully! ");

                        return RedirectToAction(nameof(List), new { CustomerId });
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



        public async Task<IActionResult> Edit(int CustomerId, int id)
        {

            var customer = await _asyncCustomerRepository.FindById(CustomerId);
            ViewBag.Message = customer.FullName;
            ViewBag.Idcustm = CustomerId;
            ViewBag.Id = id;

            var prescriptions = await _asyncCustomerRepository.FindById(CustomerId, x => x.Prescriptions);

            if (prescriptions == null)
            {
                return NotFound();
            }

            var data = new CreateAndEditPrescription()
            {

                ListPhysicians = _asyncPhysicianRepository.FindAll()
                     .Select(d => new SelectListItem
                     {
                         Text = d.FullName,
                         Value = d.Id.ToString(),
                         Selected = true

                     }).Distinct().ToList()

            };

            
                     


            _mapper.Map(customer.Prescriptions.Single(x => x.Id == id), data);

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateAndEditPrescription createAndEditPrescription,
                                            int CustomerId)
        {

            ViewBag.Idcustm = CustomerId;
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {

                        var customer = await _asyncCustomerRepository.FindById(CustomerId, x => x.Prescriptions);
                        var prescription = await Task.FromResult(customer.Prescriptions.Single(x => x.Id == createAndEditPrescription.Id));

                        _mapper.Map(createAndEditPrescription, prescription);

                        _notyf.Success("Prescription updated Successfully");

                        return RedirectToAction(nameof(List), new { CustomerId });
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

        public async Task<IActionResult> Details(int CustomerId, int id)
        {

            var customer = await _asyncCustomerRepository.FindById(CustomerId);

            ViewBag.Idcustm = CustomerId;
            ViewBag.Id = id;           

            var Listprescritions = from p in _asyncCustomerRepository.FindAll().Where(c => c.Id == CustomerId).SelectMany(x => x.Prescriptions)
                          join c in _asyncCustomerRepository.FindAll() on p.CustomerId equals c.Id
                          join ph in _asyncPhysicianRepository.FindAll() on p.PhysicianId equals ph.Id
                          select new DisplayPrescription
                          {
                              Id = p.Id,
                              CustomerId = c.Id,
                              PhysicianName=ph.FullName,
                              CustomerName=c.FullName,
                              PrescriptionNumber=p.PrescriptionNumber,
                              Presciption_issue_date = p.Presciption_issue_date,
                              Presciption_filled_date = p.Presciption_filled_date,
                              Payment_Method = p.Payment_Method,
                              Prescription_Status = p.Prescription_Status,
                              DateCreated= p.DateCreated,
                              DateModified= p.DateModified,
                          };


            if (Listprescritions == null)
            {
                return NotFound();
            }
            var data = new DisplayPrescription();

            var prescription = _mapper.Map(Listprescritions.Single(x => x.Id == id), data);
            ViewBag.Message = prescription.CustomerName;
           
            return View(prescription);
        }


        // GET: ApartmentController/Delete/5
        public async Task<IActionResult> Delete(int CustomerId, int id)
        {
            var customer = await _asyncCustomerRepository.FindById(CustomerId);

            ViewBag.Idcustm = CustomerId;
            ViewBag.Id = id;

            var Listprescritions = from p in _asyncCustomerRepository.FindAll().Where(c => c.Id == CustomerId).SelectMany(x => x.Prescriptions)
                                   join c in _asyncCustomerRepository.FindAll() on p.CustomerId equals c.Id
                                   join ph in _asyncPhysicianRepository.FindAll() on p.PhysicianId equals ph.Id
                                   select new DisplayPrescription
                                   {
                                       Id = p.Id,
                                       CustomerId = c.Id,
                                       PrescriptionNumber = p.PrescriptionNumber,
                                       PhysicianName = ph.FullName,
                                       CustomerName = c.FullName,
                                       Presciption_issue_date = p.Presciption_issue_date,
                                       Presciption_filled_date = p.Presciption_filled_date,
                                       Payment_Method = p.Payment_Method,
                                       Prescription_Status = p.Prescription_Status,
                                       DateCreated = p.DateCreated,
                                       DateModified = p.DateModified,
                                   };


            if (Listprescritions == null)
            {
                return NotFound();
            }
            var data = new DisplayPrescription();

            var prescription = _mapper.Map(Listprescritions.Single(x => x.Id == id), data);
            ViewBag.Message = prescription.PrescriptionNumber;

            return View(prescription);
        }

        // POST: ApartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DisplayPrescription displayPrescription, int CustomerId)
        {
            // ViewBag.Case_Id = caseid;
            await using (await _asyncUnitOfWorkFactory.Create())
            {
                var customer = await _asyncCustomerRepository.FindById(CustomerId, x => x.Prescriptions);
                var prescription = customer.Prescriptions.Single(x => x.Id == displayPrescription.Id);


                customer.Prescriptions.Remove(prescription);

                _notyf.Error("Prescription  removed  Successfully");
            }
            return RedirectToAction(nameof(List), new { CustomerId });
        }
    }
}
