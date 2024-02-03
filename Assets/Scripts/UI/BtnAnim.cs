using UnityEngine;
using UnityEngine.EventSystems;

public class BtnAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{
    public Animator animator;
    
    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("Highlited", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("Highlited", false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        animator.SetBool("Pressed", true);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        animator.SetBool("Pressed", false);
    }
}
