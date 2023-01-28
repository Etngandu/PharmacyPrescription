using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using ENB.PharmaciesAndPrescriptions.Entities;
using ENB.PharmaciesAndPrescriptions.Entities.Collections;
using ENB.PharmaciesAndPrescriptions.Entities.Repositories;
using ENB.PharmaciesAndPrescriptions.Infrastructure;
using ENB.PharmaciesAndPrescriptions.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Spaanjaars.ContactManager45.Web.Mvc.Controllers
{
    public class AddressesController : Controller
    {
        private readonly IAsyncCustomerRepository _asyncCustomerRepository;
        private readonly IAsyncDrugCompanyRepository _asyncDrugCompanyRepository;
        private readonly IAsyncPhysicianRepository _asyncPhysicianRepository;
        private readonly IAsyncUnitOfWorkFactory _asyncUnitOfWorkFactory;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyf;


        /// <summary>
        /// Initializes a new instance of the AddressesController class.
        /// </summary>
        public AddressesController(IAsyncCustomerRepository asyncCustomerRepository,
                                   IAsyncDrugCompanyRepository asyncDrugCompanyRepository,
                                   IAsyncPhysicianRepository asyncPhysicianRepository,
                                   IAsyncUnitOfWorkFactory asyncUnitOfWorkFactory,
                                   IMapper mapper,
                                   INotyfService notyf)
        {
            _asyncCustomerRepository = asyncCustomerRepository;
            _asyncDrugCompanyRepository = asyncDrugCompanyRepository;
            _asyncPhysicianRepository = asyncPhysicianRepository;
            _asyncUnitOfWorkFactory = asyncUnitOfWorkFactory;
            _mapper = mapper;
            _notyf = notyf;
        }

        public async Task<IActionResult> Edit(int CustomerId, int PhysicianId, int DrugCompanyId)
        {
            ViewBag.CustId = CustomerId;
            ViewBag.PhysId = PhysicianId;
            ViewBag.DrugId = DrugCompanyId;
            
            var address = new Address();
            var message = "";

            if (CustomerId != 0)
            {
                var customer = await _asyncCustomerRepository.FindById(CustomerId);
                if (customer == null)
                {
                    return NotFound();
                }
                address = customer.AddressCustomer;
                message = customer.FullName;
            }

            if (PhysicianId != 0)
            {
                var physician = await _asyncPhysicianRepository.FindById(PhysicianId);
                if (physician == null)
                {
                    return NotFound();
                }
                address = physician.AddressPhysician;
                message = physician.FullName;
            }

            if (DrugCompanyId != 0)
            {
                var drugcompany = await _asyncDrugCompanyRepository.FindById(DrugCompanyId);
                if (drugcompany == null)
                {
                    return NotFound();
                }

                address = drugcompany.DrugCompanyAddress;
                message = drugcompany.Company_name;
            }

            var data = new EditAddress();

            ViewBag.Message = message;

            _mapper.Map(address, data);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditAddress editAddressModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await using (await _asyncUnitOfWorkFactory.Create())
                    {
                        if (editAddressModel.CustomerId != 0)
                        {
                            var customer = await _asyncCustomerRepository.FindById(editAddressModel.CustomerId);
                            _mapper.Map(editAddressModel, customer.AddressCustomer);

                            _notyf.Success("Address created  Successfully! ");

                            return RedirectToAction(nameof(Index), "Customer");
                        }

                        if (editAddressModel.PhysicianId != 0)
                        {
                            var physician = await _asyncPhysicianRepository.FindById(editAddressModel.PhysicianId);
                            _mapper.Map(editAddressModel, physician.AddressPhysician);

                            _notyf.Success("Address created  Successfully! ");

                            return RedirectToAction(nameof(Index), "Physician");
                        }

                        if (editAddressModel.DrugCompanyId != 0)
                        {
                            var drugcompany = await _asyncDrugCompanyRepository.FindById(editAddressModel.DrugCompanyId);
                            _mapper.Map(editAddressModel, drugcompany.DrugCompanyAddress);

                            _notyf.Success("Address created  Successfully! "); 

                            return RedirectToAction(nameof(Index), "DrugCompany");
                        }


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
    }
}
