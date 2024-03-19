using UnityEngine;
using Zenject;

namespace InputSystem
{
    public class cameraController : MonoBehaviour
    {
        public float horisontalSpeed = 5.0f;
        public float verticalSpeed = 0.5f;
        [SerializeField] float minCameraWidth = 6;
        [SerializeField] float maxCameraWidth = 15;
        private IInputManager inputManager;
        private float _cameraWidth;

        private void Start()
        {
            _cameraWidth = transform.position.y;
        }

        [Inject]
        private void Construct(IInputManager inputManager)
        {
            this.inputManager = inputManager;
        }

        void Update()
        {
            MoveCametra();
            ChangeCameraWidth();
        }

        private void MoveCametra()
        {
            Vector2 input = inputManager.inputs.GameControl.CameraMove.ReadValue<Vector2>();
            Vector3 dir = transform.forward * input.y + transform.right * input.x;
            dir.y = 0;
            transform.position += dir * horisontalSpeed * Time.deltaTime;
        }

        private void ChangeCameraWidth()
        {
            Vector2 input = inputManager.inputs.GameControl.CasmeraWidthChange.ReadValue<Vector2>();
            float newPos = _cameraWidth + (-input.y * Time.deltaTime);
            newPos = Mathf.Clamp(newPos, minCameraWidth, maxCameraWidth);
            _cameraWidth = newPos;
            Vector3 dir = transform.position;
            dir.y = newPos;
            transform.position = Vector3.Lerp(transform.position, dir, verticalSpeed * Time.deltaTime);
        }
    }
}
