using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class PressButton1 : MonoBehaviour
{
    public Button Button1; 
    // Start is called before the first frame update
    void Start()
    {
        Button1.onClick.AddListener(WeristColab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void WeristColab()
    {
        Application.OpenURL("https://fk9.uni-wuppertal.de/de/studium/projekt-colab/");
    }
}
