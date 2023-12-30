
using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Entities
{
    public sealed class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public ICollection<Product> Products { get; private set; }

        public Category(string name)
        {
            ValiteDomain(name);
        }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }

        private void ValiteDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido. O nome é obrigatório.");

            DomainExceptionValidation.When(name.Length < 3, "Nome muito pequeno. Mínimo 3 caracteres.");

            Name = name;
        }
    }
}
