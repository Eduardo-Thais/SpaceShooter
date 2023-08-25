using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class _GC : MonoBehaviour
{
    public Text pontuacao;
    public int pontos;

    public int extraLife;
    public GameObject iconLifePrefab;
    public Transform extraLifeIcon;

    public GameObject[] extras;

    public Transform spawnPlayer;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        SetExtraLifes();
    }

    // Update is called once per frame
    void Update()
    {
        pontuacao.text = pontos.ToString();
    }

    void SetExtraLifes()
    {
        
        GameObject tempLife;
        float posXIcon;
        foreach (GameObject extra in extras) 
        {
            if (extra != null)
            {
                Destroy(extra);
            }
        }

        for (int i = 0; i < extraLife; i++)
        {
            posXIcon = extraLifeIcon.position.x + (0.5f * i);
            tempLife = Instantiate(iconLifePrefab) as GameObject;
            extras[i] = tempLife;
            tempLife.transform.position = new Vector3(posXIcon, extraLifeIcon.position.y, extraLifeIcon.position.z);

        }

        GameObject tempPlayer = Instantiate(player) as GameObject;
        tempPlayer.transform.position = spawnPlayer.position;

    }

    public void Died()
    {
        extraLife -= 1;
        if (extraLife >= 0)
        {
            SetExtraLifes();
        }
        else
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }
}
