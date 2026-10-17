using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaobabRidgeWildlifeRecords
{
    public class Animal
    {
        //These are the properties representing the 7 required fields
        public string AnimalID { get; set; } = "";
        public string Name { get; set; } = "";
        public string Species { get; set; } = "";
        public int Age { get; set; }

        // Backing field for RecoveryScore
        private int _recoveryScore;

        public int RecoveryScore
        {
            get => _recoveryScore;
            set
            {
                _recoveryScore = value;
                // INTEGRATION POINT: Automatically calculate Status and Housing Unit when score changes
                var classification = AnimalClassifier.GetClassification(_recoveryScore);
                Status = classification.Status;
                HousingUnit = classification.HousingUnit;
            }
        }
        public string Status { get; set; } = "";
        public string HousingUnit { get; set; } = "";

        public Animal() { }

        // Status and housing unit are not passed in, the RecoveryScore setter works them out
        public Animal(string animalID, string name, string species, int age, int recoveryScore)
        {
            AnimalID = animalID;
            Name = name;
            Species = species;
            Age = age;
            RecoveryScore = recoveryScore;
        }

        //Makes format ID|NAME|SPECIES|AGE|RECOVERYSCORE|STATUS|HOUSINGUNIT AS PER REQUIREMENTS (no spaces around the pipes)
        public string ToFileString()
        {
            return $"{AnimalID}|{Name}|{Species}|{Age}|{RecoveryScore}|{Status}|{HousingUnit}";
        }
    }
}