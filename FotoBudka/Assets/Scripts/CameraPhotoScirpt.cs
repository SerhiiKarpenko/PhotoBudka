using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;

public class CameraPhotoScirpt : MonoBehaviour
{
    private static CameraPhotoScirpt instance;
    [SerializeField] private GameObject model;
    private Camera myCamera;
    private bool takeScreenShotOnNextFrame;
    private int index = 0;

    private void Awake()
    {
        instance = this;
        myCamera = gameObject.GetComponent<Camera>();
    }

    private void OnPostRender()
    {
        if (takeScreenShotOnNextFrame)
        {
            takeScreenShotOnNextFrame = false;
            RenderTexture renderTexture = myCamera.targetTexture;

            Texture2D result = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            result.ReadPixels(rect, 0, 0);

            byte[] byteArray = result.EncodeToPNG();
            File.WriteAllBytes(Application.dataPath + "/Output/" + model.GetComponent<MeshFilter>().mesh.name + index + ".png", byteArray);
            index++;

            RenderTexture.ReleaseTemporary(renderTexture);
            myCamera.targetTexture = null;
            SortFiles();
            
        }
    }


    private void SortFiles()
    {
        DirectoryInfo di = new DirectoryInfo(Application.dataPath + "/Output/");
        FileInfo[] files = di.GetFiles("*.png");
        Array.Sort(files, (x, y) => Comparer<DateTime>.Default.Compare(y.CreationTime, x.CreationTime));
    }


    private void TakePhoto(int width, int height)
    {
        myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeScreenShotOnNextFrame = true;
    }

    public void TakePhotoStatic()
    {
        TakePhoto(1920, 1080);
    }

}
