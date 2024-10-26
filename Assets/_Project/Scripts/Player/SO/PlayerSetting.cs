using UnityEngine;

namespace MyCode._Player
{
    [CreateAssetMenu(menuName = "Player/Setting", fileName = nameof(PlayerSetting))]
    public class PlayerSetting : ScriptableObject
    {
        [field: SerializeField,Header("Move")] public float MoveSpeed { get; private set; } = 5f;
        [field: SerializeField, Header("Camera")] public float LookSpeed { get; private set; } = 2f;
        [field: SerializeField] public float LookXLimit { get; private set; } = 80f;
        [field: SerializeField, Header("Items")] public float PickUpRange { get; private set; } = 3f;
    }
}