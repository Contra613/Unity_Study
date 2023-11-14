using UnityEngine;

// PlayerController는 플레이어 캐릭터로서 Player 게임 오브젝트를 제어한다.
public class PlayerController : MonoBehaviour {
   public AudioClip deathClip; // 사망시 재생할 오디오 클립
   public float jumpForce = 700f; // 점프 힘

   private int jumpCount = 0; // 누적 점프 횟수
   private bool isGrounded = false; // 바닥에 닿았는지 나타냄
   private bool isDead = false; // 사망 상태

   private Rigidbody2D playerRigidbody; // 사용할 리지드바디 컴포넌트
   private Animator animator; // 사용할 애니메이터 컴포넌트
   private AudioSource playerAudio; // 사용할 오디오 소스 컴포넌트

   private void Start() 
   {
        // 초기화
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio= GetComponent<AudioSource>();
   }

   private void Update() 
   {
        // 만약 사망했다면 더 이상 진행하지 않고 종료
        if(isDead)
            return;

        // 사용자 입력을 감지하고 점프하는 처리
        // 마우스 왼쪽 버튼을 눌렀으며 && 최대 점프 횟수(2)에 도달하지 않았다면
        // GetMouseButtonDown : 0(왼쪽), 1(오른쪽), 2(휠)

        // 기능 : 2단 점프 가능, 오래누르면 더 높게 점프 가능
        if(Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            // 점프 횟수 증가
            jumpCount++;
            // 점프 직전 속도를 순간적으로 (0,0)으로 변경
            playerRigidbody.velocity  = Vector2.zero;
            // 리지드바디 위쪽으로 힘주기
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            // 오디오 소스 재생
            playerAudio.Play();
        }
        // 마우스 왼쪽 버튼이 올라왔으며 && y축 속도가 0보다 크다면  
        else if(Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)
        {
            // 속도를 반으로 줄인다.
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }

        // animator의 피라미터 상태 변경 (이름, 값)
        animator.SetBool("Grounded", isGrounded);
   }

   private void Die() 
   {
        // 사망 처리
        animator.SetTrigger("Die");

        // 오디오 소스에 할당된 오디오 클립을 deathClip으로 변경
        playerAudio.clip = deathClip;
        // 사망 효과음 재생
        playerAudio.Play();

        // 속도를 제로로변경
        playerRigidbody.velocity = Vector2.zero;
        // 사망 상태를 true로 변경
        isDead = true;

        // 게임 메니저의 게임오버 처리 시행
        GameManager.instance.OnPlayerDead();
   }

   private void OnTriggerEnter2D(Collider2D other) 
   {
        // 트리거 콜라이더를 가진 장애물과의 충돌을 감지
        // 충돌한 대상의 태그가 Dead이며 아직 사망 하지 않았다면 Die()를 실행
        if(other.tag == "Dead" && !isDead)
        {
            Die();
        }
   }

   private void OnCollisionEnter2D(Collision2D collision) 
   {
        // 바닥에 닿았음을 감지하는 처리
        // 어떤 콜라이더와 닿았으며, 충돌 표면이 위쪽을 보고 있으면 
        if(collision.contacts[0].normal.y > 0.7f)
        {
            // isGrounded를 true로 변경, jumpCount를 0으로 리셋
            isGrounded = true;
            jumpCount = 0;
        }
   }

   private void OnCollisionExit2D(Collision2D collision) 
   {
        // 바닥에서 벗어났음을 감지하는 처리
        // 어떤 콜라이더에서 때러진 경우 isGrounded를 false로 변경
        isGrounded = false;
   }
}