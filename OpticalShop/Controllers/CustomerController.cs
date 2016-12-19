using OpticalShop.Models;
using OpticalShop.Models.Customer;
using OpticalShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OpticalShop.Core.Domain;

namespace OpticalShop.Controllers
{
    public class CustomerController : BaseController
    {
        private ICustomerService _customerService;
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        public ActionResult LastNameCustomerList()
        {
            LastNameCustomerListModel model = new LastNameCustomerListModel();
            model.LastName = this._customerService.GetCustomers().Select(m => m.FamilyName).ToList();
            return View(model);
        }

        public ActionResult AddFamily( )
        {
            Family model = new Family();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddFamily(Family model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction( "FamilyMemberList",new { familyName = model.FamilyName, address = model.Address, tel = model.Tel } );
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult FamilyMemberListDetail(string familyName,string address, string tel )
        {
            FamilyMembers model = new FamilyMembers();
            model.Family = new Family();
            model.Family.FamilyName = familyName;
            model.Family.Address = address;
            model.Family.Tel = tel;
            model.Familymembers = new List<FamilyMember>();
            var customers = this._customerService.GetCustomers().Where(m => m.FamilyName.Equals(familyName)).ToList();
            if (customers != null)
            {
                model.Familymembers = TranformCustomersToModel(customers);
            }
            else
            {
               
            }
            return PartialView(model);
        }

        public ActionResult DeleteFamily(string familyName)
        {
            try
            {
                var cutomers = this._customerService.GetCustomers().Where(m => m.FamilyName.Equals(familyName)).ToList();
                foreach (var customer in cutomers)
                {
                    this._customerService.DeleteCustomer(customer.Id);
                }
                return Json(new
                {
                    IsSuccess = true,
                    Message = "Done for delete "
                });

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    IsSuccess = false,
                    Message = "Unsuccessfully delete "
                });
            }
        }


        public ActionResult FamilyMemberList(string familyName,string address = null,string tel = null)
        {
            FamilyMembers model = new FamilyMembers();
            model.Family = new Family();
            model.Family.FamilyName = familyName;
            model.Family.Address = address;
            model.Family.Tel = tel;

            var customers = this._customerService.GetCustomers().Where(m => m.FamilyName.Equals(familyName)).ToList();
            if (customers.Count() > 0 )
            {
                model.Family = new Family
                {
                    FamilyName = familyName,
                    Address = customers.FirstOrDefault().Address,
                    Tel = customers.FirstOrDefault().Tel
                };
                List<FamilyMember> familyMembers = TranformCustomersToModel(customers);
                model.Familymembers = familyMembers;
            }
            else
            {
                model.Familymembers = new List<FamilyMember>();
            }
            return View(model);
        }

       /*public ActionResult FamilyMemberList(Family family)
        {
            FamilyMembers model = new FamilyMembers();
            model.Family = family;
            var customers = this._customerService.GetCustomers().Where(m => m.FamilyName.Equals(family.FamilyName)).ToList();
            if(customers != null)
            {
                List<FamilyMember> familyMembers = TranformCustomersToModel(customers);
                model.Familymembers = familyMembers;
            }
            else
            {
                model.Familymembers = new List<FamilyMember>();
            }
            return View(model);
        }*/

        public ActionResult DeleteMember(string Id)
        {
            if(!String.IsNullOrEmpty(Id))
            {
                try
                {
                    this._customerService.DeleteCustomer(Id);
                    return Json(new
                    {
                        IsSuccess = true,
                        Message = "Done for delete "
                    });
                }
                catch(Exception ex)
                {
                    return Json(new
                    {
                        IsSuccess = true,
                        Message = ex.Message
                    });
                }
            }
            else
            {
                return Json(new
                {
                    IsSuccess = true,
                    Message = "No Id Member"
                });
            }
            
        }

        [HttpPost]
        public ActionResult AddMember(FamilyMember model)
        {
            if (!String.IsNullOrEmpty(model.FirstName))
            {
                try
                {
                    Customer customer = TranformModelToCustomer(model);
                    this._customerService.AddCustomer(customer);
                    SuccessNotification("Adding customer successfully");
                }
                catch(Exception ex)
                {
                    ErrorNotification(ex);
                }
            }
            return View(model);
        }

        public ActionResult AddMember(string FamilyName,string Address= null, string Tel=null, string FirstName = null)
        {
            FamilyMember model = new FamilyMember();
            if (!string.IsNullOrEmpty(Address))
            {
                model.FamilyName = FamilyName;
                model.Address = Address;
                model.Tel = Tel;
            }
            if(!String.IsNullOrEmpty(FirstName))
            {
                var customer = this._customerService.GetCustomers().FirstOrDefault(m => m.FirstName.Equals(FirstName) && m.FamilyName.Equals(FamilyName));
                model = TranformCustomerToModel(customer);
            }
            return View(model);
        }

        private Customer TranformModelToCustomer(FamilyMember model)
        {
            Customer customer = new Customer
            {
                FirstName = model.FirstName,
                Id = model.Id,
                Tel = model.Tel,
                FamilyName = model.FamilyName,
                Address = model.Address,
                DateOfBirth = model.DateOfBirth,
                Mobile = model.Mobile,
                RightAdd = model.RightAdd,
                RightSph = model.RightSph,
                RightAxis = model.RightAxis,
                RightCyl = model.RightCyl,
                LeftAdd = model.LeftAdd,
                LeftAxis = model.LeftAxis,
                LeftCyl = model.LeftCyl,
                LeftSph = model.LeftSph,
                Allergy = model.Allergy,
                PD = model.PD,
                PH = model.PH,
                Prism = model.Prism
            };
            return customer;
        }

        private FamilyMember TranformCustomerToModel(Customer customer)
        {
            FamilyMember model = new FamilyMember
            {
                FirstName = customer.FirstName,
                Id = customer.Id,
                Tel = customer.Tel,
                FamilyName = customer.FamilyName,
                Address = customer.Address,
                DateOfBirth = customer.DateOfBirth,
                Mobile = customer.Mobile,
                RightAdd = customer.RightAdd,
                RightSph = customer.RightSph,
                RightAxis = customer.RightAxis,
                RightCyl = customer.RightCyl,
                LeftAdd = customer.LeftAdd,
                LeftAxis = customer.LeftAxis,
                LeftCyl = customer.LeftCyl,
                LeftSph = customer.LeftSph,
                Allergy = customer.Allergy,
                PD = customer.PD,
                PH = customer.PH,
                Prism = customer.Prism
            };
            return model;
        }

        private List<FamilyMember> TranformCustomersToModel(List<Customer> customers)
        {
            List<FamilyMember> members = customers.Select(c => new FamilyMember
            {
                Id = c.Id,
                FirstName = c.FirstName,
                DateOfBirth = c.DateOfBirth,
                Address = c.Address,
                FamilyName = c.FamilyName,
                Tel = c.Tel,
                Mobile = c.Mobile,
                RightAdd = c.RightAdd,
                RightSph = c.RightSph,
                RightAxis = c.RightAxis,
                RightCyl = c.RightCyl,
                LeftAdd = c.LeftAdd,
                LeftAxis = c.LeftAxis,
                LeftCyl = c.LeftCyl,
                LeftSph = c.LeftSph,
                Allergy = c.Allergy,
                PD = c.PD,
                PH = c.PH,
                Prism = c.Prism
            }).ToList();
            return members;
        }
    }
}