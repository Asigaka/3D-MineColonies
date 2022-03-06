using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    [SerializeField] private int width = 256;
    [SerializeField] private int height = 256;
    [SerializeField] private float scale = 20;
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;

    [Space(5)]
    [SerializeField] private List<Color> colors;

    private void Start()
    {
        xOffset = Random.Range(0, 9999);
        yOffset = Random.Range(0, 9999);
        Generate();
    }

    public void Generate()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenerateTexture();
    }

    private Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();
        return texture;
    }

    private Color CalculateColor(int x, int y)
    {
        float xCoord = (float)x / width * scale + xOffset;
        float yCoord = (float)y / height * scale + yOffset;

        float aSample = Mathf.PerlinNoise(xCoord, yCoord);
        float bSample = aSample * 10;
        int cSample = (int) bSample;
        return SetColor(cSample);
    }

    private Color SetColor(int index)
    {
        return colors[index];
    }
}
