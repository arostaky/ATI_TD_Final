using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JetPackBar : MonoBehaviour{
    
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public void setMaxJetPack(float heat){
        slider.maxValue = heat;
        slider.value = heat;
        fill.color = gradient.Evaluate(1f);
    }
    public void setJetPack(float heat){
        slider.value = heat;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}