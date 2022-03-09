using UnityEngine;

namespace E12_ScreenResolutions
{
    public class Launcher : MonoBehaviour
    {
        private void Awake()
        {
            ResolutionInformer informer = new ResolutionInformer();

            Debug.Log(informer.ToString());
            Debug.Log(informer.NormalizedPixelDistance);
        }
    }
}
