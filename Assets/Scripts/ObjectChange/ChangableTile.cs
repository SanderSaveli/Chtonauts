using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangableTile : MonoBehaviour
{
    public bool IsChganged {  get => _isChganged; 
        protected set {
            _isChganged = value;
            OnTileChanged?.Invoke(value);
        } 
    }
    private bool _isChganged; 
    public float ChangeTimeLeft {  get; protected set; }

    [SerializeField] private GameObject _changeTarget;
    [SerializeField] private TileType _type;
    public TileType TileType { get => _type; }

    private GameObject createdObject;

    public delegate void TileChganged(bool isCghangeToTarget);
    public event TileChganged OnTileChanged;

    public bool ChangeTile(float duration)
    {
        if(IsChganged)
        {
            return false;
        }
        StartCoroutine(WaitTimeAndChangeBack(duration));
        ChangeGeometry(false);
        IsChganged = true;
        return true;

    }

    IEnumerator WaitTimeAndChangeBack(float tinme)
    {
        ChangeTimeLeft = tinme;
        while(ChangeTimeLeft > 0) 
        { 
            ChangeTimeLeft -= Time.deltaTime;
            yield return null;
        }
        ChangeBack();
    }

    protected void ChangeBack()
    {
        ChangeTimeLeft = 0;
        IsChganged = false;
        ChangeGeometry(true);
    }

    protected void ChangeGeometry(bool isActive)
    {
        GetComponent<MeshRenderer>().enabled = isActive;
        if(isActive) 
        {
            if(createdObject != null)
            {
                Destroy(createdObject);
            }
        }
        else
        {
            if(createdObject == null) 
            { 
                createdObject = Instantiate(_changeTarget, transform.position, transform.rotation);
            }
        }
    }
}
