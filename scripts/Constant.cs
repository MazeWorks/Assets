using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant : MonoBehaviour {
	public const int SCREEN_X = 1080;
	public const int SCREEN_Y = 1920;
	public const float UNIT_Y = 10;
	public const float UNIT_X = UNIT_Y * ((float)SCREEN_X / SCREEN_Y);
}
