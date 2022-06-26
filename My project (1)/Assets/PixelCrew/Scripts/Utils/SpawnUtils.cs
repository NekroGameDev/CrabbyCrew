using System;
using UnityEngine;
namespace PixelCrew.Scripts.Utils
{
    public class SpawnUtils
    {
        private const string ContainerName = "###SPAWNED###";

        public static GameObject Spawn(GameObject prefab, Vector3 position, string containerName = ContainerName)
        {
            var container = GameObject.Find(containerName);
            if (container == null)
                container = new GameObject(containerName);

           return UnityEngine.Object.Instantiate(prefab, position, Quaternion.identity, container.transform);
        }
    }
}
