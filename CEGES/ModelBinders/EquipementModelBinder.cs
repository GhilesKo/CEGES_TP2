using CEGES_Core;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CEGES_MVC.ModelBinder
{
    public class EquipementModelBinder : IModelBinder
    {
        private Dictionary<Type, (ModelMetadata, IModelBinder)> binders;

        public EquipementModelBinder(Dictionary<Type, (ModelMetadata, IModelBinder)> binders)
        {
            this.binders = binders;
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var modelTypeName = ModelNames.CreatePropertyModelName(bindingContext.ModelName, nameof(Equipement.Type));
            var modelTypeValue = bindingContext.ValueProvider.GetValue(modelTypeName).FirstValue;

            IModelBinder modelBinder;
            ModelMetadata modelMetadata;
            if (modelTypeValue == "Constant")
            {
                (modelMetadata, modelBinder) = binders[typeof(EquipementConstant)];
            }
            else if (modelTypeValue == "Lineaire")
            {
                (modelMetadata, modelBinder) = binders[typeof(EquipementLineaire)];
            }
            else if (modelTypeValue == "Relatif")
            {
                (modelMetadata, modelBinder) = binders[typeof(EquipementRelatif)];
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return;
            }

            var newBindingContext = DefaultModelBindingContext.CreateBindingContext(
                bindingContext.ActionContext,
                bindingContext.ValueProvider,
                modelMetadata,
                bindingInfo: null,
                bindingContext.ModelName);

            await modelBinder.BindModelAsync(newBindingContext);
            bindingContext.Result = newBindingContext.Result;

            if (newBindingContext.Result.IsModelSet)
            {
                // Setting the ValidationState ensures properties on derived types are correctly 
                bindingContext.ValidationState[newBindingContext.Result.Model] = new ValidationStateEntry
                {
                    Metadata = modelMetadata,
                };
            }
        }
    }
}
