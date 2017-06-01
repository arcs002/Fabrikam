namespace FabrikamFiber.Web.Controllers
{
    using System.Web.Mvc;

    using DAL.Data;
    using DAL.Models;
    using System.Configuration;

    public class CustomersController : Controller
    {
        private readonly ICustomerRepository customerRepository;

        /// <summary>
        /// Change 01
        /// </summary>
        /// <param name="customerRepository"></param>
        public CustomersController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        /// <summary>
        /// Change 02
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            ViewBag.Ambiente = ConfigurationManager.AppSettings["Ambiente"].ToString();

            return View(this.customerRepository.All);
        }

        /// <summary>
        /// Change 03
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ViewResult Details(int id)
        {
            return View(this.customerRepository.Find(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            //check model state
            if (ModelState.IsValid)
            {
                this.customerRepository.InsertOrUpdate(customer);
                this.customerRepository.Save();
                return RedirectToAction("Index");
            }
            
            return this.View();
        }

        /// <summary>
        /// outra altera��o
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            return View(this.customerRepository.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                this.customerRepository.InsertOrUpdate(customer);
                this.customerRepository.Save();
                return RedirectToAction("Index");
            }
            
            return this.View();
        }

        public ActionResult Delete(int id)
        {
            return View(this.customerRepository.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.customerRepository.Delete(id);
            this.customerRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

