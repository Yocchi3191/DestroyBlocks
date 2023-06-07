using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
  public GameDirector gameDirector;
  // Start is called before the first frame update
  void Start()
  {
    gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "Ball")
    {
      Destroy(this.gameObject);
    }
  }
  private void OnDestroy()
  {
    gameDirector.count--;
  }
}
