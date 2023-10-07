using lab2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lab2.Controllers
{
    

    /// <summary>
    /// Контроллер для модели человек.
    /// </summary>
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    { 
        /// <summary>
        /// Добавление человека в список.
        /// </summary>
        /// <param name="person">Данные человека.</param>
        /// <returns>Результат обработки запроса.</returns>
        /// <response code="201">Запрос успешно выполнен, произошло создание обьекта.</response>
        /// <response code="400">Некорректный запрос.</response>
        /// <response code="409">Запрос не может быть выполнен из за конфликта.</response>
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult AddPerson([FromBody] PeopleModel person)
        {
            if (person == null)
            {
                return BadRequest("Неверные данные.");
            }

            // Проверить, существует ли человек с таким же именем и фамилией.
            var existingPerson = PeopleRepository.PeopleList.FirstOrDefault(p => p.FirstName == person.FirstName && p.SecondName == person.SecondName);
            if (existingPerson != null)
            {
                return Conflict("Человек с таким же именем и фамилией уже существует.");
            }

            // Добавить человека в список.
            PeopleRepository.PeopleList.Add(person);

            // Вернуть успешный статус и объект, который был добавлен.
            return CreatedAtAction(nameof(GetPerson), new { firstName = person.FirstName, secondName = person.SecondName }, person);
        }

        /// <summary>
        /// Обновить информацию о человеке по имени и фамилии.
        /// </summary>
        /// <param name="firstName">Имя.</param>
        /// <param name="secondName">Фамилия.</param>
        /// <param name="updatedPerson">Обновленные данные о человеке.</param>
        /// <returns>Результат обработки запроса.</returns>
        /// <response code="200">Успешный запрос.</response>
        /// <response code="400">Некорректный запрос.</response>
        /// <response code="404">Человек не найден.</response>
        [HttpPut("{firstName}/{secondName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdatePersonByName(string firstName, string secondName, [FromBody] PeopleModel updatedPerson)
        {
            if (updatedPerson == null)
            {
                return BadRequest("Неверные данные.");
            }

            // Найти человека по имени и фамилии и обновить его данные.
            var existingPerson = PeopleRepository.PeopleList.FirstOrDefault(p => p.FirstName == firstName && p.SecondName == secondName);
            if (existingPerson == null)
            {
                return NotFound("Человек не найден.");
            }

            // Обновить данные человека.
            existingPerson.FirstName = updatedPerson.FirstName;
            existingPerson.SecondName = updatedPerson.SecondName;
            existingPerson.Age = updatedPerson.Age;
            existingPerson.Specialization = updatedPerson.Specialization;

            // Вернуть успешный статус и обновленный объект.
            return Ok(existingPerson);
        }

        /// <summary>
        /// Найти человека по имени и фамилии.
        /// </summary>
        /// <param name="firstName">Имя.</param>
        /// <param name="secondName">Фамилия.</param>
        /// <returns>Результат обработки запроса.</returns>
        /// <response code="200">Успешный запрос.</response>
        /// <response code="404">Невозможно выполнить запрос.</response>
        [HttpGet("{firstName}/{secondName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetPerson(string firstName, string secondName)
        {
            var person = PeopleRepository.PeopleList.FirstOrDefault(p => p.FirstName == firstName && p.SecondName == secondName);
            if (person == null)
            {
                return NotFound("Человек не найден.");
            }

            return Ok(person);
        }

        /// <summary>
        /// Удалить человека, зная имя и фамилию.
        /// </summary>
        /// <param name="firstName">Имя.</param>
        /// <param name="secondName">Фамилия.</param>
        /// <returns>Результат обработки запроса.</returns>
        /// <response code="204">Обьект успешно удален.</response>
        /// <response code="404">Невозможно выполнить запрос.</response>
        [HttpDelete("{firstName}/{secondName}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletePerson(string firstName, string secondName)
        {
            var person = PeopleRepository.PeopleList.FirstOrDefault(p => p.FirstName == firstName && p.SecondName == secondName);
            if (person == null)
            {
                return NotFound("Человек не найден.");
            }

            // Удалить человека из списка.
            PeopleRepository.PeopleList.Remove(person);

            // Вернуть успешный статус.
            return NoContent();
        }
    }
}
