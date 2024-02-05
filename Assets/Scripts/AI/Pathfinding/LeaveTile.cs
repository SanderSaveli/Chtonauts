using UnityEngine;

public class LeaveTile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<MoveController>(out MoveController component))
        {
            if (component.hasAtrifact)
            {
                Debug.Log("Explorrer Win!");
            }
        }
    }
}
