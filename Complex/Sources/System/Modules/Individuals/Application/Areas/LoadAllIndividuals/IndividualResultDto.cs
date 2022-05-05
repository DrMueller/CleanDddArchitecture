using System;
using JetBrains.Annotations;

namespace Mmu.CleanDdd.Individuals.Application.Areas.LoadAllIndividuals
{
    [PublicAPI]
    public class IndividualResultDto
    {
        public const string GenderFemale = "Female";
        public const string GenderMale = "Male";

        public DateTime BirthDate { get; set; }

        public string FirstName { get; set; }

        public string GenderDescription { get; set; }

        public long IndividualId { get; set; }

        public string LastName { get; set; }
    }
}