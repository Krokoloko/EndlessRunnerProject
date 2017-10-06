using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour {
    
    enum Stage {neutral, advanced, end};
    public Ray2D spawner;
    public GameObject neutralBlock;
    private Stage progression;
    private int[] gaps = new int[5];
    private List<int> gapBucket = new List<int>();
    private GameObject[] levelPieces = new GameObject[25];
    private List<GameObject> lvlBucket = new List<GameObject>();
    private int[] chosenPieces;
    private float time;
	// Use this for initialization
	void Start () {
        progression = Stage.neutral;
        chosenPieces = randPieceInt(0, Mathf.RoundToInt(Random.Range(15, 25)), levelPieces);
        spawner = new Ray2D(new Vector2(transform.position.x,transform.position.y),Vector2.down);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public static int[] randPieceInt(float min,float max, GameObject[] pieces)
    {   

        int[] res = new int[Mathf.RoundToInt(Random.Range(min, max))];
        List<int> usedNumbers = new List<int>();
        for (int i = 0; i < res.Length; i++)
        {
            int sug = Mathf.RoundToInt(Random.Range(min, pieces.Length));
            while (usedNumbers.Contains(sug))
            {
                sug = Mathf.RoundToInt(Random.Range(min, pieces.Length));
            }
            res[i] = sug;
            usedNumbers.Add(sug);
        }
        usedNumbers.Clear();
        print(res);
        return res;
    }
    void neutralGenerate()
    {
        Instantiate<GameObject>(neutralBlock,new Vector3(transform.position.x,0,0),Quaternion.identity);
        
        
    }
    void arangeBucket()        
    {
        for (int i = 0; i < chosenPieces.Length; i++)
        {
            lvlBucket.Add(levelPieces[chosenPieces[i]]);
        }
    }
}
