using System;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteAnimation : MonoBehaviour
    {
        [SerializeField] [Range(1, 30)] private int _frameRate = 10;
        [SerializeField] private UnityEvent<string> _onComplete;
        [SerializeField] private AnimationClip[] _clip;

        private SpriteRenderer _renderer; // Рендер для изменения спрайтов

        private float _secPerFrame; // Сколько времени на показ спрайта
        private int _currentFrame; // Текущий спрайт
        private float _nextFrameTime; // Время для след апдейта
        private bool _isPlaying = true;

        private int _currentClip;

         // Проигрывается или не проигрывается 

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>(); // Забираем все зависимости 
            _secPerFrame = 1f / _frameRate; // Рассчитываем сколько длится один кадр

            StartAnimation();

        }


        private void OnBecameVisible()
        {
            enabled = _isPlaying; 
        }

        private void OnBecameInvisible()
        {
            enabled = false;
        }

        public void SetClip(string clipName)
        {
            for (var i = 0; i < _clip.Length; i++)
            {
                if (_clip[i].Name == clipName)
                {
                    _currentClip = i;
                    StartAnimation();
                    return;
                }
            }

            enabled = _isPlaying = false;
        }

        private void StartAnimation()
        {
            _nextFrameTime = Time.time;
            enabled = _isPlaying = true;
            _currentFrame = 0;
        }
        private void OnEnable()
        { 
            _nextFrameTime = Time.time; // Задаём след апдейт
        }

        private void Update()
        {
            if ( _nextFrameTime > Time.time) return; // Проигрывается анимации и наступило ли время след кадра, если нет => выходим из функции 

            var clip = _clip[_currentClip];
            
            if (_currentFrame >= clip.Sprites.Length) // Лимит спрайтов 
            {
                if (clip.Loop)
                {
                    _currentFrame = 0; // Если цикл анимация сбрасываем спрайт на 0
                }
                else
                {
                    enabled = _isPlaying = clip.AllowNextClip;
                    clip.OnComplete?.Invoke();
                    _onComplete?.Invoke(clip.Name);
                   
                    if (clip.AllowNextClip)
                    {
                        _currentFrame = 0;
                        _currentClip = (int) Mathf.Repeat(_currentClip + 1, _clip.Length);
                    }
                }

                return;
            }
            _renderer.sprite = clip.Sprites[_currentFrame]; // Меняем спрайт
            _nextFrameTime += _secPerFrame; // обновляем время спрайта 
            _currentFrame++; // прибавление индекса на 1
        }
    }

    [Serializable]

    public class AnimationClip
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private bool _loop;
        [SerializeField] private bool _allowNextClip;
        [SerializeField] private UnityEvent _onComplete;

        public string Name => _name;

        public Sprite[] Sprites => _sprites;

        public bool Loop => _loop;

        public bool AllowNextClip => _allowNextClip;

        public UnityEvent OnComplete => _onComplete;

    }
}
