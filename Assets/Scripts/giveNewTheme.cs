using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giveNewTheme : MonoBehaviour {
    [SerializeField]
    private GameObject[] tetrisTheme;
    [SerializeField]
    private GameObject[] yoshiTheme;

    private int lastUsed;
    private GameObject[] res;
	
	public GameObject[] setTheme()
    {
        int sug = Random.Range(1, 2);
        while (sug == lastUsed) {
            sug = Random.Range(1, 2);
        }
        print(sug);
        switch (sug)
        {
            case 1:
                res = tetrisTheme;
                lastUsed = 1;
                break;
            case 2:
                lastUsed = 2;
                res = yoshiTheme;
                break;
        }
        return res;
    }
}
