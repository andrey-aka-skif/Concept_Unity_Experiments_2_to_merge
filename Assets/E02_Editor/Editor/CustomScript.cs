using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace e02_Editor
{
    public class CustomScript : Editor
    {
        //public static float n = 0;

        [MenuItem("Tools/E02_Editor/Set position")]
        public static void SetXPosition()
        {
            var deeperSelection =
                Selection.transforms
                .SelectMany(go => go.GetComponentsInChildren<Transform>(true))
                .Select(t => t.transform);

            float n = 0;

            foreach (var l in deeperSelection)
            {
                l.position += new Vector3(n, 0, 0);
                n += 1;
            }
        }
    }
}