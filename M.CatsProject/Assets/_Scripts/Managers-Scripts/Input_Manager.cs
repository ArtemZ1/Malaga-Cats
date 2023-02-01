using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(PlayerInput))]
    public class Input_Manager : MonoBehaviour
    {
        private ControllsPlayer _playerControllers;
        private void Awake() => _playerControllers = new ControllsPlayer();

        private bool[] _listTriggers = new bool[5];
        private Vector2[] _listVector2 = new Vector2[2];
        #region En/Dis
        private void OnEnable() => _playerControllers.Enable();
        private void OnDisable() => _playerControllers.Disable();
        #endregion

        #region Input Convert
        
        //Dit Convert het new input values in a public methods.
        public Vector2 MousePos => _listVector2[0];
        public Vector2 MovementVec => _listVector2[1];

        //Dit convert het triggers
        public bool Jump => _listTriggers[0];
        public bool Grab => _listTriggers[1];

        #endregion



        private void On_MousePos(InputValue input) => _listVector2[0] = input.Get<Vector2>();
        private void On_Movement(InputValue input) => _listVector2[1] = input.Get<Vector2>();

        private void On_Jump(InputValue input) => _listTriggers[0] = input.isPressed;
        private void On_Grab(InputValue input) => _listTriggers[1] = input.isPressed;
        private void On_Start(InputValue input) => _listTriggers[2] = input.isPressed;
        private void On_Options(InputValue input) => _listTriggers[3] = input.isPressed;
        private void On_Quit(InputValue input) => _listTriggers[4] = input.isPressed;
    }

