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
    private List<GameObject> prev_line;

    public List<Vector2> LinePoints
    {
        get
        {
            if (prev_line != null || prev_line.Count > 0)
            {
                List<Vector2> ans = new List<Vector2>();
                for (int i = 0; i < prev_line.Count; i++)
                {
                    ans.Add(prev_line[i].GetComponent<LineParts>().transform.position);
                }
                return ans;
            }
            else
            {
                return new List<Vector2>();
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        prev_line = new List<GameObject>();
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

            if (prev_line == null)
            {
                prev_line = new List<GameObject>();
            }
            for (int i = 0; i < prev_line.Count; i++)
            {
                prev_line[i].SendMessage("wait", i);
            }
            prev_line.Add(obj);

            if (prev_line.Count > 64 || prev_line[0].GetComponent<LineParts>().IsTimeUp)
            {
                Destroy(prev_line[0].gameObject);
                prev_line.RemoveAt(0);
            }
        }
    }

    void collision(GameObject lineParts)
    {
        /*GameObject enemyList = GameObject.Find("EnemyList");
        if (enemyList != null)
        {
            enemyList.SendMessage("Surround");
        }*

        /*GameObject enemyMgr = GameObject.Find("EnemyGenerator");
        if (enemyMgr != null)
        {
            GameObject enemyList = enemyMgr.GetComponent<EnemyGenerator>().enemyList;
            List<GameObject> enemies = enemyList.GetComponent<EnemyList>().enemies;
        //GameObject tekinokawari = GameObject.Find("tekinokawari");
            for (int i = 0; i < enemies.Count; i++)
            {
                Vector2 enemy_pos = new Vector2(tekinokawari.transform.position.x, tekinokawari.transform.position.y);
                bool[] isKill = new bool[] { false, false, false, false };
                // 上の検証
                Ray ray = new Ray(enemy_pos, transform.up);
                Debug.DrawRay(ray.origin, ray.direction, Color.red, 3.0f);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "LineParts")
                        isKill[0] = true;
                    print("hit[up]");
                }
                // 下の検証
                ray = new Ray(enemy_pos, -transform.up);
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 3.0f);

        if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "LineParts")
                        isKill[1] = true;
                    print("hit[down]");
                }
                // 右の検証
                ray = new Ray(enemy_pos, transform.right);
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 3.0f);

        if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "LineParts")
                        isKill[2] = true;
                    print("hit[right]");
                }
                // 左の検証
                ray = new Ray(enemy_pos, -transform.right);
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 3.0f);

        if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "LineParts")
                        isKill[3] = true;
                    print("hit[left]");
                }
                // isKillの検証
                bool b1 = true;
                foreach (bool b2 in isKill)
                {
                    b1 &= b2;
                }
                if (b1)
                {
            enemyMgr.SendMessage("Kill", i);
            print("kill");
                }
            }
        }*/


    }

    void EnemyAttacked()
    {
        GameObject[] line_parts = GameObject.FindGameObjectsWithTag("LineParts");
        foreach (GameObject g in line_parts)
        {
            Destroy(g);
        }
        prev_line.Clear();
    }
}