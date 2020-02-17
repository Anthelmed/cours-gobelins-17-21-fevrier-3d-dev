using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
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

        private List<TweenerCore<Color, Color, ColorOptions>> _tweenerCores = new List<TweenerCore<Color, Color, ColorOptions>>();

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
            KillPreviousTweens();
            
            var delay = Slider.FadeDelay * targetAlpha;

            for (var i = 0; i < _images.Length; i++)
            {
                var image = _images[i];
                var tweenerCore = image.DOFade(targetAlpha, duration)
                    .SetDelay(delay)
                    .SetEase(Ease.InOutQuad);

                _tweenerCores.Add(tweenerCore);
            }

            for (var i = 0; i < _rawImages.Length; i++)
            {
                var image = _rawImages[i];
                var tweenerCore = image.DOFade(targetAlpha, duration)
                    .SetDelay(delay)
                    .SetEase(Ease.InOutQuad);

                _tweenerCores.Add(tweenerCore);
            }

            for (var i = 0; i < _textsUGUI.Length; i++)
            {
                var text = _textsUGUI[i];
                var tweenerCore = text.DOFade(targetAlpha, duration)
                    .SetDelay(delay)
                    .SetEase(Ease.InOutQuad);

                _tweenerCores.Add(tweenerCore);
            }

            for (var i = 0; i < _texts.Length; i++)
            {
                var text = _texts[i];
                var tweenerCore = text.DOFade(targetAlpha, duration)
                    .SetDelay(delay)
                    .SetEase(Ease.InOutQuad);

                _tweenerCores.Add(tweenerCore);
            }

            for (var i = 0; i < _meshRenderers.Length; i++)
            {
                var meshRenderer = _meshRenderers[i];
                var tweenerCore = meshRenderer.material.DOFade(targetAlpha, duration)
                    .SetDelay(delay)
                    .SetEase(Ease.InOutQuad);

                _tweenerCores.Add(tweenerCore);
            }
        }

        private void KillPreviousTweens()
        {
            for (var i = 0; i < _tweenerCores.Count; i++)
            {
                var tweenerCore = _tweenerCores[i];
                tweenerCore.Kill();
            }

            _tweenerCores.Clear();
        }
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            gameObject.name = $"Slide {index}";
        }
#endif
    }
}


