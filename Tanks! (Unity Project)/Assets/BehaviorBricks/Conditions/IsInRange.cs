using Pada1.BBCore.Framework;
using Pada1.BBCore;
using UnityEngine;

namespace BBCore.Conditions
{
    /// <summary>
    /// It is a basic condition to check if Booleans have the same value.
    /// </summary>
    [Condition("Custom/IsInRange")]
    public class IsInRange : ConditionBase
    {

        ///<value>Input First Boolean Parameter.</value>
        [InParam("tank")]
        public GameObject tank;

        public override bool Check()
        {
            return tank.GetComponent<Shooting>().enemy_detected;
        }
    }
}

