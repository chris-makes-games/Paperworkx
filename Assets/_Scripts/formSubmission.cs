using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class formSubmission : MonoBehaviour
{

  public RobotInventory robotInventory;
  private bool hasPaper = false;
  void Start()
  {


  }


  public void PaperCheck()
  {
    if (hasPaper)
    {
      // robot has paper -> printer reads paper
    }

    // check if robot has paper
    if (robotInventory != null)
    {
      hasPaper = true;
      // printer reads paper; keeps track of wrong questions
    }
    else
    {
      // failure
    }




  }
}
