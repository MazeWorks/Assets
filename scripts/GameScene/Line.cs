using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{

    public GameObject linePrefab;
    public float lineLength = 0.2f;
    public float lineWidth = 0.1f;
    public GameObject player;

    private Vector3 touchPos;

    // Use this for initialization
    void Start()
    {
        touchPos = player.transform.position;
        touchPos.z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        drawLine();
    }

    void drawLine()
    {

        Vector3 startPos = touchPos;
        Vector3 endPos = player.transform.position;
        endPos.z = 0;

        if ((endPos - startPos).magnitude > lineLength)
        {
            GameObject obj = Instantiate(linePrefab, transform.position, transform.rotation) as GameObject;
            obj.transform.position = (startPos + endPos) / 2;
            obj.transform.right = (endPos - startPos).normalized;

            obj.transform.localScale = new Vector3((endPos - startPos).magnitude, lineWidth, lineWidth);

            obj.transform.parent = this.transform;

            touchPos = endPos;
            print(GameObject.FindGameObjectsWithTag("LinerParts").Length);
        }
    }
}
