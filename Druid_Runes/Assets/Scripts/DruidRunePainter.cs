using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runes
{
    public class DruidRunePainter : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Transform[] _runeDrawPoints;

        [SerializeField]
        private Transform _runeBrush;

        [SerializeField]
        private float _moveSpeed = 0.1f;

        #endregion

        #region Fields

        private readonly Stack<Vector3> _runeDrawingPath = new Stack<Vector3>();

        #endregion

        #region Methods

        public void DrawRune()
        {
            GenerateRunePath();
            _runeBrush.position = _runeDrawingPath.Pop();
            DrawRuneInternal();
        }

        private void DrawRuneInternal()
        {
            if (_runeDrawingPath.Count > 0)
            {
                var fromPoint = _runeBrush.position;
                var nextPoint = _runeDrawingPath.Pop();
                StartCoroutine(PaintLine(_runeBrush, fromPoint, nextPoint, _moveSpeed, DrawRuneInternal));
            }
            else
            {

            }
        }

        private void GenerateRunePath()
        {
            _runeDrawingPath.Clear();

            for (int i = _runeDrawPoints.Length - 1; i >= 0; i--)
            {
                _runeDrawingPath.Push(_runeDrawPoints[i].position);
            }
        }

        private IEnumerator PaintLine(Transform objectToMove, Vector3 fromPoint, Vector3 toPoint, float inTime, Action endCallback)
        {
            var accTime = 0f;
            var moveFactor = 0f;

            do
            {
                objectToMove.position = Vector3.Lerp(fromPoint, toPoint, moveFactor);
                moveFactor = accTime / inTime;
                accTime += Time.deltaTime;

                yield return null;

            } while (moveFactor < 1);

            endCallback?.Invoke();
        }

        #endregion
    }
}