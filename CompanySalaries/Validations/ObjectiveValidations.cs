using CompanySalaries.Models;

namespace CompanySalaries.Validations
{
    static class ObjectiveValidations
    {
        static public  bool ValidateObjective(Objective objective)
        {
            if(objective == null)
            {
                return false;
            }

            if(objective.TypeOfObjective.Name == "normal" && objective.Price!=0)
            {
                return false;
            }

            if (objective.TypeOfObjective.Name == "special" && objective.Price == 0)
            {
                return false;
            }

            return true;
        }
    }
}
