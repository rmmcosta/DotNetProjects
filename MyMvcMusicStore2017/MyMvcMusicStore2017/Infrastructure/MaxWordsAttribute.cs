using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyMvcMusicStore2017.Infrastructure
{
    public class MaxWordsAttribute : ValidationAttribute, IClientValidatable
    {
        private int MaxWords { get; set; }
        public MaxWordsAttribute(int maxWords) : base("You can't have more than {0} words")
        {
            MaxWords = maxWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;
            string stringValue = value.ToString();
            int numWords = stringValue.Split(' ').Length;
            if (numWords > MaxWords)
                return new ValidationResult(FormatErrorMessage(MaxWords.ToString()));
            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(MaxWords.ToString());
            rule.ValidationParameters.Add("maxwords", MaxWords);
            rule.ValidationType = "maxwords";
            yield return rule;
        }
    }
}