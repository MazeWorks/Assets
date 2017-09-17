using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // 移動軌跡のためのリスト
    List<Vector3> MoveGoal;

    // 移動速度
    Vector2 Velocity;

    // 移動距離残量
    float MoveDistance;

    // 線のためのリスト
    List<Line> Lines;

    // 敵キャラのためのリスト
    List<GameObject> Enemies;

    // バリア
    public GameObject barrier;

    // スプライト
    public Sprite front;
    public Sprite side;
    public Sprite back;

    // Use this for initialization
    void Start()
    {
        MoveGoal = new List<Vector3>();
        Velocity = new Vector2(0, 0);
        MoveDistance = 0;
        Lines = new List<Line>();
        Enemies = new List<GameObject>();
        try
        {
            Enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        }
        catch (UnityException)
        {

        }
        gameObject.GetComponent<SpriteRenderer>().sprite = front;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // タップ時の位置を取得
            var mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // リストの最後の要素
            var last_move_goal = MoveGoal[MoveGoal.Count - 1];
            // 距離差を計算
            var diff_x = last_move_goal.x - mouse_position.x;
            var diff_y = last_move_goal.y - mouse_position.y;
            var diff_dst = Mathf.Sqrt(diff_x * diff_x + diff_y * diff_y);
            // 距離差が一定以上
            // ⇒距離の加算&リスト要素の追加
            if (diff_dst >= 1f)
            {
                MoveDistance += diff_dst;
                MoveGoal.Add(mouse_position);
            }

            // 自キャラの移動速度を計算
            // 移動距離残量が1以上の時だけ進む
            if (MoveDistance >= 1 && MoveGoal.Count > 1)
            {
                // リストの二個目の要素を取得
                var first_move_goal = MoveGoal[1];
                // ただし、指とキャラの単純な距離が離れすぎていたら途中を切ってそっちに向かう
                if (euclid_dst(mouse_position.x, mouse_position.y, transform.position.x, transform.position.y) > 4f)
                {
                    first_move_goal = mouse_position;
                    MoveGoal.Clear();
                    MoveGoal.Add(transform.position);
                    MoveDistance = euclid_dst(mouse_position.x, mouse_position.y, transform.position.x, transform.position.y);
                }
                // 移動距離の計算
                var mv_x = first_move_goal.x - transform.position.x;
                var mv_y = first_move_goal.y - transform.position.y;
                var mv_dst = Mathf.Sqrt(mv_x * mv_x + mv_y * mv_y);
                // 移動方向の計算
                float dir = Mathf.Atan2(mv_y, mv_x);
                // 移動速度の更新
                float speed = 10;
                Velocity.x = speed * Mathf.Cos(dir);
                Velocity.y = speed * Mathf.Sin(dir);
                // 移動距離が0.1未満の時リストの先頭を削除して移動距離残量を消費
                if (mv_dst < 0.1)
                {
                    diff_x = first_move_goal.x - MoveGoal[0].x;
                    diff_y = first_move_goal.y - MoveGoal[0].y;
                    diff_dst = Mathf.Sqrt(diff_x * diff_x + diff_y * diff_y);
                    MoveDistance -= diff_dst;
                    MoveGoal.RemoveAt(0);
                }
            }
            else
            {
                Velocity = new Vector2(0, 0);
            }
        }
        else
        {
            Velocity = new Vector2(0, 0);
            MoveGoal.Clear();
            MoveGoal.Add(transform.position);
            MoveDistance = 0;
        }
        Rigidbody2D rd = GetComponent<Rigidbody2D>();
        rd.velocity = Velocity;
        var res_dir = Mathf.Atan2(Velocity.x, Velocity.y) * Mathf.Rad2Deg;
        if (Velocity.x != 0 || Velocity.y != 0)
        {
            print(res_dir);
            if (-45 < res_dir && res_dir <= 45)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = back;
            }
            else if (45 < res_dir && res_dir <= 135)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = side;
                var scale = transform.localScale;
                scale.x = -1;
                transform.localScale = scale;
            }
            else if (-135 < res_dir && res_dir <= -45)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = side;
                var scale = transform.localScale;
                scale.x = 1;
                transform.localScale = scale;
            }
            else if (res_dir < -135 || 135 < res_dir)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = front;
            }
        }

        if (Velocity.x != 0 && Velocity.y != 0)
        {
            Line line = Line.Add(transform.position.x, transform.position.y);
            Lines.Add(line);
            if (Lines.Count > 128)
            {
                Destroy(Lines[0].gameObject);
                Lines.RemoveAt(0);
            }
            Lines[0].SpriteChange_point();
        }

        if (Enemies.Count == 0)
        {
            try
            {
                Enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
            }
            catch (UnityException)
            {

            }
        }
        if (Enemies.Count != 0)
        {
            int polygon_index = completePolygon();
            if (polygon_index >= 0)
            {
                for (int i = 0; i < Enemies.Count; i++)
                {
                    var enemy_position = Enemies[i].transform.position;
                    float total_angle = 0;
                    for (int j = Lines.Count - 1; j > polygon_index; j--)
                    {
                        var point1 = Lines[j].transform.position;
                        var point2 = Lines[j - 1].transform.position;

                        var vec1_x = point1.x - enemy_position.x;
                        var vec1_y = point1.y - enemy_position.y;

                        var vec2_x = point2.x - enemy_position.x;
                        var vec2_y = point2.y - enemy_position.y;

                        var angle1 = Mathf.Atan2(vec1_x, vec1_y);
                        var angle2 = Mathf.Atan2(vec2_x, vec2_y);

                        var angle = Mathf.Abs(angle1 - angle2);
                        if (angle >= Mathf.PI)
                        {
                            angle = 2 * Mathf.PI - angle;
                        }
                        total_angle += angle * Mathf.Rad2Deg;

                        if (359.9 < total_angle && total_angle < 360.1)
                        {
                            Enemies[i].SendMessage("kill");
                        }
                    }
                }
            }
        }
    }

    private void kill()
    {
        Barrier barrier_cmp = barrier.GetComponent<Barrier>();
        if (barrier_cmp.isActive)
        {
            barrier.GetComponent<Barrier>().active();
            return;
        }

        Destroy(this.gameObject);

        foreach (Line line in Lines)
        {
            Destroy(line.gameObject);
        }

        for (int i = 0; i < 32; i++)
        {
            PlayerDeath.Add(transform.position.x, transform.position.y);
        }
    }

    private void GetItem(int type)
    {
        switch (type)
        {
            case 0:
                break;
            case 1:
                barrier.GetComponent<Barrier>().active();
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        }
    }

    private float euclid_dst(float x1, float y1, float x2, float y2)
    {
        float diff_x = x2 - x1;
        float diff_y = y2 - y1;

        return Mathf.Sqrt(diff_x * diff_x + diff_y * diff_y);
    }

    private int completePolygon()
    {
        if (Lines.Count < 4)
        {
            return -1;
        }

        var last_line_start = Lines[Lines.Count - 2].transform.position;
        var last_line_end = Lines[Lines.Count - 1].transform.position;

        for (int i = Lines.Count - 3; i > 0; i--)
        {
            var cur_line_start = Lines[i - 1].transform.position;
            var cur_line_end = Lines[i].transform.position;

            if (judgeIentersected(last_line_start, last_line_end, cur_line_start, cur_line_end))
            {
                return i;
            }
        }

        return -1;
    }

    private bool judgeIentersected(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
    {
        var ta = (c.x - d.x) * (a.y - c.y) + (c.y - d.y) * (c.x - a.x);
        var tb = (c.x - d.x) * (b.y - c.y) + (c.y - d.y) * (c.x - b.x);
        var tc = (a.x - b.x) * (c.y - a.y) + (a.y - b.y) * (a.x - c.x);
        var td = (a.x - b.x) * (d.y - a.y) + (a.y - b.y) * (a.x - d.x);

        return tc * td <= 0 && ta * tb <= 0;
    }
}
