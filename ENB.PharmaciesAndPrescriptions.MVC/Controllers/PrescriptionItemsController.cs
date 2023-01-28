using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using ENB.PharmaciesAndPrescriptions.EF.Migrations;
using ENB.PharmaciesAndPrescriptions.Entities;
using ENB.PharmaciesAndPrescriptions.Entities.Collections;
using ENB.PharmaciesAndPrescriptions.Entities.Repositories;
using ENB.PharmaciesAndPrescriptions.Infrastructure;
using ENB.PharmaciesAndPrescriptions.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ENB.PharmaciesAndPrescriptions.MVC.Controllers
{
    public class PrescriptionItemsController : Controller
    {
        private readonly IAsyncCustomerRepository _asyncCustomerRepository;
        private readonly IAsyncDrugCompanyRepository _asyncDrugCompanyRepository ;
        private readonly IAsyncPhysicianRepository _asyncPhysicianRepository;
        private readonly IAsyncUnitOfWorkFactory _asyncUnitOfWorkFactory;
        private readonly ILogger<PrescriptionItemsController> _logger;
        private readonly INotyfService _notyfService;
        private readonly IMapper _imapper;
        public PrescriptionItemsController(IAsyncCustomerRepository asyncCustomerRepository, 
                                            IAsyncDrugCompanyRepository asyncDrugCompanyRepository,
                                            IAsyncPhysicianRepository asyncPhysicianRepository,
                                            IAsyncUnitOfWorkFactory asyncUnitOfWorkFactory,
                                            ILogger<PrescriptionItemsController> logger,
                                            INotyfService notyfService,
                                            IMapper imapper)
        {
            _asyncCustomerRepository = asyncCustomerRepository;
            _asyncDrugCompanyRepository = asyncDrugCompanyRepository;
            _asyncPhysicianRepository= asyncPhysicianRepository;
            _asyncUnitOfWorkFactory = asyncUnitOfWorkFactory;
            _logger = logger;
            _notyfService= notyfService;
            _imapper = imapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> List(int CustomerId,int PrescriptionId)
        {
            ViewBag.Idcustm = CustomerId;
            ViewBag.presId = PrescriptionId;

            var customer = await _asyncCustomerRepository.FindById(CustomerId, prs => prs.Prescriptions);
            var prescription = customer.Prescriptions.Single(x => x.Id == PrescriptionId);

            ViewBag.Message = customer.FullName;
            ViewBag.presNumber = prescription.PrescriptionNumber;

            return View();
        }


        public async Task<IActionResult> GetPrescriptionsItems(int customerId, int PrescriptionId)
        {
            

            var presItems = (from prsit in _asyncCustomerRepository.FindAll().Where(cs => cs.Id == customerId).SelectMany(presIt => presIt.Prescription_Items)
                                   .Where(x => x.PrescriptionId == PrescriptionId)
                            join prs in _asyncCustomerRepository.FindAll().Where(cst => cst.Id == customerId).SelectMany(pres => pres.Prescriptions)
                                on prsit.PrescriptionId equals prs.Id
                            join cst in _asyncCustomerRepository.FindAll() on prs.CustomerId equals cst.Id
                            join phy in _asyncPhysicianRepository.FindAll() on prs.PhysicianId equals phy.Id
                            join drgm in _asyncDrugCompanyRepository.FindAll().SelectMany(z => z.Drug_Medications)
                                  on prsit.Drug_medicationId equals drgm.Id

                            select new DisplayPrescriptionItem
                          {
                              Id = prsit.Id,
                              Prescription_quantity = prsit.prescription_quantity,
                              Instructions_to_customer=prsit.Instructions_to_customer,
                              NameCustomer = cst.FullName,
                              NamePhysician = phy.FullName,
                              NumberPrescription = prs.PrescriptionNumber,
                              DrugName = drgm.Drug_name,
                              DateCreated=prsit.DateCreated,
                              DateModified=prsit.DateModified,

                            }).ToList();




            var Mpdata = new List<DisplayPrescriptionItem>();

            var lst = await Task.FromResult(presItems);

            _imapper.Map(lst, Mpdata);

            return Json(new { data = Mpdata });


        }

        [HttpGet]
        public async Task<IActionResult> Create(int CustomerId, int PrescriptionId)
        {
            ViewBag.Idcustm = CustomerId;
            ViewBag.presId = PrescriptionId;    
            
            var data = new CreateAndEditPrescriptionItem()
            {
                
                ListDrugs =  _asyncDrugCompanyRepository.FindAll()
                          .SelectMany(x => x.Drug_Medications)
                      .Select(d => new SelectListItem
                      {
                          Text = d.Drug_name,
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
        public async Task<IActionResult> Create(CreateAndEditPrescriptionItem createAndEditPrescriptionItem, 
                                                    int CustomerId, 
                                                    int PrescriptionId)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {
                        var customer = await _asyncCustomerRepository.FindById(CustomerId, x => x.Prescriptions);

                        var prescr = customer.Prescriptions.Single(x => x.Id == PrescriptionId);

                        Prescription_item prescription_Item   = new ();

                        _imapper.Map(createAndEditPrescriptionItem, prescription_Item);
                       
                        prescr.Prescription_Items.Add(prescription_Item);

                          _notyfService.Success("PrescriptionItem Added  Successfully! ");

                        return RedirectToAction(nameof(List), new { CustomerId, PrescriptionId });
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



        public async Task<IActionResult> Edit(int CustomerId,
                                                    int PrescriptionId, int id)
        {

            var customer = await _asyncCustomerRepository.FindById(CustomerId, x => x.Prescription_Items);
            var prescr = customer.Prescription_Items.Where(x => x.PrescriptionId == PrescriptionId)
                       .Single(y => y.Id == id);
            ViewBag.Message = customer.FullName;
            ViewBag.Idcustm = CustomerId;
            ViewBag.presId = PrescriptionId;
            ViewBag.Id = id;
            


            if (customer == null)
            {
                return NotFound();
            }



            var data = new CreateAndEditPrescriptionItem()
            {

                ListDrugs = _asyncDrugCompanyRepository.FindAll()
                         .SelectMany(x => x.Drug_Medications)
                     .Select(d => new SelectListItem
                     {
                         Text = d.Drug_name,
                         Value = d.Id.ToString(),
                         Selected = true

                     }).Distinct().ToList()

            };

            _imapper.Map(prescr, data);

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateAndEditPrescriptionItem createAndEditPrescriptionItem, int CustomerId,
                                                    int PrescriptionId)
        {

            ViewBag.Idcustm = CustomerId;
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {

                        var customer = await _asyncCustomerRepository.FindById(CustomerId, x => x.Prescription_Items);
                        var presItem = customer.Prescription_Items.Where(x => x.PrescriptionId == PrescriptionId)
                                   .Single(y => y.Id == createAndEditPrescriptionItem.Id);

                        _imapper.Map(createAndEditPrescriptionItem, presItem);

                         _notyfService.Success("PrescriptionItem updated Successfully");

                        return RedirectToAction(nameof(List), new { CustomerId, PrescriptionId });
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

        public async Task<IActionResult> Details(int CustomerId,
                                                    int PrescriptionId, int id)
        {           
           
            ViewBag.Idcustm = CustomerId;
            ViewBag.presId = PrescriptionId;
            ViewBag.Id = id;


            var prsItm=  from prsit in _asyncCustomerRepository.FindAll().Where(cs => cs.Id == CustomerId).SelectMany(presIt => presIt.Prescription_Items)
                                   .Where(x => x.PrescriptionId == PrescriptionId)
             join prs in _asyncCustomerRepository.FindAll().Where(cst => cst.Id == CustomerId).SelectMany(pres => pres.Prescriptions)
                 on prsit.PrescriptionId equals prs.Id
             join cst in _asyncCustomerRepository.FindAll() on prs.CustomerId equals cst.Id
             join phy in _asyncPhysicianRepository.FindAll() on prs.PhysicianId equals phy.Id
             join drgm in _asyncDrugCompanyRepository.FindAll().SelectMany(z => z.Drug_Medications)
                   on prsit.Drug_medicationId equals drgm.Id

             select new DisplayPrescriptionItem
             {
                 Id = prsit.Id,
                 Prescription_quantity = prsit.prescription_quantity,
                 Instructions_to_customer = prsit.Instructions_to_customer,
                 NameCustomer = cst.FullName,
                 NamePhysician = phy.FullName,
                 NumberPrescription = prs.PrescriptionNumber,
                 DrugName = drgm.Drug_name,
                 DateCreated= prsit.DateCreated,
                 DateModified= prsit.DateModified,

             };


            if (prsItm == null)
            {
                return NotFound();
            }
            var mypresIt = new DisplayPrescriptionItem();

            var sglprsItm = await Task.FromResult(_imapper.Map(prsItm.Single(x=>x.Id==id), mypresIt));
            ViewBag.Message = sglprsItm.DrugName;
            // sglevent.Color = Enum.GetName(typeof(EventStatus), Int32.Parse(sglevent.Color));
            return View(sglprsItm);
        }


        // GET: ApartmentController/Delete/5
        public async Task<IActionResult> Delete(int CustomerId,
                                                    int PrescriptionId, int id)
        {
            ViewBag.Idcustm = CustomerId;
            ViewBag.presId = PrescriptionId;
            ViewBag.Id = id;


            var prsItm = from prsit in _asyncCustomerRepository.FindAll().Where(cs => cs.Id == CustomerId).SelectMany(presIt => presIt.Prescription_Items)
                                   .Where(x => x.PrescriptionId == PrescriptionId)
                         join prs in _asyncCustomerRepository.FindAll().Where(cst => cst.Id == CustomerId).SelectMany(pres => pres.Prescriptions)
                             on prsit.PrescriptionId equals prs.Id
                         join cst in _asyncCustomerRepository.FindAll() on prs.CustomerId equals cst.Id
                         join phy in _asyncPhysicianRepository.FindAll() on prs.PhysicianId equals phy.Id
                         join drgm in _asyncDrugCompanyRepository.FindAll().SelectMany(z => z.Drug_Medications)
                               on prsit.Drug_medicationId equals drgm.Id

                         select new DisplayPrescriptionItem
                         {
                             Id = prsit.Id,
                             Prescription_quantity = prsit.prescription_quantity,
                             Instructions_to_customer = prsit.Instructions_to_customer,
                             NameCustomer = cst.FullName,
                             NamePhysician = phy.FullName,
                             NumberPrescription = prs.PrescriptionNumber,
                             DrugName = drgm.Drug_name,
                             DateCreated = prsit.DateCreated,
                             DateModified = prsit.DateModified,

                         };


            if (prsItm == null)
            {
                return NotFound();
            }
            var mypresIt = new DisplayPrescriptionItem();

            var sglprsItm = await Task.FromResult(_imapper.Map(prsItm.Single(x => x.Id == id), mypresIt));
            ViewBag.Message = sglprsItm.DrugName;
            // sglevent.Color = Enum.GetName(typeof(EventStatus), Int32.Parse(sglevent.Color));
            return View(sglprsItm);
        }

        // POST: ApartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DisplayPrescriptionItem displayPrescriptionItem,
               int CustomerId, int PrescriptionId)
        {

            await using (await _asyncUnitOfWorkFactory.Create())
            {
                var customer = await _asyncCustomerRepository.FindById(CustomerId, x => x.Prescription_Items);
                var presItem = customer.Prescription_Items.Where(x => x.PrescriptionId == PrescriptionId)
                    .Single(y => y.Id == displayPrescriptionItem.Id);
               
                customer.Prescription_Items.Remove(presItem);

                 _notyfService.Error("Prescription_Items removed  Successfully");
            }
            return RedirectToAction(nameof(List), new { CustomerId, PrescriptionId });
        }
    }
}
