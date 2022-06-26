using Assets.PixelCrew.Assets.Prefabs.Creatures.PatricTheBoss;
using Assets.PixelCrew.Scripts.Components;
using UnityEngine;

public class BossNextStage : StateMachineBehaviour
{
    [ColorUsage(true, true)] [SerializeField]
    private Color _stageColor;
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var spawner = animator.GetComponent<CircularProjectileSpawner>();
        spawner.Stage++;

        var changeLight = animator.GetComponent<ChangeLightsComponent>();
        changeLight.SetColor(_stageColor);
    }


}
