
using UnityEngine;



    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerValues _playerValues;
        [SerializeField] private LineRay _buttomCollider;
        [SerializeField] private Input_Manager _inputManager;
        [SerializeField] private Camera _camera;

        private float _sensitivity;
        private Vector3 _playerVelocity;
        
        #region Components
        private CharacterController _characterController;
        #endregion

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _sensitivity = _camera.GetComponent<Camera_Movement>().Sensitivity;
        }

        private void Update()
        {
            HandleJump();
            HandelMovement(_playerValues.forwardSpeed, _playerValues.gravity);
         
        }

        private void HandelMovement(float speed, float gravity)
        {
            

            var move = new Vector3(_inputManager.MovementVec.x, 0, _inputManager.MovementVec.y);
            var cam = _camera.transform;
            var movement = cam.right * move.x + cam.forward * move.z;
            movement.y = 0f;
            

            _characterController.Move(movement * (speed * Time.deltaTime));
            
            if (movement.magnitude == 0f) return;
            Transform transform1;
            (transform1 = transform).Rotate(Vector3.up * (move.x * _sensitivity * Time.deltaTime));


            var camRotation = cam.rotation;
            camRotation.x = 0f;
            camRotation.z = 0f;

            transform.rotation = Quaternion.Lerp(transform1.rotation, camRotation, 0.1f);
        }
        

        #region Jump

        private void HandleJump()
        {
            var calculateJumpHeight = (_inputManager.Jump && IsGrounded) ?
                CalculateJumpHeight(_playerValues.jumpForce, _playerValues.gravity) 
                : ApplyGravity(_playerValues.gravity);
            _playerVelocity.y += calculateJumpHeight;
            _characterController.Move(_playerVelocity * Time.deltaTime);
        }

        private float ApplyGravity(float gravity) => gravity * Time.deltaTime;

        private float CalculateJumpHeight(float jump, float gravity)
        {
            _playerVelocity = Vector3.zero;
            return (2 * jump);
        }

        public bool IsGrounded
        {
            get
            {
                var position = transform.position;
                var pos = new Vector3(position.x, position.y - _buttomCollider.rayLength, position.z);
                var radius = _buttomCollider.rayLength;
                var layerMask = _playerValues.groundLayer;
                return Physics.Raycast(position, Vector3.down, radius, layerMask);
            }
        }

        #endregion

        protected virtual void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            // Draw sphere for the grounded check area
            var position = transform.position;
            var pos = new Vector3(position.x, position.y - _buttomCollider.rayLength, position.z);
            Gizmos.DrawLine(position, pos);
        }
    }
