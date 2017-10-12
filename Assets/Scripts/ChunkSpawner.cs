using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour {
    
    enum Stage {neutral, advanced, end};
    [SerializeField]
    private GameObject Gen_;

    public Ray2D checker;
    private RaycastHit2D checkerInfo;
    private GameObject neutralBlock;

    private BoxCollider2D neutralCol;

    [SerializeField]
    private Stage progression;
    private GameObject[] levelPieces = new GameObject[25];
    private List<GameObject> lvlBucket = new List<GameObject>();
    private int[] chosenPieces;
    private float time;
    private float totalDis;
    private giveNewTheme themeScript;
	
	void Start () {
        themeScript = Gen_.GetComponent<giveNewTheme>();
        levelPieces = themeScript.setTheme();
        neutralBlock = levelPieces[0];
        neutralCol = neutralBlock.GetComponent<BoxCollider2D>();
        progression = Stage.neutral;
        chosenPieces = RandPieceInt(15, 25, levelPieces);
        checker = new Ray2D(new Vector2(transform.position.x,transform.position.y),Vector2.down);
    }
	
	void Update () {
        switch (progression)
        {
            case Stage.neutral:
                SpawnNeutral(neutralBlock, neutralCol);
                break;
            case Stage.advanced:
                break;
            case Stage.end:
                chosenPieces = RandPieceInt(15,25,levelPieces);
                progression = Stage.neutral;
                break;
        }
		
	}
    public static int[] RandPieceInt(float min,float max, GameObject[] pieces)
    {   

        int[] res = new int[Mathf.RoundToInt(Random.Range(min, max))];
        List<int> usedNumbers = new List<int>();
        for (int i = 0; i < res.Length - 1; i++)
        {
            int sug = Mathf.RoundToInt(Random.Range(1, pieces.Length -1));
            while (usedNumbers.Contains(sug))
            {
                sug = Mathf.RoundToInt(Random.Range(1, pieces.Length -1));
            }
            res[i] = sug;
            usedNumbers.Add(sug);
        }
        usedNumbers.Clear();
        print(res);
        return res;
    }

    void SpawnChunk()
    {
        float placementSet = totalDis;
        float chunkDist = placementSet;
        float distColli;
        for (int i = 0;i < chosenPieces.Length; i++)
        {
            BoxCollider2D colli = levelPieces[chosenPieces[i]].GetComponent<BoxCollider2D>();
            distColli = colli.size.x;
            GameObject Chunk = Instantiate(levelPieces[chosenPieces[i]],new Vector3(chunkDist,0,0),Quaternion.identity);
            chunkDist += distColli;
        }
        GameObject EndChunk = Instantiate(levelPieces[25],new Vector3(chunkDist,0,0),Quaternion.identity);
    }

    private void ArangeBucket()        
    {
        for (int i = 0; i < chosenPieces.Length; i++)
        {
            lvlBucket.Add(levelPieces[chosenPieces[i]]);
        }
    }

    private void SpawnNeutral(GameObject object_, BoxCollider2D collider_)
    {
        float placementSet = transform.position.x;
        float perDist = collider_.size.x;
        int[] gaps = new int[3];
        gaps[0] = 1;
        gaps[1] = 1;
        gaps[2] = 2;
        int num = Mathf.RoundToInt(Random.Range(5, 10));
        int gapchance;
        int gapDist = 0;
        for (int i = 0; i < num; i++)
        {
            gapchance = Mathf.RoundToInt(Random.Range(0, 5));
            totalDis = placementSet + perDist + (i * perDist) + gapDist;
            GameObject newneutralPiece = Instantiate(object_, new Vector3(totalDis, 0, 0), Quaternion.identity);
            if (gapchance == 0 || gapchance == 1 || gapchance == 2)
            {
                gapDist += gaps[gapchance];
                gaps[gapchance] = 0;
            }
        }
    }
}
