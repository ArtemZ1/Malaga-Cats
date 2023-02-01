using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
  

    [SerializeField] private Input_Manager _inputManager;
    [SerializeField] private CameraValue _cameraValue;
    
    private float _currentX, _currentY;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void LateUpdate()
    {

        var sens = (_cameraValue.sensitivity * 100) * Time.deltaTime;
        _currentX += _inputManager.MousePos.x * sens;
        _currentY += _inputManager.MousePos.y * sens;
       
        _currentY = Mathf.Clamp(_currentY, _cameraValue.yMin, _cameraValue.yMax);
        var direction = new Vector3(0, 0, -_cameraValue.distance);
        var rotation = Quaternion.Euler(_currentY ,_currentX, 0);
        var position = _cameraValue.lookAt.position;
        var transform1 = transform;
        transform1.position = position + rotation * direction;

        transform1.LookAt(position);
    }

    public float Sensitivity => _cameraValue.sensitivity;
    
 

}
