using UnityEngine;

public class RotateCanvas : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found. Make sure you have a camera in the scene tagged as 'MainCamera'.");
        }
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - mainCamera.transform.position, Vector3.up);
    }
}
