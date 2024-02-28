using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
  private enum SwitchState
  {
    Off,
    On,
    Blink
  }

  public Collider bola;
  public Material offMaterial;
  public Material onMaterial;
  public ScoreManager scoreManager;
  public float score;
  public AudioManager audioManager;
  public VFXManager vfxManager;

  private SwitchState state;
  private Renderer renderers;

  private void Start()
  {
    renderers = GetComponent<Renderer>();

    Set(false);

    StartCoroutine(BlinkTimerStart(5));
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other == bola)
    {
      Toggle(other);
    }
  }

  private void Set(bool active)
  {
    if (active == true)
    {
      state = SwitchState.On;
      renderers.material = onMaterial;
      StopAllCoroutines();
    }
    else
    {
      state = SwitchState.Off;
      renderers.material = offMaterial;
      StartCoroutine(BlinkTimerStart(5));
    }
  }

  private void Toggle(Collider collision)
  {
    vfxManager.PlayVFXSwitch(collision.transform.position);
    scoreManager.AddScore(score);
    if (state == SwitchState.On)
    {
      Set(false);
      audioManager.PlaySFXSwitchOff(collision.transform.position);
    }
    else
    {
      Set(true);
      audioManager.PlaySFXSwitchOn(collision.transform.position);
    }
  }

  private IEnumerator Blink(int times)
  {
    state = SwitchState.Blink;

    for (int i = 0; i < times; i++)
    {
      renderers.material = onMaterial;
      yield return new WaitForSeconds(0.5f);
      renderers.material = offMaterial;
      yield return new WaitForSeconds(0.5f);
    }

    state = SwitchState.Off;

    StartCoroutine(BlinkTimerStart(5));
  }

  private IEnumerator BlinkTimerStart(float time)
  {
    yield return new WaitForSeconds(time);
    StartCoroutine(Blink(2));
  }
}