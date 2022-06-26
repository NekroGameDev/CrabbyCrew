using UnityEditor;
using UnityEngine;

namespace Assets.PixelCrew.Assets.Prefabs.Creatures.PatricTheBoss
{
    public class BossFloodStage : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            var spawner = animator.GetComponent<FloodController>();
            spawner.StartFlooding();
        }
    }
}