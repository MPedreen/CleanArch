
using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }
        public ICollection<Product> Products { get; private set; }

        public Category(string name)
        {
            ValiteDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Valor do Id inválido.");
            Id = id;
            ValiteDomain(name);
        }

        private void ValiteDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido. O nome é obrigatório.");

            DomainExceptionValidation.When(name.Length < 3, "Nome muito pequeno. Mínimo 3 caracteres.");

            Name = name;
        }
    }
}
