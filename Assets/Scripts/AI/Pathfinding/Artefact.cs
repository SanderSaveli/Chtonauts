using UnityEngine;

public class Artefact : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<MoveController>(out MoveController component))
        {
            component.hasAtrifact = true;
            Destroy(gameObject);
        }
    }
}
