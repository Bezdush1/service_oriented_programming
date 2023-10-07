namespace lab2.Models
{
    /// <summary>
    /// Класс, представляющий модель человека.
    /// </summary>
    public class PeopleModel
    {
        /// <summary>
        /// Уникальный идентификатор человека.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string SecondName { get; set; } = string.Empty;

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Специализация.
        /// </summary>
        public string Specialization { get; set; } = string.Empty;
    }

    public static class PeopleRepository
    {
        public static List<PeopleModel> PeopleList { get; } = new List<PeopleModel>();
    }
}
