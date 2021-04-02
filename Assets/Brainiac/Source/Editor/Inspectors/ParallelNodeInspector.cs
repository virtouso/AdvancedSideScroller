﻿using UnityEditor;
using Brainiac;

namespace BrainiacEditor
{
	[CustomNodeInspector(typeof(Parallel))]
	public class ParallelNodeInspector : CompositeInspector
	{
		private string[] m_exitConditions = new string[] { "Any", "All" };
		private string[] m_tieConditions = new string[] { "Fail", "Succeed" };

		protected override void DrawProperties()
		{
			Parallel parallel = (Parallel)Target;

			parallel.FailOnAny = EditorGUILayout.Popup("Fail", parallel.FailOnAny ? 0 : 1, m_exitConditions) == 0;
			parallel.SucceedOnAny = EditorGUILayout.Popup("Succeed", parallel.SucceedOnAny ? 0 : 1, m_exitConditions) == 0;
			parallel.FailOnTie = EditorGUILayout.Popup("Tie Breaker", parallel.FailOnTie ? 0 : 1, m_tieConditions) == 0;
			EditorGUILayout.Space();

			DrawChildren(parallel);
		}
	}
}
