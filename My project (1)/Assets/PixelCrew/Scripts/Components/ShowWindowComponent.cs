using PixelCrew.Scripts.Utils;
using UnityEditor;
using UnityEngine;

namespace Assets.PixelCrew.Scripts.Components
{
    public class ShowWindowComponent : MonoBehaviour
    {
        [SerializeField] private string _path;

        public void Show()
        {
            WindowUtils.CreateWindow(_path);
        }
    }
}