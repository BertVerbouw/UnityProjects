using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCounter : MonoBehaviour
{
    public int AverageFps { get; private set; }
    int[] fpsBuffer;
    int fpsBufferIndex;
    public int frameRange = 60;

    void InitializeBuffer()
    {
        if (frameRange <= 0)
        {
            frameRange = 1;
        }
        fpsBuffer = new int[frameRange];
        fpsBufferIndex = 0;
    }

    void Update()
    {
        if (fpsBuffer == null || fpsBuffer.Length != frameRange)
        {
            InitializeBuffer();
        }
        UpdateBuffer();
        CalculateFPS();
    }

    void UpdateBuffer()
    {
        fpsBuffer[fpsBufferIndex++] = (int)(1f / Time.unscaledDeltaTime);
        if (fpsBufferIndex >= frameRange)
        {
            fpsBufferIndex = 0;
        }
    }

    void CalculateFPS()
    {
        int sum = 0;
        for (int i = 0; i < frameRange; i++)
        {
            sum += fpsBuffer[i];
        }
        AverageFps = sum / frameRange;
    }
}