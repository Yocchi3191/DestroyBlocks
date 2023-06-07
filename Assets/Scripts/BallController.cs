using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
  public float speed;

  public void BallAddForce(GameObject obj)
  {
    Rigidbody2D rigid2d;
    rigid2d = obj.GetComponent<Rigidbody2D>();
    float r = Random.Range(0f, 1f) * 2f - 1f;
    Debug.Log(r);
    //ランダムな角度でボールを打ち出す
    Vector2 direction = new Vector2(r, 1);
    rigid2d.AddForce(direction.normalized * speed, ForceMode2D.Impulse);
  }
  // Start is called before the first frame update
  void Start()
  {
    BallAddForce(gameObject);
  }

  // Update is called once per frame
  void Update()
  {

  }
}
