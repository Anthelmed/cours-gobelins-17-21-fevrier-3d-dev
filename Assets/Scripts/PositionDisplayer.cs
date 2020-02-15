using System;
using TMPro;
using UnityEngine;

namespace AnthelmeXGobelins
{
    [ExecuteInEditMode]
    public class PositionDisplayer : MonoBehaviour
    {
        [SerializeField] private Space space = Space.World;
    
        private TextMeshPro textMeshPro;

        private void Awake()
        {
            textMeshPro = GetComponent<TextMeshPro>();
        }
    
        private void Update()
        {
            if (textMeshPro == null) return;

            var position = (space == Space.World) ? transform.position : transform.localPosition;
        
            textMeshPro.text = $"(<color=\"red\">{Math.Round(position.x, 2)}<color=\"white\">, " +
                               $"<color=\"green\">{Math.Round(position.y, 2)}<color=\"white\">, " +
                               $"<color=\"blue\">{Math.Round(position.z, 2)}<color=\"white\">)";
        }
    }
}


