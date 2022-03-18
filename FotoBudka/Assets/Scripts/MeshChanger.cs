using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshChanger : MonoBehaviour
{
    [SerializeField] private ModelsLoaderScript modelsLoader;
    [SerializeField] private GameObject ModelPrefab;
    private int placeOfNumberMesh = 0;

    private void Start()
    {
        ModelPrefab.GetComponent<MeshFilter>().mesh = modelsLoader.meshes[placeOfNumberMesh];
    }

    public void OnForwadButton()
    {
        if (placeOfNumberMesh == modelsLoader.meshes.Count - 1)
            placeOfNumberMesh = 0;
        else
            placeOfNumberMesh++;
        ModelPrefab.GetComponent<MeshFilter>().mesh = modelsLoader.meshes[placeOfNumberMesh];

    }

    public void OnBackButton()
    {
        if (placeOfNumberMesh <= 0)
            placeOfNumberMesh = modelsLoader.meshes.Count - 1;
        else
            placeOfNumberMesh--;
        ModelPrefab.GetComponent<MeshFilter>().mesh = modelsLoader.meshes[placeOfNumberMesh];
    }


}
