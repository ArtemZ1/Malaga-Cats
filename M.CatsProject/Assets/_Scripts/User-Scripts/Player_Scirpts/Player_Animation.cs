
using UnityEngine;


    public class Player_Animation : MonoBehaviour
    {
        [SerializeField] private float _smoothSpeed;
        [SerializeField] private string  _RunAnim, _JumpAnim, _SideAnimR, _SideAnimL, _BackToIdle, _GrabAnim;
        
        [SerializeField] private Input_Manager _inputManager;
        
        
        private Vector2 currentInput, SmoothInput;

        private Animator _animator;
        private PlayerMovement _playerMovement;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _playerMovement = gameObject.GetComponentInParent<PlayerMovement>();
        }

        private void Update()
        {
            Running_Anim();
            Jump_Anim();
          //  Grab_Anim();
        }

        private void Running_Anim()
        {
            currentInput = Vector2.SmoothDamp(currentInput, _inputManager.MovementVec, ref SmoothInput, _smoothSpeed);
            _animator.SetFloat(_RunAnim, Mathf.Abs(currentInput.y));
            
            if(currentInput.x > 0.1) _animator.SetTrigger(_SideAnimR);
            else if (currentInput.x < -0.1) _animator.SetTrigger(_SideAnimL);
            else
            {
                _animator.SetTrigger(_BackToIdle);
            }
        }

        private void Jump_Anim() => _animator.SetBool(_JumpAnim, _playerMovement.IsGrounded);
       // private void Grab_Anim() => _animator.SetBool(_GrabAnim, _grabSystem.Grab);
    }

