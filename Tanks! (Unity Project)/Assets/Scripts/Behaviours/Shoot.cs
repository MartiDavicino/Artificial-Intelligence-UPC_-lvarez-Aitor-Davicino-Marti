using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Actions
{

    [Action("Navigation/Shoot")]
    public class Shoot : GOAction
    {
        private Shooting shooting;

        [InParam("tank")]
        public GameObject tank;

        public override void OnStart()
        {
            shooting = tank.GetComponent<Shooting>();
        }

        public override TaskStatus OnUpdate()
        {
            shooting.AimAndShoot();
            return TaskStatus.RUNNING;
        }

    }
}
