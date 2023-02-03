using UnityEngine;

public class TriggerOIF : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ObscuringItemFader[] obscuringItemFaders = collision.gameObject.GetComponentsInChildren<ObscuringItemFader>();

        if (obscuringItemFaders.Length > 0)
        {
            foreach (ObscuringItemFader obscuringItemFader in obscuringItemFaders)
            {
                obscuringItemFader.FadeOut();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ObscuringItemFader[] obscuringItemFaders = collision.gameObject.GetComponentsInChildren<ObscuringItemFader>();

        if (obscuringItemFaders.Length > 0)
        {
            foreach (ObscuringItemFader obscuringItemFader in obscuringItemFaders)
            {
                obscuringItemFader.FadeIn();
            }
        }
    }
}
