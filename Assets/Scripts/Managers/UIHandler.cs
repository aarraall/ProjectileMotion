using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Slider speedSlider;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private Slider heightSlider;
    [SerializeField] private TextMeshProUGUI heightText;


    private ShootHandler _shootHandler;

    private void Start()
    {
        _shootHandler = FindObjectOfType<ShootHandler>();
        speedText.text = _shootHandler.gravity.ToString();
        heightText.text = _shootHandler.firingAngle.ToString();
    }

    public void SetParameters()
    {
        _shootHandler.gravity = speedSlider.value;
        _shootHandler.firingAngle = heightSlider.value;
        speedText.text = _shootHandler.gravity.ToString();
        heightText.text = _shootHandler.firingAngle.ToString();
    }
}