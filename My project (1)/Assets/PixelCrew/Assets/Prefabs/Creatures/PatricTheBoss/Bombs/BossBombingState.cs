using UnityEditor;
using UnityEngine;

namespace Assets.PixelCrew.Assets.Prefabs.Creatures.PatricTheBoss.Bombs
{
    public class BossBombingState : StateMachineBehaviour
    {
         public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            var spawner = animator.GetComponent<BombsController>();
            spawner.StartBombing();
        }
    }
}