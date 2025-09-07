using UnityEngine;
using UnityEngine.UI;

public class ObjectsController : MonoBehaviour
{
    public ToggleObjs[] TObjs;
    public void FlipAvtication(GameObject Obj)
    {
        Obj.SetActive(!Obj.active);
    }

    public void SetActivationFToggle(int index)
    {
        var o = TObjs[index];
        foreach (var Obj in o.Objs)
        {
            Obj.SetActive(o.tgl.isOn);
        }
    }
}

[System.Serializable]
public class ToggleObjs
{
    public Toggle tgl;
    [Space(10f)]
    public GameObject[] Objs;
}
