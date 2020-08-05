using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxPlayerSlider : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text text = null;
    Slider slider;

    private void Awake()
    {
        NetWorkManager.GetMaxPlayer += () => GetMaxPlayer();
        slider = GetComponent<Slider>();
    }
    public void Slide()
    {
        text.text = slider.value.ToString();
    }

    float GetMaxPlayer()
    {
        return slider.value;
    }

}
