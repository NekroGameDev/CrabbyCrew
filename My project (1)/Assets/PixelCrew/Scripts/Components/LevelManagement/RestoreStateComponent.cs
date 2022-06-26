using PixelCrew.Model;
using UnityEditor;
using UnityEngine;

namespace Assets.PixelCrew.Scripts.Components.LevelManagement
{
    public class RestoreStateComponent : MonoBehaviour
    {
        [SerializeField] private string _id;
        private GameSession _session;
        public string Id => _id;


        private void Start()
        {
            _session = GameSession.Instance;
            var isDestroyed = _session.RestoreState(Id);
            if (isDestroyed)
                Destroy(gameObject);
        }

    }
}