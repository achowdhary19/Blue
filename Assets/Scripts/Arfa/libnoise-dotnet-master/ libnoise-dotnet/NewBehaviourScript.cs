using UnityEngine;
using LibNoise;
using System.Collections;

class NoiseExample : MonoBehaviour
{
    private Texture2D texture;
    private Voronoi voronoiNoise;
    private Perlin perlinNoise;
    private bool isVoronoi = false;

    void Start()
    {
        //create the texture
        texture = new Texture2D(1024, 1024);
        texture.wrapMode = TextureWrapMode.Clamp;

        //create some voronoi noise
        voronoiNoise = new Voronoi();

        //create some perlin noise, and set the seed
        perlinNoise = new Perlin();
        perlinNoise.Seed = 1001; //important, starting point for creating seed 

        StartCoroutine(UpdateImage());
    }

    //continuously create new images from the noise
    private IEnumerator UpdateImage()
    {
        float timeToCreateNoise;
        float timeToSetPixels;
        float timeToApplyToImage;

        int pixels = texture.width * texture.height;
        int width = texture.width;
        int height = texture.height;
        Color[] colors = new Color[pixels];

        while (true)
        {
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            timer.Start();

            float depth = Time.time / 2f;
            
            for (int i = 0; i < pixels; i++)
            {
                float value;
                if (isVoronoi)
                    value = (float)voronoiNoise.GetValue((float)(i % width) / width * 4f, depth, i / width / (float)width * 4f);
                else //perlin
                    value = (float)perlinNoise.GetValue((float)(i % width) / width * 4f, depth, i / width / (float)width * 4f);
                colors[i] = new Color(value, value, value);
            }

            timeToCreateNoise = timer.ElapsedMilliseconds;

            texture.SetPixels(colors);

            timeToSetPixels = timer.ElapsedMilliseconds - timeToCreateNoise;

            texture.Apply();

            timeToApplyToImage = timer.ElapsedMilliseconds - (timeToSetPixels + timeToCreateNoise);

            Debug.Log("Updating image took: create noise: " + timeToCreateNoise + ", set pixels: " + timeToSetPixels + ", apply: " + timeToApplyToImage);

            timer.Stop();

            yield return null;
        }
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width / 2f - Screen.height / 2f, 0f, Screen.height, Screen.height), texture);
    }
}