using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class PathDrawer : MonoBehaviour
{
    [SerializeField] private Transform nextSection; // 이동할 목표 오브젝트
    [SerializeField] private LineRenderer lineRenderer; // Line Renderer 컴포넌트
    [SerializeField, Range(0f, 1f)] private float lineOffset = 0.1f; // Line Renderer의 위치 오프셋
    
    private NavMeshAgent agent; // 네비게이션 에이전트 컴포넌트
    [SerializeField] private bool isOnPath; //플레이어가 다음 Section으로 이동 중인지 체크
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // 네비게이션 에이전트 컴포넌트 가져오기
        StopDrawingPath();
    }

    private void Update()
    {
        if (isOnPath) DrawPath();
    }

    private void DrawPath()
    {
        NavMeshPath path = new NavMeshPath();

        if (NavMesh.SamplePosition(nextSection.position, out NavMeshHit hit, 100f, NavMesh.AllAreas))
        {
            //agent.CalculatePath(hit.position, path); // NavMesh 경로 계산
            NavMesh.CalculatePath(transform.position, nextSection.position, NavMesh.AllAreas, path);
        }
        else
        {
            // 목표 위치가 NavMesh 상에서 접근 불가능한 경우
            lineRenderer.enabled = false;
            return;
        }

        if (path.corners.Length < 2) return; // 경로가 2개 이상의 점을 가지지 않으면 종료

        lineRenderer.enabled = true;
        lineRenderer.positionCount = path.corners.Length; // 경로 점의 개수로 Line Renderer의 점 개수 설정

        for (int i = 0; i < path.corners.Length; i++)
        {
            // 바닥이 아닌 카메라 밑에서 Line Renderer의 위치 조정
            Vector3 linePosition = path.corners[i] + Vector3.up * lineOffset;
            lineRenderer.SetPosition(i, linePosition);
        }
    }

    public void SetNextSection(Transform section)
    {
        nextSection = section;
    }

    public void StartDrawingPath()
    {
        isOnPath = true;
    }

    public void StopDrawingPath()
    {
        isOnPath = false;
        lineRenderer.enabled = false;
    }
    public void OnPath()
    {
        isOnPath = true;
    }

}
