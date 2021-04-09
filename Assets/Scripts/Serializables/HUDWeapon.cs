using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class HUDWeapon
{
    [SerializeField]
    private Text txtActualAmmo;
    [SerializeField]
    private Text txtMaxAmmo;

    public void SetActualAmmo(float value) {
        txtActualAmmo.text = value.ToString();
    }

    public void SetMaxAmmo(float value)
    {
        txtMaxAmmo.text = value.ToString();
    }

    public void SetAmmo(float max, float actual) {
        txtActualAmmo.text = actual.ToString();
        txtMaxAmmo.text = max.ToString();
    }

}
