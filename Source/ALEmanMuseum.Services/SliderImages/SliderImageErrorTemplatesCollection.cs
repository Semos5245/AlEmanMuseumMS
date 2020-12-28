using System.Collections.Generic;

namespace ALEmanMuseum.Services.SliderImages
{
    public abstract class SliderImageErrorTemplatesCollection
    {
        protected static readonly Dictionary<SliderImageErrors, string> MErrorTemplates
            = new Dictionary<SliderImageErrors, string>
            {
                { SliderImageErrors.Database, "Operation failed" },
            };

        public static string GetTemplateForError(SliderImageErrors sliderImageError)
            => MErrorTemplates.GetValueOrDefault(sliderImageError);
    }
}
