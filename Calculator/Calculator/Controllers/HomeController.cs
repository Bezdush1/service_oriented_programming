using Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Calculator.Models.Calculator calculator)
        {
            double a, b;
            a = calculator.Value1;
            b = calculator.Value2;

            if (calculator.Calculate == "Сложение")
            {
                calculator.Result = a+b;
            }
            

            if (calculator.Calculate == "Вычитание")
            {
                calculator.Result = a-b;
            }

            if (calculator.Calculate == "Умножение")
            {
                calculator.Result = a * b;
            }

            if(calculator.Calculate == "Деление")
            {
                if (b!=0.0)
                {
                    calculator.Result = a/b;
                }
                else
                {
                    calculator.Result = 0;
                }
            }

            if (calculator.Calculate == "Факториал первого значения")
            {
                calculator.Result = CalculateFactorial(Convert.ToInt32(a));
            }

            ViewData["result"]=calculator.Result;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public static int CalculateFactorial(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

    }
}