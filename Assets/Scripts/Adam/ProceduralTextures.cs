using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ProceduralTextures : MonoBehaviour
{

    private Texture2D texture; 
    
    
    // Start is called before the first frame update
    void Start()
    {
   
        
        //Code goes here 
        Color[] pixels = texture.GetPixels();
        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i] = new Color(1-pixels[i].r, 1-pixels[i].g, 1-pixels[i].b, pixels[i].a);
        }
        
        texture.SetPixels(pixels);
        texture.Apply();
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), texture);
    }
     
}
