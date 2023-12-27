using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HPBarScript : MonoBehaviour
{
    float HP = 10;
    public UnityEngine.UI.Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = HP;

        if(Input.GetMouseButtonDown(0))
        {
            HP -= 1;
        }
    }
}
