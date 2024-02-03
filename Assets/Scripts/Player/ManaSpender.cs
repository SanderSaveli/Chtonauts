using UnityEngine;

public class ManaSpender : MonoBehaviour
{
    private IManaService _manaService;

    private IManaCostCalculator _costCalculator;

    private void Start()
    {
        _costCalculator = ServiceLocator.Get<IManaCostCalculator>();
        Debug.Log(_costCalculator.ToString());
        _manaService = ServiceLocator.Get<IManaService>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;
                if (clickedObject.TryGetComponent<InteractiveTile>(out InteractiveTile changableTile))
                {
                    ActivateTile(changableTile);
                }
            }
        }
    }

    private void ActivateTile(InteractiveTile tile)
    {
        int changeCost = _costCalculator.getCost(tile.TileType);
        if (_manaService.TrySpendMana(changeCost))
        {
            tile.ActivateTile();
        }
    }
}
