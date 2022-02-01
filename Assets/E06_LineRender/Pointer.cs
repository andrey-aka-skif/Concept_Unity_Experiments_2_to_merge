using E06_Timed;
using UnityEngine;

namespace E06_Plotter
{
    public class Pointer : MonoBehaviour
    {
        [SerializeField] PlotterNoTransform _plotter;

        private float _startTime;
        private bool _isShowed = false;
        private Timer _timer;

        private void Start()
        {
            _startTime = Time.time;
            _timer = new Timer(_plotter.UpdateTime);

            Debug.Log(_plotter.Width / _plotter.Speed);
        }

        private void Update()
        {
            //if (_timer.Dropped)
            //{
            //    transform.Translate(_plotter.Step * Vector3.left);
            //}

            transform.Translate(_plotter.Speed * Time.deltaTime * Vector3.left);

            if (transform.localPosition.x < 0 && _isShowed == false)
            {
                Debug.Log(Time.time - _startTime);
                _isShowed = true;
            }
        }
    }
}