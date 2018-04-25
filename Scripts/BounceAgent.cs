using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceAgent : Agent {

    public float speed;
    public GameObject ball;

    public override void CollectObservations()
    {
        AddVectorObs(ball.transform.position.x - gameObject.transform.position.x);

        //状態数は少なくても上手くいったため、削除
        // AddVectorObs(gameObject.transform.position);
        // AddVectorObs(ball.transform.GetComponent<Rigidbody>().velocity);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ball")
        {
            //衝突する度に報酬を与える
            SetReward(1f);
        }
    }
    public override void AgentAction(float[] vectorAction, string textAction)
	{
        MoveAgent(vectorAction);

        //以下のような報酬の与え方でもよいが、単に衝突時に報酬を与えてもうまくいくため削除
        // if (Mathf.Abs(ball.transform.position.x - gameObject.transform.position.x) < 0.2f)
        // {
        //     SetReward(0.1f);
        // }
        // else{
        //     SetReward(-0.1f);
        // }

        if ((ball.transform.position.y - gameObject.transform.position.y) < 0)
        {
            //ゲームオーバー時に報酬を引く方法だとうまくいかなかった
            // SetReward(-10f);
            Done();
        }

        // Monitor.Log ("Reward", reward);
    }

    public override void AgentReset()
    {
        ball.transform.position = new Vector3(Random.Range(-0.2f,0.2f),1.5f,0) + gameObject.transform.position;
        ball.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
    }

    public void MoveAgent(float[] act)
    {
        int action = Mathf.FloorToInt(act[0]);

        //アクション
        if (action == 1)
        {
            transform.Translate(-speed, 0, 0);
            // AddReward(-0.01f);
        }
        if (action == 2)
        {
            transform.Translate(speed, 0, 0);
            // AddReward(-0.01f);
        }

        //移動制限
        if (transform.localPosition.x < -1.5f)
        {
            transform.localPosition = new Vector3(-1.5f, 0, 0);
        }
        if (1.5f < transform.localPosition.x)
        {
            transform.localPosition = new Vector3(1.5f, 0, 0);
        }
    }
}