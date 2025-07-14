using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    //[SerializeField] TextMeshProUGUI textPoints;
    [SerializeField] Slider playerLife;
    
    [SerializeField] TextMeshProUGUI endText;

    public static UIController instance;
    private int pointsAmmount;

    private void Awake()
    {
        instance = this;
    }

    public void SetLife(int life)
    {
        playerLife.value = life;
    }

    //public void AddPoint(int point)
    //{
    //    pointsAmmount += point;
    //    textPoints.text = "" + pointsAmmount;
    //}


}