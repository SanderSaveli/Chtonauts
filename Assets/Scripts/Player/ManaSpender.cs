using UnityEngine;
using Zenject;

public class ManaSpender : MonoBehaviour
{
    private IManaService _manaService;

    private IManaCostCalculator _costCalculator;

    private Camera _camera;


    private void Start()
    {
        _camera = Camera.main;
    }

    [Inject] 
    private void Construct(IManaService manaService, IManaCostCalculator manaCostCalculator)
    {
        _manaService = manaService;
        _costCalculator = manaCostCalculator;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            RaycastHit[] clickedObj = Physics.RaycastAll(ray);

            foreach(RaycastHit hitObj in clickedObj) 
            {
                GameObject clickedObject = hitObj.collider.gameObject;
                if (clickedObject.TryGetComponent<InteractiveTile>(out InteractiveTile changableTile))
                {
                    ActivateTile(changableTile);
                    break;
                }
            }
        }
    }

    private void ActivateTile(InteractiveTile tile)
    {
        int changeCost = _costCalculator.getCost(tile.TileType);
        if (tile.isAvailable)
        {
            if (_manaService.TrySpendMana(changeCost))
            {
                tile.ActivateTile();
            }
        }
    }
}
