using Eleven.OralExpert.Domain.Entities;
using Eleven.OralExpert.Domain.Enums;

namespace Eleven.OralExpert.Domain.Factories;

public static class UserFactory
{
    public static User CreateUser(UserRegisterDto request, string hashedPassword, Guid clinicId)
    {
        var user = new User(request.Name, request.Email, hashedPassword, clinicId, request.Role);

        return request.Role switch
        {
            Role.Doctor => CreateDoctor(user, request),
            Role.Employee => CreateEmployee(user, request),
            _ => user // Admin ou outro tipo de usuário
        };
    }

    private static User CreateDoctor(User user, UserRegisterDto request)
    {
        if (string.IsNullOrWhiteSpace(request.CRO) || string.IsNullOrWhiteSpace(request.Specialty))
            throw new ArgumentException("Doutor precisa de CRO e Especialidade.");

        var doctor = new Doctor
        {
            Id = Guid.NewGuid(),
            CRO = request.CRO,
            Especialidade = request.Specialty
        };

        user.SetDoctor(doctor);
        return user;
    }

    private static User CreateEmployee(User user, UserRegisterDto request)
    {
        if (string.IsNullOrWhiteSpace(request.Position))
            throw new ArgumentException("Funcionário precisa de um Cargo.");

        var employee = new Employee
        {
            Id = Guid.NewGuid(),
            Position = request.Position
        };

        user.SetEmployee(employee);
        return user;
    }
}