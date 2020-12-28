using System.Collections.Generic;

namespace ALEmanMuseum.Services.Sliders
{
    public class SliderErrorTemplatesCollection
    {
        protected static readonly Dictionary<SliderErrors, string> MErrorTemplates
            = new Dictionary<SliderErrors, string>
            {
                { SliderErrors.SliderNotExist, "Slider does not exist" },
                { SliderErrors.SliderAlreadExist, "Slider already exist" },
                { SliderErrors.SliderAlreadyActive, "Slider already active" },
                { SliderErrors.SliderWithNoImages, "Slider has no images" },
                { SliderErrors.OnlyOneSliderExist, "Only one slider exist" },
                { SliderErrors.DatabaseError, "Operation failed" }
            };

        public static string GetTemplateForError(SliderErrors sliderError)
            => MErrorTemplates.GetValueOrDefault(sliderError);
    }
}
