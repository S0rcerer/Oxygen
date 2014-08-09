using UnityEngine;
using System.Collections;

public static class Helpers
{
	public static float GetAngle(Vector2 currentPosition, Vector2 target)
	{
		float angle = Mathf.Atan2 ((target.y - currentPosition.y), (target.x - currentPosition.x));
		return (angle * Mathf.Rad2Deg);
	}
}
