using TopDown.Input;
using UnityEngine;

namespace TopDown.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private InputReader inputReader;
        [SerializeField]
        private PlayerConfig playerConfig;
        private Rigidbody rb;
        private Vector2 playerMoveInput;

        private void OnMovementInput(Vector2 moveInput)
        {
            playerMoveInput = moveInput;
        }

        #region Unity Callbacks
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
        private void OnEnable()
        {
            inputReader.MoveChanged += OnMovementInput;
        }
        private void OnDisable()
        {
            inputReader.MoveChanged -= OnMovementInput;
        }
        private void FixedUpdate()
        {
            Vector2 moveInput = playerMoveInput;
            Vector3 linearVelocity = new(moveInput.x, rb.linearVelocity.y, moveInput.y);
            rb.linearVelocity = linearVelocity * playerConfig.MoveSpeed;
        }
        #endregion
    }
}
