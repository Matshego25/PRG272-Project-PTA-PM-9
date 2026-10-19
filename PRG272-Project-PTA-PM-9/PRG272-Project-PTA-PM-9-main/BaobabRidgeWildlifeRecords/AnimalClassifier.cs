using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaobabRidgeWildlifeRecords
{
    public static class AnimalClassifier
    {
        //This will determine the status and housing Unit based on the provided recovery score!

        public static (string Status, string HousingUnit) GetClassification( int recoveryScore)
        {
            if (recoveryScore >= 0 && recoveryScore <= 19)
            {
                return ("Critical", "Intensive Care Unit");
            }
            else if (recoveryScore >= 20 && recoveryScore <=39)
            {
                return ("Serious", "High-Dependency Ward");
            }
            else if (recoveryScore >= 40 && recoveryScore <= 59)
            {
                return ("Stable", "Recovery Ward");
            }
            else if (recoveryScore >= 60 && recoveryScore <= 79)
            {
                return ("Recovering", "Outdoor Enclosure");
            }
            else if (recoveryScore >= 80 && recoveryScore <= 100)
            {
                return ("Release-Ready", "Pre-Release Camp");
            }
            else { throw new System.ArgumentOutOfRangeException(nameof(recoveryScore), "Recovery score must be between 0 and 100."); }
        }

    }
}