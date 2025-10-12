using UnityEngine;

public class RobotInventory : MonoBehaviour
{
  public bool holdingPaper = false;

  public bool IsHoldingPaper()
  {
    return holdingPaper;
  }

  public void PickUpPaper()
  {
    holdingPaper = true; // now holding paper
  }

  public void RemovePaper()
  {
    holdingPaper = false; // paper -> to printer
  }

  void update()
  {
    if ()
  }

}
