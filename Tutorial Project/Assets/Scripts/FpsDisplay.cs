using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(FpsCounter))]
public class FpsDisplay : MonoBehaviour
{
    public Text fpsLabel;

    FpsCounter fpsCounter;

    void Awake()
    {
        fpsCounter = GetComponent<FpsCounter>();
    }

    void Update()
    {
        fpsLabel.text = fpsCounter.AverageFps.ToString();
    }
}
