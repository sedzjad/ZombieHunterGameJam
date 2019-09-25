using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLight : MonoBehaviour
{

    private SpriteRenderer sp;
    private float tempD, temp;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Blinking();
 
    }

    private void Blinking()
    {
        //float tempFrame = 2f;

        time += 0.2f * Time.deltaTime;
        tempD = Mathf.Lerp(0f, 255f , time );
        temp = tempD;
        Debug.Log(temp);

        sp.color = new Color(sp.color.r, sp.color.b, sp.color.g, temp);
        if (tempD == 255)
        {
            tempD = 0;
            time = 0.0f;
        }
        
    }
}
