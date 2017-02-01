using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BonusSystem : MonoBehaviour
{
    private bool isActive = false;
    public bool IsActive
    {
        get { return isActive; }
        set
        {
            if (isActive != value)
            {
                isActive = value;
                if (isActive == true) { onActivation(); }
            }
        }
    }
    public event ValueChange onActivation;
    public GameObject activatorObject;

    private SpriteRenderer spriteRenderer;
    private GameObject particles;
    private Collider2D collider2d;
    private GameObject tail;
    private IBonus bonusComponent;
    private void Start()
    {
        onActivation = ActivateParticles;
        onActivation += ActivateBonusGroup;
        onActivation += ActivateImage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameObjectsTags.BONUS_tag)) 
        {
            activatorObject = collision.gameObject;
            bonusComponent = activatorObject.GetComponent<IBonus>();
            bonusComponent.Activate();
            IsActive = true;
            StartCoroutine(DestroyBonus(activatorObject));
        }
    }

    IEnumerator DestroyBonus(GameObject toDestroy)
    {
        yield return new WaitForSeconds(GameConstants.BONUS_TIME);
        Destroy(toDestroy);
    }

    private void ActivateParticles()
    {
        particles = activatorObject.transform.FindChild("Particles").gameObject;
        collider2d = activatorObject.GetComponent<Collider2D>();
        spriteRenderer = activatorObject.GetComponent<SpriteRenderer>();
        tail = activatorObject.transform.FindChild("TailEffects").gameObject;

        collider2d.enabled = !IsActive;
        spriteRenderer.enabled = !IsActive;
        particles.SetActive(IsActive);
        tail.SetActive(!IsActive);
        isActive = false;
    }

    private IEnumerator ActivateBonusGUI(Image imageObject)
    {
        int time = (int)GameConstants.BONUS_TIME;
        while (time >= 0 && imageObject)
        {
            imageObject.fillAmount = (float)time / GameConstants.BONUS_TIME;
            time--;
            yield return new WaitForSeconds(1.0f);
        }
        onActivation -= delegate { StartCoroutine(ActivateBonusGUI(GUIController.Instance.bonusImageIcon[bonusComponent.ID])); };
    }
    private void ActivateImage()
    {
        if (Extensions.InitComponent<Image>(ref GUIController.Instance.bonusImageIcon[bonusComponent.ID],
                                                GameObjectsTags.BONUS_UI_tags[bonusComponent.ID]))
        {
            StartCoroutine(ActivateBonusGUI(GUIController.Instance.bonusImageIcon[bonusComponent.ID]));
        }
    }
    private void ActivateBonusGroup()
    {
        Transform tempPrefab = GUIController.Instance.prefabBonusGroups[bonusComponent.ID].transform;

        Transform initedPrefab = Instantiate(tempPrefab);
        initedPrefab.SetParent(GUIController.Instance.bonusPanel);
        initedPrefab.localScale = Vector3.one;
        initedPrefab.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero;

        StartCoroutine(DeactivateGroup(initedPrefab.gameObject));
    }
    private IEnumerator DeactivateGroup(GameObject toDestroy)
    {
        yield return new WaitForSeconds(GameConstants.BONUS_TIME);
        Destroy(toDestroy);
    }
}
