using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
  public TextMeshProUGUI gameText;
  public GameDirector gameDirector;
  // Start is called before the first frame update
  void Start()
  {
    this.gameText = GetComponent<TextMeshProUGUI>();
    this.gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
  }

  // Update is called once per frame
  void Update()
  {
    //GameDirectorの終了条件判定の関数を使う
    //何も起きてないときはテキスト無しで，ゲーム終了時に何らかのテキストを表示
    gameText.text = null;
    if (gameDirector.AllBlocksDestroyed())
    {
      gameText.text = "<size=51.3>WELL DONE</size>\n<size=75>Tap to RESTART</size>";
      // Debug.Log(gameText);
    }
    if (gameDirector.BallBelowPlayer())
    {
      gameText.text = "<size=51.3>GAME OVER</size>\n<size=75>Tap to RESTART</size>";
      // Debug.Log(gameText);
    }
  }
}
