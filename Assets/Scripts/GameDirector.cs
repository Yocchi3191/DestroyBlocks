using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
  //プレハブの情報を取得
  public GameObject prefabPlayer;
  public GameObject prefabBall;
  public GameObject prefabBlock;

  //CreateBlocksを実行する際に，BlockGeneratorの関数を使用するので，それ用に取得しておく
  public BlockGenerator blockGenerator;

  public Button buttonRight;

  //シーン中のオブジェクトの情報を取得
  private GameObject player;
  private GameObject ball;
  public GameObject[] blocks;
  public int count;

  // Start is called before the first frame update
  void Start()
  {
    CreateBlocks();
    player = GameObject.FindWithTag("Player");
    ball = GameObject.FindWithTag("Ball");
    buttonRight = GameObject.Find("Canvas").GetComponent<Button>(); ;
  }

  // Update is called once per frame
  void Update()
  {
    //終了条件1：全てのブロックが破壊される
    //終了条件2：ボールがプレイヤーよりも下に行く
    //どちらかを満たした場合ゲームシーンを停止
    if (AllBlocksDestroyed() || BallBelowPlayer())
    {
      Time.timeScale = 0;
    }
    if (Time.timeScale == 0 && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
    {
      Restart();
    }
  }

  //ブロックを再生成
  private void CreateBlocks()
  {
    //ブロックを再生成
    blockGenerator.setBlocks();
    //Blockタグを持ったオブジェクト(ブロック)を格納
    blocks = GameObject.FindGameObjectsWithTag("Block");
    //blocksの長さを取得
    count = blocks.Length;
  }
  //全てのブロックを破壊
  private void DestroyAllBlocks()
  {
    foreach (GameObject block in blocks)
    {
      Destroy(block);
    }
  }
  //プレイヤーとボールを再配置
  private void ResetPlayerBall()
  {
    //プレイヤーとボールの位置を初期位置に再配置
    player.transform.position = prefabPlayer.transform.position;
    ball.transform.position = prefabBall.transform.position;
    //ボールの速度を0に
    ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
  }

  //リスタート 
  private void Restart()
  {
    DestroyAllBlocks();
    CreateBlocks();
    ResetPlayerBall();
    BallController ballController = ball.GetComponent<BallController>();
    ballController.BallAddForce(ball);
    Time.timeScale = 1;
  }

  //ゲーム終了条件1：全てのブロックが破壊される を判定
  public bool AllBlocksDestroyed()
  {
    /* 
    グローバル変数 countの値を参照
    Blockが破壊されたときに1ずつ減る
     */
    if (this.count == 0)
    {
      // Debug.Log("All Blocks Destroyed!");
      return true;
    }
    else
    {
      return false;
    }
  }
  //終了条件2：ボールがプレイヤーよりも下に行く を判定
  public bool BallBelowPlayer()
  {
    //シーン中のプレイヤーとボールのy座標を比較
    if (this.ball.transform.position.y < this.player.transform.position.y - 1)
    {
      // Debug.Log("Ball Below Player!");
      return true;
    }
    else
    {
      return false;
    }
  }
}
