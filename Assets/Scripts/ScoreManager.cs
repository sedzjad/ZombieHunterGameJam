using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Score_Text _st;

    public GameObject[] highScoreSlot;

    // Start is called before the first frame update
    void Start()
    {
        _st = FindObjectOfType<Score_Text>();
    }


}
