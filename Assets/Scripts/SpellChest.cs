using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellChest : TreasureChestController {
	public TextAsset description;
	public List<Spell> spells;

	protected override void showMessage(){
		GameObject message = ModalDialog.Create(description.text);

		foreach(Spell spell in spells){
            Game.current.spells.Add(spell);
		}
		message.SetActive(true);
	}
}
