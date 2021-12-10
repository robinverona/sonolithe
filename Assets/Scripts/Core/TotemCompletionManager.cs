using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class TotemCompletionManager : MonoBehaviour
{
    public TotemCompletion[] totemCompletionArray;
    public List<bool> booleanArray;
    [SerializeField]
    GameObject portalSphere;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    GameObject _FPSCamera;
    [SerializeField]
    GameObject _endCutsceneCamera;
    [SerializeField]
    Light _endLight;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < totemCompletionArray.Length; i++)
        {
            totemCompletionArray[i].OnTotemCompleted += CheckTotemTotal;
        }

    }

    private void portalApparition()
    {
        _endLight.gameObject.SetActive(true);
        _FPSCamera.SetActive(false);
        _endCutsceneCamera.SetActive(true);
        player.GetComponent<PlayerBehavior>().enabled = false;
        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(5f).Append(portalSphere.transform.DOScale(
        3f, 2f).SetEase(Ease.InOutBounce))
       .AppendInterval(1f).Append(portalSphere.transform.DOMove(
        new Vector3(-52.15f, 5.25f, -79f), 6f))
        .AppendInterval(0f).Append(portalSphere.transform.DOScale(
        8f, 1f).SetEase(Ease.InOutBounce)).Join(_endLight.DOIntensity(
        3000f, 1f).SetEase(Ease.InOutSine));

    }

    private void pulseEmissionPortal()
    {
        /*  float timer;
          timer += Time.deltaTime;
          if (timer > timeBetweenShots)
          {
              float emissionIntensity = Mathf.Sin(Time.time * pulseTempo) * 0.5f + 0.5f;
              transform.Find("signal.001").gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", _emissionColor * emissionIntensity);
              pulseSource.Play();
              timer = 0;
          }*/
    }
    // Update is called once per frame
    private void CheckTotemTotal(bool isTotemCompleted, string name)
    {
        booleanArray.Add(isTotemCompleted);


        if (booleanArray.Count >1)
        {
            portalApparition();
            Debug.Log("Tous les totems sont complets");

        }
    }
}
