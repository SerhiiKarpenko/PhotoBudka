using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ModelsLoaderScript : MonoBehaviour
{
	// here can be array or list
	private List<GameObject> models = new List<GameObject>();
    private string folderPath;

    private void Start()
    {
	    folderPath = Application.streamingAssetsPath + "/Input" + "/Douglas.fbx";
        LoadModels();
    }



    private void LoadModels()
    {
        //adding models from file Input
        //models.Add();
        if (File.Exists(folderPath))
            Debug.Log(folderPath);
    }

}
