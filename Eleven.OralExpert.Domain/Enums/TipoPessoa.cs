using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Eleven.OralExpert.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TipoPessoa
{
    [EnumMember(Value = "Pessoa Física")]
    Fisica,

    [EnumMember(Value = "Pessoa Jurídica")]
    Juridica
}