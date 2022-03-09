using UnityEngine;

namespace E12_ScreenResolutions
{
    public class ResolutionInformer
    {
        public float NormalizedPixelDistance { get; private set; }
        public int DisplayWidth => Display.main.systemWidth;
        public int DisplayHeight => Display.main.systemHeight;

        public ResolutionInformer()
        {
            NormalizedPixelDistance = CalculateNormalizedPixelDistance();
        }

        public override string ToString()
        {
            return $"NormalizedPixelDistance: {NormalizedPixelDistance}. " +
                $"Display size: {DisplayWidth}x{DisplayHeight}";
        }

        private float CalculateNormalizedPixelDistance()
        {
            float displayDimension = ReferenceDisplaySize();
            float ratio = 1 / displayDimension;
            float targetHeight = 1 / ratio;
            float fovInRad = FoV * 180 / Mathf.PI;
            return targetHeight / Mathf.Tan(fovInRad);
        }

        private float FoV => Camera.main.fieldOfView;

        private float ReferenceDisplaySize()
        {
            if (DisplayHeight > DisplayWidth)
                return DisplayWidth;
            else
                return DisplayHeight;
        }
    }
}
