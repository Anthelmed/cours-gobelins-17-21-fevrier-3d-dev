using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AnthelmeXGobelins
{
    public class Slide : MonoBehaviour
    {
        [SerializeField] private int index = -1;

        private Image[] _images;
        private RawImage[] _rawImages;
        private TextMeshProUGUI[] _textsUGUI;
        private TextMeshPro[] _texts;
        private MeshRenderer[] _meshRenderers;

        private void Awake()
        {
            GetVisualComponents();
        }

        private void Start()
        {
            Slider.SlideCount++;
        
            if (index != 0)
                Fade(0f, 0f);
        }

        private void OnDestroy()
        {
            Slider.SlideCount--;
        }

        private void OnEnable()
        {
            Slider.SlideIndexChangeEvent += OnSlideIndexChanged;
        }
    
        private void OnDisable()
        {
            Slider.SlideIndexChangeEvent -= OnSlideIndexChanged;
        }

        private void OnSlideIndexChanged(int newSlideIndex, int previousSlideIndex)
        {
            if (newSlideIndex == index)
                Fade(1f, Slider.FadeDuration);
            else if (previousSlideIndex == index)
                Fade(0f, Slider.FadeDuration);
        }

        private void GetVisualComponents()
        {
            _images = GetComponentsInChildren<Image>();
            _rawImages = GetComponentsInChildren<RawImage>();
            _textsUGUI = GetComponentsInChildren<TextMeshProUGUI>();
            _texts = GetComponentsInChildren<TextMeshPro>();
            _meshRenderers = GetComponentsInChildren<MeshRenderer>();
        }

        private void Fade(float targetAlpha, float duration)
        {
            var delay = Slider.FadeDelay * targetAlpha;
        
            foreach (var image in _images)
            {
                image.DOFade(targetAlpha, duration)
                    .SetDelay(delay)
                    .SetEase(Ease.InOutQuad);
            }
            
            foreach (var image in _rawImages)
            {
                image.DOFade(targetAlpha, duration)
                    .SetDelay(delay)
                    .SetEase(Ease.InOutQuad);
            }
        
            foreach (var text in _textsUGUI)
            {
                text.DOFade(targetAlpha, duration)
                    .SetDelay(delay)
                    .SetEase(Ease.InOutQuad);
            }
            
            foreach (var text in _texts)
            {
                text.DOFade(targetAlpha, duration)
                    .SetDelay(delay)
                    .SetEase(Ease.InOutQuad);
            }

            foreach (var meshRenderer in _meshRenderers)
            {
                meshRenderer.material.DOFade(targetAlpha, duration)
                                    .SetDelay(delay)
                                    .SetEase(Ease.InOutQuad);
            }
        }
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            gameObject.name = $"Slide {index}";
        }
#endif
    }
}


