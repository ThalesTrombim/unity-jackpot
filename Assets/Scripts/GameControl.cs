using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
  public static event Action handlePulled = delegate { };

  [SerializeField]
  private Text prizeText;

  [SerializeField]
  private Row[] rows;

  [SerializeField]
  private Transform handle;

  private int prizeValue;
  private bool resultsChecked;

  void Start()
  {
    resultsChecked = false;
  }
  void Update()
  {
    if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped)
    {
      prizeValue = 0;
      prizeText.enabled = false;
      resultsChecked = true;
    }

    if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped)
    {
      CheckResults();
      prizeText.enabled = true;
      prizeText.text = "Prize: " + prizeValue;
    }
  }

  private void OnMouseDown()
  {
    if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped)
    {
      StartCoroutine("PullHandle");
    }
  }

  private IEnumerator PullHandle()
  {
    for (int i = 0; i < 15; i+= 5)
    {
      handle.Rotate(0f, 0f, i);
      yield return new WaitForSeconds(0.01f);
    }

    handlePulled();

    for (int i = 0; i < 15; i += 5)
    {
      handle.Rotate(0f, 0f, -i);
      yield return new WaitForSeconds(0.01f);
    }
  }

  private void CheckResults()
  {
    if (rows[0].stoppedSlot == "Diamond" && rows[1].stoppedSlot == "Diamond" && rows[2].stoppedSlot == "Diamond")
    {
      prizeValue = 200;
    }
    else if (rows[0].stoppedSlot == "Crow" && rows[1].stoppedSlot == "Crow" && rows[2].stoppedSlot == "Crow")
    {
      prizeValue = 400;
    }
    else if (rows[0].stoppedSlot == "Melon" && rows[1].stoppedSlot == "Melon" && rows[2].stoppedSlot == "Melon")
    {
      prizeValue = 600;
    }
    else if (rows[0].stoppedSlot == "Bar" && rows[1].stoppedSlot == "Bar" && rows[2].stoppedSlot == "Bar")
    {
      prizeValue = 800;
    }
    else if (rows[0].stoppedSlot == "Seven" && rows[1].stoppedSlot == "Seven" && rows[2].stoppedSlot == "Seven")
    {
      prizeValue = 1500;
    }
    else if (rows[0].stoppedSlot == "Cherry" && rows[1].stoppedSlot == "Cherry" && rows[2].stoppedSlot == "Cherry")
    {
      prizeValue = 3000;
    }
    else if (rows[0].stoppedSlot == "Lemon" && rows[1].stoppedSlot == "Lemon" && rows[2].stoppedSlot == "Lemon")
    {
      prizeValue = 5000;
    }


    else if (
        rows[0].stoppedSlot == rows[1].stoppedSlot && rows[0].stoppedSlot == "Diamond" ||
        rows[0].stoppedSlot == rows[2].stoppedSlot && rows[0].stoppedSlot == "Diamond" ||
        rows[1].stoppedSlot == rows[2].stoppedSlot && rows[1].stoppedSlot == "Diamond"
      )
    {
      prizeValue = 100;
    }
    else if (
        rows[0].stoppedSlot == rows[1].stoppedSlot && rows[0].stoppedSlot == "Crow" ||
        rows[0].stoppedSlot == rows[2].stoppedSlot && rows[0].stoppedSlot == "Crow" ||
        rows[1].stoppedSlot == rows[2].stoppedSlot && rows[1].stoppedSlot == "Crow"
      )
    {
      prizeValue = 100;
    }
    else if (
        rows[0].stoppedSlot == rows[1].stoppedSlot && rows[0].stoppedSlot == "Melon" ||
        rows[0].stoppedSlot == rows[2].stoppedSlot && rows[0].stoppedSlot == "Melon" ||
        rows[1].stoppedSlot == rows[2].stoppedSlot && rows[1].stoppedSlot == "Melon"
      )
    {
      prizeValue = 500;
    }
    else if (
        rows[0].stoppedSlot == rows[1].stoppedSlot && rows[0].stoppedSlot == "Bar" ||
        rows[0].stoppedSlot == rows[2].stoppedSlot && rows[0].stoppedSlot == "Bar" ||
        rows[1].stoppedSlot == rows[2].stoppedSlot && rows[1].stoppedSlot == "Bar"
      )
    {
      prizeValue = 700;
    }
    else if (
        rows[0].stoppedSlot == rows[1].stoppedSlot && rows[0].stoppedSlot == "Seven" ||
        rows[0].stoppedSlot == rows[2].stoppedSlot && rows[0].stoppedSlot == "Seven" ||
        rows[1].stoppedSlot == rows[2].stoppedSlot && rows[1].stoppedSlot == "Seven"
      )
    {
      prizeValue = 1000;
    }
    else if (
        rows[0].stoppedSlot == rows[1].stoppedSlot && rows[0].stoppedSlot == "Cherry" ||
        rows[0].stoppedSlot == rows[2].stoppedSlot && rows[0].stoppedSlot == "Cherry" ||
        rows[1].stoppedSlot == rows[2].stoppedSlot && rows[1].stoppedSlot == "Cherry"
      )
    {
      prizeValue = 2000;
    }
    else if (
        rows[0].stoppedSlot == rows[1].stoppedSlot && rows[0].stoppedSlot == "Lemon" ||
        rows[0].stoppedSlot == rows[2].stoppedSlot && rows[0].stoppedSlot == "Lemon" ||
        rows[1].stoppedSlot == rows[2].stoppedSlot && rows[1].stoppedSlot == "Lemon"
      )
    {
      prizeValue = 4000;
    }

    resultsChecked = true;
  }
}