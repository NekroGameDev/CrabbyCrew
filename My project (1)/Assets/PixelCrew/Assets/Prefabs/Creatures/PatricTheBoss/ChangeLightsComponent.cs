using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Assets.PixelCrew.Assets.Prefabs.Creatures.PatricTheBoss
{
    public class ChangeLightsComponent : MonoBehaviour
    {
        [SerializeField] private Light2D[] _lights;
        [ColorUsage( true, true)] [SerializeField]
        private Color _color;

        [ContextMenu( "Setup")]
        public void SetColor()
        {
            SetColor(_color);
        }
        public void SetColor(Color color)
        {
            foreach (var lights2D in _lights)
            {
                lights2D.color = color;
            }
        }
    }
}