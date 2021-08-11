using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing_grid : MonoBehaviour
{
    GameObject[,] testingGameObject;
    public Vector2 testingDemWorldPositions;
    public GameObject testingPrefab;
    public float radius;
    float diameter;

    public LayerMask testinLM;

    public Transform startingPosition;
    // Start is called before the first frame update
    void Start()
    {
       

        int intVectorX = (int)testingDemWorldPositions.x;
        int intVectorY = (int)testingDemWorldPositions.y;
        intVectorX = intVectorX / (int)testingPrefab.transform.localScale.x;
        intVectorY = intVectorY / (int)testingPrefab.transform.localScale.y;
        
        testingGameObject = new GameObject[intVectorX, intVectorY];

        Vector3 worldPosition = transform.position + startingPosition.transform.position + testingPrefab.transform.localScale/2;


        for (int x = 0; x < intVectorX; x++)
        {
            for (int y = 0; y< intVectorY; y++)
            {


                Vector3 posXY = worldPosition + Vector3.right * (x * testingPrefab.transform.localScale.x * radius) + Vector3.forward * (y * testingPrefab.transform.localScale.y * radius);
                
                
                testingGameObject[x, y] = Instantiate(testingPrefab, posXY, Quaternion.identity);
                print(testingGameObject[x, y]);
                float radiusSum = (testingGameObject[x, y].transform.localScale.x + testingGameObject[x, y].transform.localScale.y + testingGameObject[x, y].transform.localScale.z) / 3;
                if (Physics.CheckSphere(testingGameObject[x, y].transform.position, radiusSum, testinLM))
                    testingGameObject[x, y].GetComponent<Renderer>().material.color = new Color(1, 0, 0);
                //print("THE VECTOR YO" + yo);
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
