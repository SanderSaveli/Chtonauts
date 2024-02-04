using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePages : MonoBehaviour
{
    [SerializeField] private float pageSpeed = 0.1f;
    [SerializeField] private List<Transform> pages;
    private int index = -1;
    private bool rotate = false;
    

    public void RotateForward()
    {
        if (rotate)
        {
            return;
        }
        index++;
        float angle = 180;
        pages[index].SetAsLastSibling();
        StartCoroutine(Rotate(angle, true));
    }

    public void RotateBack()
    {
        if (rotate)
        {
            return;
        }
        float angle = 0;
        pages[index].SetAsLastSibling();
        StartCoroutine(Rotate(angle, false));
    }

    IEnumerator Rotate(float angle, bool forward)
    {
        float value = 0f;
        while (true)
        {
            rotate = true;
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
            value += Time.deltaTime * pageSpeed;
            pages[index].rotation = Quaternion.Slerp(pages[index].rotation, targetRotation, value); //smoothly turn the page
            float angle1 = Quaternion.Angle(pages[index].rotation, targetRotation); //calculate the angle between the given angle of rotation and the current angle of rotation
            if (angle1 < 0.1f)
            {
                if (forward == false)
                {
                    index--;
                }

                rotate = false;
                break;
            }
            yield return null;
        }
    }
}
