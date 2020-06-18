using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    
    enum EnemyState
    {
        Idle,Move,Attack,Return,Damaged,Die
    }

    EnemyState state;

    #region "Idle 상태에 필요한변수들"

    #endregion
    #region "Move 상태에 필요한변수들"   
    #endregion
    #region "Attack 상태에 필요한변수들"   
    #endregion
    #region "Return 상태에 필요한변수들"    
    #endregion
    #region "Damaged 상태에 필요한변수들"
    #endregion
    #region "Die 상태에 필요한변수들"
    #endregion
    public float findRange = 15f;
    public float moveRange = 30f;
    public float attackRange = 2f;
    Vector3 startPoint;
    Transform player;
    CharacterController cc;

    int hp = 100;
    int att = 5;

    float speed = 5.0f;
    float attTime = 2f;
    float timer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        state = EnemyState.Idle;

        startPoint = transform.position;
        player = GameObject.Find("Player").transform;
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Return:
                Return ();
                break;
            case EnemyState.Damaged:
                //Damaged();
                break;
            case EnemyState.Die:
                //Die();
                break;
            
        }
    }

private void Idle()
    {
        
        //Vector3 distance = transform.position - player.position;
        //float distance = dir.magnitude;
        //if(distance.magnitude<findRange )
        //if(distance<findRange )

        if(Vector3 .Distance (transform .position ,player .position )<findRange  )
        {
            state = EnemyState.Move;
            print("상태전환 : Idle -> Move");
        }
        
    }

    private void Move()
    {
       
        if(Vector3 .Distance (transform.position,startPoint) > moveRange)
        {
            state = EnemyState.Return;
            print("상태전환 : Move-> Return");

        }
        else if (Vector3.Distance(transform.position,player.position) > attackRange)
        {
            Vector3 dir = (player.position - transform.position).normalized;
            //dir.Normalize();

            //transform.forward = dir;
            //transform.LookAt(player);
            //transform.forward = Vector3.Lerp(transform.forward, dir, 10 * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
            //cc.Move(dir * speed * Time.deltaTime);

            cc.SimpleMove(dir * speed);
        }
        else
        {
            state = EnemyState.Attack;
            print("상태전환 : Move ->Attack");
        }
    }

    private void Attack()
    {
        
        if (Vector3.Distance(transform.position,player.position ) < attackRange )
        {
            timer += Time.deltaTime;
            if(timer > attTime)
            {
                print("공격");

                timer = 0f;
            }
        }
        else
        {
            state = EnemyState.Move;
            print("상태전환 : Attack -> Move");
            timer = 0f;
        }
        //공격범위안에 일정시간각격으로
        //공격범위를 벗어나면 이동
        //공격범위 1미터
        //상태변경
        //상태전환 출력
    }

    private void Return()
    {
        
        
        //일정범위30미터
        //상태변경
        //상태전환 출력tranditional
        if(Vector3 .Distance (transform .position ,startPoint )>0.1)
        {
            Vector3 dir = (startPoint - transform.position).normalized ;
            cc.SimpleMove(dir * speed);
        }
        else
        {
            transform.position = startPoint;
            state = EnemyState.Idle;
            print("상태전환 : Return -> Idle");
        }
    }

    public void hitDamage(int value)
    {
        if (state == EnemyState.Damaged || state == EnemyState.Die) return;

        hp -= value;

        if(hp>0)
        {
            state = EnemyState.Damaged;
            print("상태전환 : AnyState -> Damaged");
            print("HP : " + hp);

            Damaged();
        }
        else
        {
            state = EnemyState.Die;
            print("상태전환 : AnyState -> Die");

            Die();
        }
    }

    private void Damaged()
    {

        //코루틴
        //몬스터 체력이 1 이상
        //다시 이전상태로 변경
        //상태변경
        //상태전환 출력

        StartCoroutine(DamageProc());
    }

    IEnumerator DamageProc()
    {
        yield return new WaitForSeconds(1.0f);

        state = EnemyState.Move;
        print("상태전환 : Damaged -> Move");
    }

    private void Die()
    {
        //코루틴
        //체력이 0이하
        //몬스터 오브젝트 삭제
        //상태변경
        //상태전환 출력(죽었다)
        StopAllCoroutines();

        StartCoroutine(DieProc());
    }

    IEnumerator DieProc()
    {
        cc.enabled = false;

        yield return new WaitForSeconds(2.0f);
        print("죽었다");
        Destroy(gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, findRange );

        Gizmos.color = Color.green ;
        Gizmos.DrawWireSphere(startPoint , moveRange);
    }
}
