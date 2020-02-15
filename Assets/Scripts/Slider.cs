using System;
using UnityEngine;

namespace AnthelmeXGobelins
{
    public static class Slider
    {
        private static float _fadeDuration = 0.3f;
        private static float _fadeDelay = 0.5f;
    
        public static float FadeDuration => _fadeDuration;
        public static float FadeDelay => _fadeDelay;
    
        private static int _previousSlideIndex = -1;
        private static int _currentSlideIndex = -1;

        public static int SlideCount { get; set; } = -1;

        public static int PreviousSlideIndex => _previousSlideIndex;
        public static int CurrentSlideIndex => _currentSlideIndex;
    
        public delegate void SlideIndexChangeEventHandler(int newSlideIndex, int previousSlideIndex);
        public static event SlideIndexChangeEventHandler SlideIndexChangeEvent;
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void Start()
        {
            SetCurrentSlideIndex(0);
        }
        
        public static void SetCurrentSlideIndex(int index)
        {
            if (_currentSlideIndex == index) return;

            _previousSlideIndex = _currentSlideIndex;
            _currentSlideIndex = index;
        
            SlideIndexChangeEvent?.Invoke(_currentSlideIndex, _previousSlideIndex);
        }
    }
}


