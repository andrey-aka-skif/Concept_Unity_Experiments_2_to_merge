using System;
using UnityEngine;

namespace E12_ScreenResolutions
{
    public class ResolutionInformer1 : MonoBehaviour
    {
        private Camera _camera;
        private Display _display;

        public float NormalizedPixelDistance { get; private set; }

        private void Awake()
        {
            _camera = Camera.main;
            _display = Display.main;


            float displayDimension = ReferenceDisplaySize();
            float ratio = 1 / displayDimension;
            float targetHeight = 1 / ratio;
            float fovInRad = FoV * 180 / Mathf.PI;
            NormalizedPixelDistance = targetHeight / Mathf.Tan(fovInRad);
        }

        [SerializeField] private Transform _target;


        private void Start()
        {
            if (_target == null)
                throw new Exception("Не указан Target");
        }

        private void Update()
        {
            Debug.Log(SizeInPixels(_target));
        }

        private int SizeInPixels(Transform target)
        {
            float distance = DistanceToCamera(target);
            float size = ReferenceSize(target);
            float angularDiameter = AngularDiameter(distance, size);
            float angleRatio = angularDiameter / FoV;
            float displayDimension = ReferenceDisplaySize();
            int sizeInPixel = (int)(displayDimension * angleRatio);
            return sizeInPixel;
        }

        private float DistanceToCamera(Transform target)
        {
            return (target.position - _camera.transform.position).magnitude;
        }

        private float ReferenceSize(Transform target)
        {
            Mesh mesh = target.GetComponent<MeshFilter>().mesh;
            Bounds bounds = mesh.bounds;
            Vector3 maxSize = bounds.max;
            float maxDimension = maxSize.x > maxSize.y ? maxSize.x : maxSize.y;
            return maxDimension * 2;
        }

        private float AngularDiameter(float distance, float size)
        {
            float angleInRad = Mathf.Atan(size / distance);
            float angleInGrad = angleInRad * 180 / Mathf.PI;
            return angleInGrad;
        }

        private float FoV => _camera.fieldOfView;

        private float ReferenceDisplaySize()
        {
            float displayHeight = _display.systemHeight;
            float displayWidth = _display.systemWidth;
            float maxSize = displayHeight > displayWidth ? displayWidth : displayHeight;
            return maxSize;
        }
    }
}
