using Microsoft.AspNetCore.Mvc;

namespace REST_API_Calculator.Controllers
{
    /// <summary>
    /// Контроллер калькулятора.
    /// </summary>
    public class CalculatorController : ControllerBase
    {
        /// <summary>
        /// Метод сложения.
        /// </summary>
        /// <param name="a">Первое значение.</param>
        /// <param name="b">Второе значение.</param>
        /// <returns>Результат сложения.</returns>
        /// <response code="200">Сложение выполнено успешно.</response>
        [HttpGet("Addition")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Addition(double a, double b)
        {
            double result = a + b;
            return Ok(result);
        }

        /// <summary>
        /// Метод вычитания.
        /// </summary>
        /// <param name="a">Первое значение.</param>
        /// <param name="b">Второе значение.</param>
        /// <returns>Результат вычитания.</returns>
        /// <response code="200"> выполнено успешно.</response>
        /// <response code="200">Вычитание выполнено успешно.</response>
        [HttpGet("Subtraction")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Subtraction(double a, double b)
        {
            double result = a - b;
            return Ok(result);
        }

        /// <summary>
        /// Метод умножения.
        /// </summary>
        /// <param name="a">Первое значение.</param>
        /// <param name="b">Второе значение.</param>
        /// <returns>Результат умножения.</returns>
        /// <response code="200">Умножение выполнено успешно.</response>
        [HttpGet("Multiplication")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Multiplication(double a, double b)
        {
            double result = a * b;
            return Ok(result);
        }

        /// <summary>
        /// Метод деления.
        /// </summary>
        /// <param name="a">Первое значение.</param>
        /// <param name="b">Второе значение.</param>
        /// <returns>Результат деления.</returns>
        /// <response code="200">Деление выполнено успешно.</response>
        /// /// <response code="400">На ноль делить нельзя.</response>
        [HttpGet("Division")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Division(double a, double b)
        {
            if (a == 0)
            {
                return BadRequest("На ноль делить нельзя!");
            }

            double result = a / b;
            return Ok(result);
        }

        /// <summary>
        /// Метод вычисления факториала.
        /// </summary>
        /// <param name="number">Значение.</param>
        /// <returns>Результат вычисления факториала.</returns>
        /// <response code="200">Факториал вычеслен успешно.</response>
        /// <response code="400">Факториал для отрицательных чисел не может быть вычеслен.</response>
        /// <response code="500">Ошибка сервера при вычислении.</response>
        [HttpGet("Factorial")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CalculateFactorial(int number)
        {
            try
            {
                if (number < 0)
                {
                    return BadRequest("Факториал не определен для отрицательных чисел");
                }

                long result = 1;
                for (int i = 2; i <= number; i++)
                {
                    result *= i;
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка при вычислении факториала: {ex.Message}");
            }
        }
    }
}
