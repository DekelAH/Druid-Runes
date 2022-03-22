using Assets.Scripts.Infastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Runes
{
    public abstract class RuneBase : MonoBehaviour
    {
        #region Events

        public event Action<bool> BeginDraw;
        public event Action<bool> EndDraw;

        #endregion

        #region Editor

        [SerializeField]
        protected Transform[] _runeDrawPoints;

        [SerializeField]
        protected Transform _runeBrush;

        [SerializeField]
        protected float _moveSpeed;

        #endregion

        #region Fields

        protected readonly Stack<Vector3> _runeDrawingPath = new Stack<Vector3>();
        private bool _isDrawing;

        #endregion

        #region Methods

        public void DrawRune()
        {
            GenerateRunePath();
            _runeBrush.position = _runeDrawingPath.Pop();
            DrawRuneInternal();
        }

        public void DrawRuneInternal()
        {
            if (_runeDrawingPath.Count > 0)
            {
                var fromPoint = _runeBrush.position;
                var nextPoint = _runeDrawingPath.Pop();
                StartCoroutine(PaintLine(_runeBrush, fromPoint, nextPoint, _moveSpeed, DrawRuneInternal));
            }

            _isDrawing = false;
            EndDraw?.Invoke(_isDrawing);
        }

        public void GenerateRunePath()
        {
            _runeDrawingPath.Clear();

            for (int i = _runeDrawPoints.Length - 1; i >= 0; i--)
            {
                _runeDrawingPath.Push(_runeDrawPoints[i].position);
            }
        }

        public IEnumerator PaintLine(Transform objectToMove, Vector3 fromPoint, Vector3 toPoint, float inTime, Action endCallback)
        {
            var accTime = 0f;
            var moveFactor = 0f;

            do
            {
                objectToMove.position = Vector3.Lerp(fromPoint, toPoint, moveFactor);
                moveFactor = accTime / inTime;
                accTime += Time.deltaTime;
                _isDrawing = true;
                BeginDraw?.Invoke(_isDrawing);

                yield return null;

            } while (moveFactor < 1);

            endCallback?.Invoke();
        }

        #endregion
    }
}
