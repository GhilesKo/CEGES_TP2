using CEGES_Core;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;

namespace CEGES_MVC.ModelBinder
{    
    public class EquipementModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType != typeof(Equipement))
            {
                return null;
            }

            var subclasses = new[] { typeof(EquipementConstant), typeof(EquipementLineaire), typeof(EquipementRelatif) };

            var binders = new Dictionary<Type, (ModelMetadata, IModelBinder)>();
            foreach (var type in subclasses)
            {
                var modelMetadata = context.MetadataProvider.GetMetadataForType(type);
                binders[type] = (modelMetadata, context.CreateBinder(modelMetadata));
            }

            return new EquipementModelBinder(binders);
        }
    }
}
