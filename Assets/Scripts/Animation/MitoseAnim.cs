using UnityEngine;

public class MitoseAnim : MonoBehaviour
{
    [Header("Fibres FA : ")]
    public string FFAPropName;
    public float FFAAscend;
    public float FFAAscendP;
    public GameObject[] FibresP;
    public GameObject[] FibresChr;
    [Space(10f)]
    public Material FPMaterial;
    [Space(5f)]
    public string FPDessolveName;
    public float FPDessolve;

    [Space(15f)]
    [Header("Chromatide :")]
    public string CondParamName;
    public float Cond;
    [Space(10f)]
    public string LawyParamName;
    public float Lawy;
    [Space(7f)]
    public Animator[] Chromosomes;

    // Update is called once per frame
    void Update()
    {
        foreach (var FibreP in FibresP)
        {
            FibreP.GetComponent<SkinnedMeshRenderer>().material = FPMaterial;
            FibreP.GetComponent<SkinnedMeshRenderer>().material.SetFloat(FFAPropName, FFAAscendP);
            
            FibreP.GetComponent<SkinnedMeshRenderer>().material.SetFloat(FPDessolveName ,FPDessolve);
        }

        foreach (var FibreChr in FibresChr)
        {
            FibreChr.GetComponent<SkinnedMeshRenderer>().material.SetFloat(FFAPropName, FFAAscend);
        }

        foreach (var chr in Chromosomes)
        {
            chr.SetFloat(CondParamName, Cond);
            chr.SetFloat(LawyParamName, Lawy);
        }
    }
}
