using PixelCrew.Scripts.UIscripts.HUD.Dialogs;
using UnityEditor;
using UnityEngine;

namespace Assets.PixelCrew.Scripts.UIscripts.HUD.Dialogs.Editor
{
    public class ShowOptionsComponent : MonoBehaviour
    {
        [SerializeField] private OptionDialogData _data;
        private OptionDialogController _dialogBox;

        public void Show()
        {
            if (_dialogBox == null)
                _dialogBox = FindObjectOfType<OptionDialogController>();

            _dialogBox.Show(_data);
        }
       
    }
}