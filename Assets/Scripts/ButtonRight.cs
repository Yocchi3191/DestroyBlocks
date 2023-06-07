using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRight : MonoBehaviour
{
  public bool rButtonPressed;
  // Start is called before the first frame update
  void Start()
  {
    rButtonPressed = false;
  }

  // Update is called once per frame
  void Update()
  {
  }
  public void ButtonPressed()
  {
    rButtonPressed = true;
  }
  public void ButtonUp()
  {
    rButtonPressed = false;
  }
}
