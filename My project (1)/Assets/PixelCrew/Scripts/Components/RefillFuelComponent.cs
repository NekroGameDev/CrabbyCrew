using PixelCrew.Model;
using UnityEditor;
using UnityEngine;

namespace Assets.PixelCrew.Scripts.Components
{
    public class RefillFuelComponent : MonoBehaviour
    {
        public void Refill()
        {
            GameSession.Instance.Data.Fuel.Value = 100;
        }
    }
}