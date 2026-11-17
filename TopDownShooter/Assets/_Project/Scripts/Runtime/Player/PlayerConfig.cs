using UnityEngine;

namespace TopDown.Player
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "TopDown/Player Config")]
    public sealed class PlayerConfig : ScriptableObject
    {
        [field: SerializeField, Min(0f)]
        public float MoveSpeed { get; private set; } = 6f;
    }
}
