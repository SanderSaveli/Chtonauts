using UnityEngine;

public class ManaSpender : MonoBehaviour
{
    private IManaService _manaService;

    private ManaCostCalculator _costCalculator;
    private DurationCalculator _durationCalculator;

    private void Start()
    {
        _costCalculator = GetComponent<ManaCostCalculator>();
        _durationCalculator = GetComponent<DurationCalculator>();
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
                if (clickedObject.TryGetComponent<ChangableTile>(out ChangableTile changableTile))
                {
                    ActivateTile(changableTile);
                }
            }
        }
    }

    private void ActivateTile(ChangableTile tile)
    {
        int changeCost = _costCalculator.getCost(tile.TileType);
        if (_manaService.TrySpendMana(changeCost))
        {
            tile.ChangeTile(_durationCalculator.getDuration(tile.TileType));
        }
    }
}
