﻿using Microsoft.AspNetCore.Mvc;

namespace SaleOfProducts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenseItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}