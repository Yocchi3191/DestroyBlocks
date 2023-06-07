using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
  public Transform player;
  //移動スピード
  public float speed;
  //移動範囲の右端
  public float rightLimit;
  //移動範囲の左端
  public float leftLimit;
  private ButtonRight buttonR;
  private ButtonLeft buttonL;

  // Start is called before the first frame update
  void Start()
  {
    this.player = transform;
    buttonR = GameObject.Find("ButtonRight").GetComponent<ButtonRight>();
    buttonL = GameObject.Find("ButtonLeft").GetComponent<ButtonLeft>();

    //右の壁
    GameObject wallRight = GameObject.Find("WallRight");
    //左の壁
    GameObject wallLeft = GameObject.Find("WallLeft");
    //playerの幅の半分
    float plWidth = this.player.localScale.x / 2;
    //壁の幅の半分
    float wallWidth = wallRight.transform.localScale.x / 2;
    //右端
    rightLimit = wallRight.transform.position.x - (wallWidth + plWidth);
    //左端
    leftLimit = wallLeft.transform.position.x + (wallWidth + plWidth);
  }

  // Update is called once per frame
  void Update()
  {
    //右キー，s，画面上の右ボタン押下され，かつプレイヤーが右の壁に接していなければ
    if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.S) || buttonR.rButtonPressed) &&
    AllowMoveRight(player, rightLimit))
    {
      GoRight();
    }
    //左キー，a，画面上の左ボタンが押下され，かつプレイヤーが左の壁に接していなければ
    if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || buttonL.lButtonPressed) &&
    AllowMoveLeft(player, leftLimit))
    {
      GoLeft();
    }
  }

  //右移動
  public void GoRight()
  {
    if (transform.position.x < this.rightLimit)
    {
      transform.position += Vector3.right * speed * Time.deltaTime;
    }
  }

  //左移動
  public void GoLeft()
  {
    if (transform.position.x > this.leftLimit)
    {
      transform.position += Vector3.left * speed * Time.deltaTime;
    }
  }

  //プレイヤーが右端にいないかを判定
  public bool AllowMoveRight(Transform pos, float rLim)
  {
    /* 
    pos : プレイヤーのtransformを渡す
    rLim : rightLimitを渡す
    */
    if (pos.position.x < rLim)
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  //プレイヤーが左端にいないかを判定
  public bool AllowMoveLeft(Transform pos, float lLim)
  {
    /* 
    pos : プレイヤーのtransformを渡す
    lLim : leftLimitを渡す
    */
    if (lLim < pos.position.x)
    {
      return true;
    }
    else
    {
      return false;
    }
  }
}
