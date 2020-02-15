using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnthelmeXGobelins
{
    public class InputSystem : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (Slider.CurrentSlideIndex >= Slider.SlideCount) return;
            
                Slider.SetCurrentSlideIndex(Slider.CurrentSlideIndex + 1);
            }
            
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (Slider.CurrentSlideIndex <= 0) return;
            
                Slider.SetCurrentSlideIndex(Slider.CurrentSlideIndex - 1);
            }
        }
    }
}


