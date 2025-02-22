﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    /// <summary>
    /// 작성자 : 곽진성,
    /// 기능 : 머지 관련 브랜치 모델 드래그 앤 드랍 적용
    /// </summary>
    public class DragBranch : MonoBehaviour
    {
        [SerializeField] Material highlight;

        private GameObject dragObject;
        private BranchModel branchModel;
        private BranchModel dragBranchModel;

        private float startY;
        private Vector3 point;

        private bool mouseIn = false;
        private bool mouseDrag = false;

        // 드래그용 게임 오브젝트 설정
        public void Initialize()
        {
            branchModel = GetComponent<BranchModel>();
            
            dragObject = Instantiate(gameObject);
            dragBranchModel = dragObject.GetComponent<BranchModel>();
            dragBranchModel.SetRepository(branchModel.GetRepository());
            dragBranchModel.SetIsDragObject(true);
            dragObject.GetComponent<DragBranch>().enabled = false;

            // 하이라이트 적용
            foreach (MeshRenderer renderer in dragObject.GetComponentsInChildren<MeshRenderer>())
                renderer.material = highlight;

            // 위상 적용
            startY = GameObject.Find("Master").GetComponent<Transform>().position.y;

            dragObject.SetActive(false);
        }

        public GameObject GetDragObject()
        {
            return dragObject;
        }

        // 브랜치와 같은 지평선의 좌표
        private Vector3 RatioApplied(Vector3 point)
        {
            float ratio = (Camera.main.transform.position.y - startY) / (Camera.main.transform.position.y - point.y);

            float resultX = (point.x - Camera.main.transform.position.x) * ratio + Camera.main.transform.position.x;
            float resultY = startY;
            float resultZ = (point.z - Camera.main.transform.position.z) * ratio + Camera.main.transform.position.z;

            return new Vector3(resultX, resultY, resultZ);
        }

        private void Update()
        {
            // 마우스 우클릭
            if (Input.GetMouseButtonDown(1) && mouseIn)
            {
                dragObject.SetActive(true);
                mouseDrag = true;

                branchModel.ApplyMergeStartMaterial();
            }
            if (Input.GetMouseButton(1) && mouseDrag)
            {
                // 마우스 위치 계산
                point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
                dragObject.transform.position = RatioApplied(point);
            }
            if (Input.GetMouseButtonUp(1))
            {
                if (!dragBranchModel.TryMerge())
                    dragObject.SetActive(false);
                mouseDrag = false;

                branchModel.LoadOriginalMaterial();
            }
        }

        // 마우스 안에 있음
        private void OnMouseEnter()
        {
            mouseIn = true;
        }

        // 마우스가 밖에 있음
        private void OnMouseExit()
        {
            mouseIn = false;
        }
    }
}