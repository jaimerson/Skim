using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadingNotice : Notice {
	protected override void executeAction(){
		dialog = FadingDialog.Create(textAsset.text);
		dialog.SetActive(true);
		dialog.GetComponent<Animator>().SetTrigger("show");
		Invoke("hide", 5f);
	}

	protected void hide(){
		dialog.GetComponent<Animator>().SetTrigger("fade");
		StartCoroutine(AsyncHelper.WaitFor(() => dialog.GetComponent<CanvasGroup>().alpha == 0, () => {
			Destroy(dialog);
			Destroy(gameObject);
		}));
	}
}
