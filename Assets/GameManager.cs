using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text FPSText;
    private float count;
    public int screenResolution;

    // Update is called once per frame
    void Update()
    {
        FPSText.text = count.ToString();
        screenResolution = Screen.currentResolution.refreshRate;
    }    

    private IEnumerator Start()
    {
        while (true)
        {
            count = 1f / Time.unscaledDeltaTime;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
