using Eleven.OralExpert.Domain.Entities;
using Eleven.OralExpert.Domain.Enums;

namespace Eleven.OralExpert.Domain.Factories
{
    public static class UserFactory
    {
        // Método central para criar o usuário com os dados básicos
        public static User CreateUser(string name, string email, string hashedPassword, Guid clinicId, Role role, Doctor? doctor = null, Employee? employee = null)
        {
            var user = new User(name, email, hashedPassword, clinicId, role, doctor, employee);
            
            // Agora retorna o usuário criado
            return user;
        }

        // Método para adicionar a lógica de criação de um usuário com role "Doctor"
        public static User CreateDoctor(User user, string cro, string specialty)
        {
            // Verifica se os dados necessários para o médico estão presentes
            if (string.IsNullOrWhiteSpace(cro) || string.IsNullOrWhiteSpace(specialty))
                throw new ArgumentException("Doutor precisa de CRO e Especialidade.");

            // Cria o Doctor
            var doctor = new Doctor
            {
                Id = Guid.NewGuid(),
                CRO = cro,
                Especialidade = specialty
            };
 
            return user;
        }

        // Método para adicionar a lógica de criação de um usuário com role "Employee"
        public static User CreateEmployee(User user, string position)
        {
            // Verifica se o cargo do funcionário foi informado
            if (string.IsNullOrWhiteSpace(position))
                throw new ArgumentException("Funcionário precisa de um Cargo.");

            // Cria o Employee
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                Position = position
            };
 
            
            return user;
        }
    }
}
