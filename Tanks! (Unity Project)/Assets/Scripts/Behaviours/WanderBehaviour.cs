using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Actions
{

    [Action("Navigation/Wander")]
    [Help("Gets a random position from a given area and moves the game object to that point by using a NavMeshAgent")]
    public class WanderBehaviour : GOAction
    {
        private TankWander tankW;

        [InParam("tank")]
        [Help("Gets a random position from a given area and moves the game object to that point by using a NavMeshAgent")]
        public GameObject tank;

        public override void OnStart()
        {
            tankW = tank.GetComponent<TankWander>();           
        }
        
        public override TaskStatus OnUpdate()
        {
            tankW.Wander();
            return TaskStatus.RUNNING;
        }

    }
}
