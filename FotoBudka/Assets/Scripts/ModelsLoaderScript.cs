using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using UnityEditor;

public class ModelsLoaderScript : MonoBehaviour
{
	// here can be array or list
    private string directoryPath;
    private Object[] objects;
    public List<Mesh> meshes = new List<Mesh>();
 
    private void Start()
    {
        directoryPath = Application.dataPath + "/Resources/Input/";
        if (Directory.Exists(directoryPath))
        {
            objects = Resources.LoadAll("Input"); 
            for(int i = 0; i < objects.Length; i++)
                if(objects[i].GetType() == typeof(Mesh))
                    meshes.Add((Mesh)objects[i]);
        }
        else
        {

            Debug.Log("Create [Input] directory inside resources"); return;
        }

        
    }
}
