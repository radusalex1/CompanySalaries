using CompanySalaries.Models;

namespace CompanySalaries.Validations
{
    static class WorkTaskValidations
    {
        static public  bool ValidateWorkTask(WorkTask WorkTask)
        {
            if(WorkTask == null)
            {
                return false;
            }

            if(WorkTask.TypeOfWorkTask.Name == "normal" && WorkTask.Price!=0)
            {
                return false;
            }

            if (WorkTask.TypeOfWorkTask.Name == "special" && WorkTask.Price == 0)
            {
                return false;
            }

            return true;
        }
    }
}
