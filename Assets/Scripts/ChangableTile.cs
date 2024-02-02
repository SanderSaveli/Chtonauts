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

    public delegate void TileChganged(bool isCghangeToTarget);
    public event TileChganged OnTileChanged;

    [SerializeField] private GameObject changeTarget;
    private GameObject createdObject;

    private void Start()
    {
        ChangeTile(5);
    }

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
                createdObject = Instantiate(changeTarget, transform.position, transform.rotation);
            }
        }
    }
}
