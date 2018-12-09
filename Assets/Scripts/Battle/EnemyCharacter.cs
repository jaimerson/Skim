using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Enemy", menuName="Battle/Enemy")]
[System.Serializable]
public class EnemyCharacter : Character {
	public int experienceDrop;
	public int goldDrop;
}
