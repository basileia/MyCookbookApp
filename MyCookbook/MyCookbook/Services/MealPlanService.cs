using AutoMapper;
using MyCookbook.Data.Contracts.Services;
using MyCookbook.Data.Models;

namespace MyCookbook.Services
{
    public class MealPlanService : IMealPlanService
    {
        private readonly IMapper _mapper;
    }

    /* Generování náhodného jídelníčku podle filtrů
        Vytvoření MealPlan + MealPlanDay + MealPlanRecipe
        Editace poznámek, nahrazení receptů
        Zajištění, že jídelníčky patří jen danému uživateli*/
}
