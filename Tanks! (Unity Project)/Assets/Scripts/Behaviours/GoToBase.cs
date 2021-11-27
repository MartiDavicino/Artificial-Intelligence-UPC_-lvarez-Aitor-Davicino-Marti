using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Actions
{

    [Action("Navigation/GoTOBase")]
    public class GoTOBase : GOAction
    {
        private TankReload tankW;

        [InParam("tank")]
        public GameObject tank;

        public override void OnStart()
        {
            tankW = tank.GetComponent<TankReload>();
        }

        public override TaskStatus OnUpdate()
        {
            tankW.GoTOBase();
            return TaskStatus.RUNNING;
        }

    }
}
