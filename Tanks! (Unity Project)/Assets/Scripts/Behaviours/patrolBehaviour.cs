using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Actions
{

    [Action("Navigation/Patrol")]
    [Help("Gets a random position from a given area and moves the game object to that point by using a NavMeshAgent")]
    public class PatrolBehaviour : GOAction
    {
        private TankPatrol tankP;

        [InParam("tank")]
        public GameObject tank;

        public override void OnStart()
        {
            tankP = tank.GetComponent<TankPatrol>();
        }

        public override TaskStatus OnUpdate()
        {
            tankP.Patrol();
            return TaskStatus.RUNNING;
        }

    }
}
