using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hp;
    void Start()
    {
        this.hp = GameObject.Find("hp");
    }

    // Update is called once per frame
    public void DecreaseHp()
    {
        this.hp.GetComponent<Image>().fillAmount -= 0.1f;
        if (hp.GetComponent<Image>().fillAmount == 0)
        {
            SceneManager.LoadScene("Over");
        }
    }
}
