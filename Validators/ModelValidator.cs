namespace REPR_API.Validators
{
    public static class ModelValidator
    {
        /// <summary>
        /// Method to validate the Model 
        /// </summary>
        /// <param name="validatorTypeName"></param>
        /// <param name="entityInstance"></param>
        /// <returns></returns>
        public static FluentValidation.Results.ValidationResult IsValid(string validatorTypeName, object entityInstance)
        { 
            
            // Vaidator Type Instance
            var validatorType = Type.GetType(validatorTypeName);
            var validatorInstance = Activator.CreateInstance(validatorType);

            // Get methods from the type

            Type validType = validatorInstance.GetType();
            // Read only Validate Methods
            var validateMethods = validType.GetMethods().Where(m => m.Name.StartsWith("Validate")).ToArray();

            string name = validateMethods[0].Name;

            ////Valiate the Entity, Get the method that accepts the ENtity Object as Input Parameter
            var validateMethod = validatorInstance.GetType().GetMethod(validateMethods[0].Name, new Type[] { entityInstance.GetType() });

            var validationResult = (FluentValidation.Results.ValidationResult)validateMethod.Invoke(validatorInstance, new[] { entityInstance });

             
            return validationResult;
        }

    }
}
