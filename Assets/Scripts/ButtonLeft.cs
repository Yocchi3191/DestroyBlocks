using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLeft : MonoBehaviour
{
  public bool lButtonPressed;
  // Start is called before the first frame update
  void Start()
  {
    lButtonPressed = false;
  }

  // Update is called once per frame
  void Update()
  {
  }
  public void ButtonPressed()
  {
    lButtonPressed = true;
  }
  public void ButtonUp()
  {
    lButtonPressed = false;
  }
}
