using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHider : MonoBehaviour
{
    public Sprite ActivatedUI;
    public Sprite DesactivatedUI;

    public void ChangeUIVisibility(GameObject UI)
    {
        var activation = !UI.active;

        UI.SetActive(activation);

        var Img = GetComponent<Image>();
        if (activation)
            Img.sprite = ActivatedUI;
        else
            Img.sprite = DesactivatedUI;
    }
}
