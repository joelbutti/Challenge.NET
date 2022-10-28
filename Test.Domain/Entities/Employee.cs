using Test.Domain.Seed;

namespace Test.Domain.Entities
{
    public class Employee : Entity
    {
        public string IdNumber { get; private set; }
        public string FullName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Guid CompanyId { get; private set; }
        public Company Company { get; private set; }

        public Employee() { }

        private Employee(
            Guid id,
            string idNumber,
            string fullName,
            DateTime dateOfBirth,
            Guid companyId,
            Company company,
            string? createdBy,
            string? updatedBy,
            DateTime createdAt,
            DateTime updatedAt) : base(id, createdBy, updatedBy, createdAt, updatedAt)
        {
            IdNumber = idNumber;
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            CompanyId = companyId;
            Company = company;
        }

        public static Employee New(
            string idNumber,
            string fullName,
            DateTime dateOfBirth,
            Guid companyId
        )
        {
            var person = new Employee(
                Guid.Empty,
                idNumber,
                fullName,
                dateOfBirth,
                companyId,
                null,
                null,
                null,
                DateTime.UtcNow,
                DateTime.UtcNow
            );

            return person;
        }
    }
}
