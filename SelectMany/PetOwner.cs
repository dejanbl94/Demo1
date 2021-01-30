using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelectMany
{
    public class PetOwner
    {
        public string Name { get; set; }
        public List<string> Pets { get; set; }

        public static void SelectManyEx()
        {
            PetOwner[] petOwners =
                {
                    new PetOwner{ Name = "Dejan", Pets = new List<string>{ "Scruffy", "Sam"} },
                    new PetOwner{ Name = "Andrej", Pets = new List<string>{ "Walker", "Sugar"} },
                    new PetOwner{ Name = "Ana", Pets = new List<string>{ "Scratches", "Diesel"} },
                    new PetOwner{ Name = "Dragan", Pets = new List<string>{ "Scar", "Sasha"} }
            };

            // Project the pet owner's name and the pet's name.
            var query = petOwners
                            .SelectMany(petowner => petowner.Pets, (petowner, petname) => new { petowner, petname })
                            .Where(ownerAndPet => ownerAndPet.petname.StartsWith("S"))
                            .Select(ownerAndPet =>
                                new
                                {
                                    Owner = ownerAndPet.petowner.Name,
                                    Pet = ownerAndPet.petname
                                });

            foreach (var obj in query)
            {
                Console.WriteLine(obj);
            }
        }
    }

}
