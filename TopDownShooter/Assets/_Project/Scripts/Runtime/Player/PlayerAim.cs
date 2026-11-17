using TopDown.Input;
using UnityEngine;

namespace TopDown.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class PlayerAim : MonoBehaviour
    {
        [SerializeField]
        private InputReader inputReader;
        [SerializeField]
        private Camera viewCamera;

        #region Cached Variables
        private Rigidbody rb;
        private Quaternion targetRotation;
        #endregion

        #region Unity Callbacks
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            if (viewCamera == null)
            {
                Debug.LogError("PlayerAim: View Camera is not assigned in the inspector.", this);
                this.enabled = false;
                return;
            }
            targetRotation = rb.rotation;
        }

        private void Update()
        {
            var ray = viewCamera.ScreenPointToRay(inputReader.AimPosition);
            var plane = new Plane(Vector3.up, rb.position);
            if (plane.Raycast(ray, out float distance))
            {
                Vector3 aimDirection = ray.GetPoint(distance) - rb.position;
                aimDirection.y = 0f;
                if (aimDirection.sqrMagnitude < 0.0001f)
                    return;
                targetRotation = Quaternion.LookRotation(aimDirection);
            }
        }

        private void FixedUpdate()
        {
            rb.MoveRotation(targetRotation);
        }
        #endregion
    }
}
