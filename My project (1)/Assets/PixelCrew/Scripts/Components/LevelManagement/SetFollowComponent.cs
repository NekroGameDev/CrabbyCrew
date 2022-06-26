using Cinemachine;
using PixelCrew.Creatures;
using UnityEditor;
using UnityEngine;

namespace PixelCrew.PixelCrew.Scripts.Components.LevelManagement
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class SetFollowComponent : MonoBehaviour
    {
        private void Start()
        {
            var vCamera = GetComponent<CinemachineVirtualCamera>();
            vCamera.Follow = FindObjectOfType<Hero>().transform;
        }
    }
}