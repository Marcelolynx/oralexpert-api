using Eleven.OralExpert.Domain.Entities;
using Eleven.OralExpert.Domain.Enums;

namespace Eleven.OralExpert.Domain.Factories
{
    public static class UserFactory
    {
        public static User CreateUser(string name, string email, string password, Guid clinicId, Role role, Address address)
        {
            return new User(name, email, password, clinicId, role, address);
        }

        public static Doctor CreateDoctor(string name, string email, string password, Guid clinicId, Address address, string cro, string specialty)
        {
            return new Doctor(name, email, password, clinicId, address, cro, specialty);
        }

        public static Employee CreateEmployee(string name, string email, string password, Guid clinicId, Address address, string position, decimal salary)
        {
            return new Employee(name, email, password, clinicId, address, position, salary);
        }

        public static Patient CreatePatient(string name, string email, string password, Guid clinicId, Address address, string medicalRecord)
        {
            return new Patient(name, email, password, clinicId, address, medicalRecord);
        }
    }

}
