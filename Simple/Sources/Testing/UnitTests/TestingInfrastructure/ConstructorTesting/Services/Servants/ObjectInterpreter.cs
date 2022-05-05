using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Services.Servants
{
    internal static class ObjectInterpreter
    {
        internal static string GetStringRepresentation(params object?[] parameters)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < parameters.Length; i++)
            {
                sb.Append(GetStringRepresentation(parameters[i]));

                if (i + 1 < parameters.Length)
                {
                    sb.Append(", ");
                }
            }

            return sb.ToString();
        }

        private static string GetStringRepresentation(object? parameter)
        {
            switch (parameter)
            {
                case null:
                    return "(NULL)";
                case IEnumerable<object> enumerable:
                {
                    var arr = enumerable.ToList();

                    if (!arr.Any())
                    {
                        return "(EMPTY)";
                    }

                    return string.Join(";", arr);
                }

                default:
                    return parameter.ToString() ?? "No object representation";
            }
        }
    }
}