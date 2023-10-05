using UnityEngine;

namespace GFA.Case04
{
    public interface IPlayer
    {
        public float Velocity { get; set; }
        public Vector2 Movement { get; set; }
        public bool IsJumped { get; set; }
        public bool IsRolled { get; set; }
        public MoveBehaviour Behaviour { get; set; }
    }
    public enum MoveBehaviour
    {
        Idle,
        Run,
        Roll,
        Jump,


    }
}