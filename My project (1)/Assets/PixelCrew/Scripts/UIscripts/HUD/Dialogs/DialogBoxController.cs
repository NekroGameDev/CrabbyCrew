﻿using Assets.PixelCrew.Scripts.UIscripts.HUD.Dialogs;
using Assets.PixelCrew.Scripts.Utils;
using PixelCrew.Creatures;
using PixelCrew.PixelCrew.Scripts.Model.Definitions.Localization;
using PixelCrew.Scripts.Model.Data;
using PixelCrew.Scripts.Utils;
using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Scripts.UIscripts.HUD.Dialogs
{
    public class DialogBoxController : MonoBehaviour
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private Animator _animator;
        [SerializeField] private UnityEvent _onComplete;

        [Space]
        [SerializeField] private float _textSpeed = 0.09f;

        [Header("Sounds")] 
        [SerializeField] private AudioClip _typing;
        [SerializeField] private AudioClip _open;
        [SerializeField] private AudioClip _close;

        [Space]
        [SerializeField] protected DialogContent _content;


        private static readonly int IsOpen = Animator.StringToHash("IsOpen");

        private DialogData _data;
        private int _currentSentence;
        private AudioSource _sfxSource;
        private Coroutine _typingRoutine;

        protected Sentence CurrentSentence => _data.Sentences[_currentSentence];
        private void Start()
        {
            _sfxSource = AudioUtils.FindSfxSource();
        }

        public void ShowDialog(DialogData data, UnityEvent onComplete)
        {
            _onComplete = onComplete;
            _data = data;
            _currentSentence = 0;
            CurrentContent.Text.text = string.Empty;

            _container.SetActive(true);
            _sfxSource.PlayOneShot(_open);
            _animator.SetBool("IsOpen", true);
        }
        private IEnumerator TypeDialogText()
        {
            CurrentContent.Text.text = string.Empty;
            var sentence = CurrentSentence;
            CurrentContent.TrySetIcon(sentence.Icon);

            var localizedSentence = sentence.Value.Localize();

            foreach ( var letter in localizedSentence)
            {
                CurrentContent.Text.text += letter;
                _sfxSource.PlayOneShot(_typing);
                yield return new WaitForSeconds(_textSpeed);
            }
            _typingRoutine = null;
        }

        protected virtual DialogContent CurrentContent => _content;

        public void OnSkip()
        {
            if (_typingRoutine == null) return;

            StopTypeAnimation();
            var sentence = _data.Sentences[_currentSentence].Value;

            CurrentContent.Text.text = sentence.Localize();
        }
        public void OnContinue()
        {
            StopTypeAnimation();
            _currentSentence++;

            var isDialogCompleted = _currentSentence >= _data.Sentences.Length;
            if (isDialogCompleted)
            {
                HideDialogBox();
                _onComplete?.Invoke();
            }
            else
            {
                OnStartDialogAnimation();
            }
        }

        private void StopTypeAnimation()
        {
            if (_typingRoutine != null)
                StopCoroutine(_typingRoutine);
            _typingRoutine = null;
        }

        

        private void HideDialogBox()
        {
            _animator.SetBool(IsOpen, false);
            _sfxSource.PlayOneShot(_close);
        }

        protected virtual void OnStartDialogAnimation()
        {
            _typingRoutine = StartCoroutine(TypeDialogText());
        }

       

        private void OnCloseDialogAnimation()
        {

        }

        
    }
}