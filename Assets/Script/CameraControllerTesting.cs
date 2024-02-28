using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerTesting : MonoBehaviour
{
  public Transform target;
  public Transform dummyTarget;
  private Vector3 defaultPosition;

  private void Start()
  {
      defaultPosition = transform.position;
      target = null;
  }

  private void Update()
  {
		// kita beri debug dulu dengan GetKey karena script ini masih tahap awal
		if (Input.GetKeyDown(KeyCode.Space))
		{
			FocusAtTarget(dummyTarget, 5);
		}
        if (Input.GetKeyDown(KeyCode.R))
	    {
		GoBackToDefault();
	    }
  }

	// belum dipakai
  private void FocusAtTarget(Transform targetTransform, float length)
    {
	target = targetTransform;

	// disini perlu ditambahkan kalkulasi posisi kamera dari target
	Vector3 targetToCameraDirection = transform.rotation * -Vector3.forward;
  Vector3 targetPosition = target.position + (targetToCameraDirection * length);

	// bagian ini diuab jadi targetPosition
	StartCoroutine(MovePosition(targetPosition, 5));
    }
	
	// belum dipakai
  public void GoBackToDefault()
  {
      target = null;

      // disini perlu ditambahkan fungsi untukmengggerakan ke posisi default
      StartCoroutine(MovePosition(defaultPosition, 5));
  }

  private IEnumerator MovePosition(Vector3 target, float time)
  {
      float timer = 0;
      Vector3 start = transform.position;

      while (timer < time)
      {
          // pindahkan posisi camera secara bertahap menggunakan Lerp
					// Lerp ini kita tambahkan smoothing menggunakan SmoothStep
          transform.position = Vector3.Lerp(start, target, Mathf.SmoothStep(0.0f, 1.0f, timer/time));
					
					// di lakukan berulang2 tiap frame selama parameter time
          timer += Time.deltaTime;
          yield return new WaitForEndOfFrame();
      }
			
      transform.position = target;
  }
}