using Unity.Collections;
using UnityEngine;
using UnityEngine.Serialization;


[System.Serializable]
    public struct PlayerValues
    {
    [Tooltip("How fast this player will move"), Range(1, 15)] public float forwardSpeed;

    [Header("Jump Values")] 
    public float jumpForce; 
    public float gravity;
    public LayerMask groundLayer;
    
    }
    [System.Serializable]
    public struct LineRay {
        public float  rayLength;
    }


    [System.Serializable]
    public struct CameraValue
    {
        public int yMin, yMax;
        public float distance, sensitivity;
        public Transform lookAt;
    }



