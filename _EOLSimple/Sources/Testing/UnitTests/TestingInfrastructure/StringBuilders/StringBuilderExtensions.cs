using System.Text;
using JetBrains.Annotations;

namespace Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.StringBuilders
{
    [PublicAPI]
    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendLineWithIndentation(this StringBuilder sb, string value, int indentationSize)
        {
            return sb.AppendLine(AppendIndentation(value, indentationSize));
        }

        private static string AppendIndentation(string value, int indentationSize)
        {
            var emptyStr = new string(' ', indentationSize);

            return emptyStr + value;
        }
    }
}