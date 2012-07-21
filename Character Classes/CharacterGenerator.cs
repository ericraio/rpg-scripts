using UnityEngine;
using System.Collections;
using System;

public class CharacterGenerator : MonoBehaviour {
  private PlayerCharacter _toon;
  private const int STARTING_POINTS = 350;
  private const int MIN_STARTING_ATTRIBUTE_VALUE = 10;
  private const int STARTING_VALUE = 50;
  private int pointsLeft;

  public GUIStyle myStyle;

	// Use this for initialization
	void Start () {
    _toon = new PlayerCharacter();
    _toon.Awake();

    pointsLeft = STARTING_POINTS;

    for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++) {
      _toon.GetPrimaryAttribute(i).BaseValue = STARTING_VALUE;
      pointsLeft -= (STARTING_VALUE - MIN_STARTING_ATTRIBUTE_VALUE);
    }

    _toon.StatUpdate();
	}
	
	// Update is called once per frame
	void Update () {
	}

  void OnGUI() {
    DisplayName();
    DisplayPointsLeft();
    DisplayAttributes();
    DisplayVitals();
    DisplaySkills();
  }

  private void DisplayName() {
    GUI.Label(new Rect(10, 10, 50, 25), "Name:");
    _toon.Name = GUI.TextField(new Rect(65, 10, 100, 25), _toon.Name);
  }

  private void DisplayAttributes() {
    for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++) {
      GUI.Label(new Rect(10, 40 + (i * 25), 100, 25), ((AttributeName)i).ToString() );
      GUI.Label(new Rect(115, 40 + (i * 25), 30, 25), _toon.GetPrimaryAttribute(i).AdjustedBaseValue.ToString() );
      if(GUI.Button(new Rect(150, 40 + (i * 25), 25, 25), "-")) {
        if(_toon.GetPrimaryAttribute(i).BaseValue > MIN_STARTING_ATTRIBUTE_VALUE) {
          _toon.GetPrimaryAttribute(i).BaseValue--;
          pointsLeft++;
          _toon.StatUpdate();
        }
      }
      if(GUI.Button(new Rect(180, 40 + (i * 25), 25, 25), "+")) {
        if(pointsLeft > 0) {
          _toon.GetPrimaryAttribute(i).BaseValue++;
          pointsLeft--;
          _toon.StatUpdate();
        }
      }
    }
  }

  private void DisplayVitals() {
    for (int i = 0; i < Enum.GetValues(typeof(VitalName)).Length; i++) {
      GUI.Label(new Rect(10, 40 + ((i + 7) * 25), 100, 25), ((VitalName)i).ToString() );
      GUI.Label(new Rect(115, 40 + ((i + 7) * 25), 30, 25), _toon.GetVital(i).AdjustedBaseValue.ToString() );
    }
  }

  private void DisplaySkills() {
    for (int i = 0; i < Enum.GetValues(typeof(SkillName)).Length; i++) {
      GUI.Label(new Rect(250, 40 + (i * 25), 100, 25), ((SkillName)i).ToString());
      GUI.Label(new Rect(355, 40 + (i * 25), 30, 25), _toon.GetSkill(i).AdjustedBaseValue.ToString());
    }
  }

  private void DisplayPointsLeft() {
    GUI.Label(new Rect(250, 10, 100, 25), "Points Left: " + pointsLeft.ToString());
  }

}
