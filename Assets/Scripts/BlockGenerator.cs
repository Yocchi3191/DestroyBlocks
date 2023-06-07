using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
  public GameObject prefabBlock;
  public float spacing;
  public int xCount;
  public int yCount;

  //ブロックの配置．GameDirectorからもアクセスしたいのでパブリック
  public void setBlocks()
  {
    Vector3 position = transform.position;
    for (int y = 0; y < yCount; y++)
    {
      for (int x = 0; x < xCount; x++)
      {
        Vector3 blockPosition = new Vector3(position.x + x * spacing, position.y + y * (spacing / 2.0f), 0);
        Instantiate(prefabBlock, blockPosition, Quaternion.identity);
      }
    }
  }
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}
