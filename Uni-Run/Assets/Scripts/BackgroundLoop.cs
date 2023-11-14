using UnityEngine;

// 왼쪽 끝으로 이동한 배경을 오른쪽 끝으로 재배치하는 스크립트
public class BackgroundLoop : MonoBehaviour 
{
    private float width; // 배경의 가로 길이

    // Awake() : Start() 매서드처럼 시작시 한번만 실행된다. 하지만 Start()보다 실행시점이 한 프레임 더 빠르다.
    private void Awake() 
    {
        // BoxCollider2D 컴포넌트가 추가되면 자동으로 스프라이트의 크기에 맞게 설정되기 때문에 
        // 가로 길이를 구할 수 있다.

        // 가로 길이를 측정하는 처리
        // BoxCollider2D 컴포넌트의 Size 필드의 x 값을 가로 길이로 사용
        BoxCollider2D backgroundCllider = GetComponent<BoxCollider2D>();
        width = backgroundCllider.size.x;
    }

    private void Update() 
    {
        // 현재 위치가 원점에서 왼쪽으로 width 이상 이동했을때 위치를 재배치
        if(transform.position.x <= -width)
        {
            Reposition();
        }
    }

    // 위치를 리셋하는 메서드
    private void Reposition() 
    {
        // 현제 위치에서 오른쪽 가로 길이 * 2만큼 이동
        Vector2 offset = new Vector2(width * 2f, 0);
        // transform.position는 Vector3 타입이므로 Vector2로 명시적 형변환
        // Vector2 -> Vector3 할당 가능
        // Vector3 -> Vector2 할당 불가능 (명시적 할당)
        transform.position = (Vector2) transform.position + offset;
    }
}