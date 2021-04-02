﻿using UnityEngine;
using UnityEditor;
using Brainiac;

namespace BrainiacEditor
{
	public class BehaviourTreeEditor : EditorWindow
	{
		[SerializeField]
		private Texture m_gridTexture;
		[SerializeField]
		private BTAsset m_btAsset;
		[SerializeField]
		private BTNavigationHistory m_navigationHistory;

		private BTEditorGrid m_grid;
		private BTEditorGraph m_graph;
		private BTEditorCanvas m_canvas;
		private bool m_isDisposed;

		public BTNavigationHistory NavigationHistory
		{
			get { return m_navigationHistory; }
		}

		private void OnEnable()
		{
			if(m_gridTexture == null)
			{
				m_gridTexture = Resources.Load<Texture>("Brainiac/EditorGUI/background");
			}
			
			if(m_graph == null)
			{
				m_graph = BTEditorGraph.Create();
			}
			if(m_canvas == null)
			{
				m_canvas = new BTEditorCanvas();
				BTEditorCanvas.Current = m_canvas;
			}
			if(m_grid == null)
			{
				m_grid = new BTEditorGrid(m_gridTexture);
			}
			if(m_navigationHistory == null)
			{
				m_navigationHistory = new BTNavigationHistory();
			}

			ReloadBehaviourTree();
			m_isDisposed = false;
			m_canvas.OnRepaint += OnRepaint;
			EditorApplication.playModeStateChanged += HandlePlayModeChanged;
		}

		private void OnDisable()
		{
			Dispose();
		}

		private void OnDestroy()
		{
			Dispose();
		}

		private void Dispose()
		{
			if(!m_isDisposed)
			{
				if(m_graph != null)
				{
					BTEditorGraph.DestroyImmediate(m_graph);
					m_graph = null;
				}
				if(m_btAsset != null)
				{
					SaveBehaviourTree();
					m_btAsset.Dispose();
				}

				EditorApplication.playModeStateChanged -= HandlePlayModeChanged;
				m_isDisposed = true;
			}
		}

		private void SetBTAsset(BTAsset asset, bool clearNavigationHistory)
		{
			if(asset != null && (clearNavigationHistory || asset != m_btAsset))
			{
				if(m_btAsset != null)
				{
					SaveBehaviourTree();
					m_btAsset.Dispose();
					m_btAsset = null;
				}

				BehaviourTree behaviourTree = asset.GetEditModeTree();
				if(behaviourTree != null)
				{
					m_btAsset = asset;
					m_graph.SetBehaviourTree(behaviourTree);
					m_canvas.Area = m_btAsset.CanvasArea;
					m_canvas.CenterOnPosition(behaviourTree.Root.Position, position.size);
					m_canvas.IsDebuging = false;

					if(clearNavigationHistory)
					{
						m_navigationHistory.Clear();
					}

					m_navigationHistory.Push(m_btAsset, null);
				}
				else
				{
					CrashEditor("Failed to deserialize behaviour tree!\n\nThis can happen when you rename a behaviour node class, when you change the namespace or when you delete a behaviour node script.\n\nTry to enable text serialization and manually edit the asset file to fix the behaviour tree.");
				}
			}
		}

		private void SetBTAssetDebug(BTAsset asset, BehaviourTree btInstance, bool clearNavigationHistory)
		{
			if(asset != null && btInstance != null && (clearNavigationHistory || asset != m_btAsset || !m_canvas.IsDebuging))
			{
				m_btAsset = asset;
				m_graph.SetBehaviourTree(btInstance);
				m_canvas.CenterOnPosition(btInstance.Root.Position, position.size);
				m_canvas.Area = m_btAsset.CanvasArea;
				m_canvas.IsDebuging = true;

				if(clearNavigationHistory)
				{
					m_navigationHistory.Clear();
				}

				m_navigationHistory.Push(m_btAsset, btInstance);
			}
		}

		private void ReloadBehaviourTree()
		{
			if(m_btAsset != null)
			{
				BehaviourTree behaviourTree = m_btAsset.GetEditModeTree();
				if(behaviourTree != null)
				{
					m_graph.SetBehaviourTree(behaviourTree);
					m_canvas.CenterOnPosition(behaviourTree.Root.Position, position.size);
					m_canvas.Area = m_btAsset.CanvasArea;
					m_canvas.IsDebuging = false;
				}
				else
				{
					CrashEditor("Failed to deserialize behaviour tree!\n\nThis can happen when you rename a behaviour node class, when you change the namespace or when you delete a behaviour node script.\n\nTry to enable text serialization and manually edit the asset file to fix the behaviour tree.");
				}
			}
		}

		private void CrashEditor(string message)
		{
			Close();
			EditorUtility.DisplayDialog("Error", message, "Close");
		}

		public void CreateNewBehaviourTree()
		{
			string path = EditorUtility.SaveFilePanelInProject("Create new behaviour tree", "behaviour_tree", "asset", "");
			if(!string.IsNullOrEmpty(path))
			{
				BTAsset asset = ScriptableObject.CreateInstance<BTAsset>();

				AssetDatabase.CreateAsset(asset, path);
				AssetDatabase.Refresh();

				SetBTAsset(AssetDatabase.LoadAssetAtPath<BTAsset>(path), true);
			}
		}

		public void OpenBehaviourTree()
		{
			string path = EditorUtility.OpenFilePanel("Open behaviour tree", "", "asset");
			if(!string.IsNullOrEmpty(path))
			{
				int index = path.IndexOf("Assets");
				if(index >= 0)
				{
					path = path.Substring(index);
					SetBTAsset(AssetDatabase.LoadAssetAtPath<BTAsset>(path), true);
				}
			}
		}

		public void SaveBehaviourTree()
		{
			if(m_btAsset != null)
			{
				m_btAsset.CanvasArea = m_canvas.Area;
				m_btAsset.Serialize();
				EditorUtility.SetDirty(m_btAsset);
			}
		}

		private void HandlePlayModeChanged(PlayModeStateChange change)
		{
			if(!EditorApplication.isPlaying)
			{
				if(EditorApplication.isPlayingOrWillChangePlaymode)
				{
					SaveBehaviourTree();
				}
				else
				{
					m_navigationHistory.DiscardInstances();
					ReloadBehaviourTree();
				}
			}
		}

		private void OnGUI()
		{
			if(m_btAsset != null)
			{
				Rect navHistoryRect = new Rect(0.0f, 0.0f, position.width, 20.0f);
				Rect optionsRect = new Rect(position.width - 20.0f, 0.0f, 20.0f, 20.0f);
				Rect footerRect = new Rect(0.0f, position.height - 18.0f, position.width, 20.0f);
				Rect canvasRect = new Rect(0.0f, navHistoryRect.yMax, position.width, position.height - (footerRect.height + navHistoryRect.height));
				
				BTEditorStyle.EnsureStyle();
				m_grid.DrawGUI(position.size);
				m_graph.DrawGUI(canvasRect);
				m_canvas.HandleEvents(canvasRect, position.size);
				DrawNavigationHistory(navHistoryRect);
				DrawFooter(footerRect);
				DrawOptions(optionsRect);

				if(m_canvas.IsDebuging)
				{
					OnRepaint();
				}
			}
		}

		private void DrawNavigationHistory(Rect screenRect)
		{
			EditorGUI.LabelField(screenRect, "", BTEditorStyle.EditorFooter);

			m_navigationHistory.Refresh();

			if(m_navigationHistory.Size > 0)
			{
				float left = screenRect.x;
				for(int i = 0; i < m_navigationHistory.Size; i++)
				{
					BTAsset asset = m_navigationHistory.GetAssetAt(i);
					GUIStyle style;
					Vector2 size;

					if(i > 0)
					{
						style = (i == m_navigationHistory.Size - 1) ? BTEditorStyle.BreadcrumbMiddleActive : BTEditorStyle.BreadcrumbMiddle;
						size = style.CalcSize(new GUIContent(asset.name));
					}
					else
					{
						style = (i == m_navigationHistory.Size - 1) ? BTEditorStyle.BreadcrumbLeftActive : BTEditorStyle.BreadcrumbLeft;
						size = style.CalcSize(new GUIContent(asset.name));
					}

					Rect position = new Rect(left, screenRect.y, size.x, screenRect.height);
					left += size.x;

					if(i < m_navigationHistory.Size - 1)
					{
						if(GUI.Button(position, asset.name, style))
						{
							GoBackInHistory(i);
							break;
						}
					}
					else
					{
						EditorGUI.LabelField(position, asset.name, style);
					}
				}
			}
		}

		private void GoBackInHistory(int positionInHistory)
		{
			BTAsset btAsset;
			BehaviourTree btInstance;

			m_navigationHistory.GetAt(positionInHistory, out btAsset, out btInstance);

			if(btAsset != null)
			{
				m_navigationHistory.Trim(positionInHistory);
				if(btInstance != null)
				{
					SetBTAssetDebug(btAsset, btInstance, false);
				}
				else
				{
					SetBTAsset(btAsset, false);
				}
			}
			else
			{
				m_navigationHistory.Clear();
			}
		}

		private void DrawFooter(Rect screenRect)
		{
			string behaviourTreePath = AssetDatabase.GetAssetPath(m_btAsset).Substring(7);
			EditorGUI.LabelField(screenRect, behaviourTreePath, BTEditorStyle.EditorFooter);
		}

		private void DrawOptions(Rect screenRect)
		{
			if(GUI.Button(screenRect, BTEditorStyle.OptionsIcon, EditorStyles.toolbarButton))
			{
				GenericMenu menu = BTContextMenuFactory.CreateBehaviourTreeEditorMenu(this);
				menu.DropDown(new Rect(Event.current.mousePosition, Vector2.zero));
			}
		}

		public void OnRepaint()
		{
			Repaint();
		}

		public static void Open(BTAsset behaviourTree)
		{
			var window = EditorWindow.GetWindow<BehaviourTreeEditor>("Brainiac");
			window.SetBTAsset(behaviourTree, true);
		}

		public static void OpenDebug(BTAsset btAsset, BehaviourTree btInstance)
		{
			var window = EditorWindow.GetWindow<BehaviourTreeEditor>("Brainiac");
			window.SetBTAssetDebug(btAsset, btInstance, true);
		}

		public static void OpenSubtree(BTAsset behaviourTree)
		{
			var window = EditorWindow.GetWindow<BehaviourTreeEditor>("Brainiac");
			window.SetBTAsset(behaviourTree, false);
		}

		public static void OpenSubtreeDebug(BTAsset btAsset, BehaviourTree btInstance)
		{
			var window = EditorWindow.GetWindow<BehaviourTreeEditor>("Brainiac");
			window.SetBTAssetDebug(btAsset, btInstance, false);
		}

		[UnityEditor.Callbacks.OnOpenAsset(0)]
		private static bool OnOpenBTAsset(int instanceID, int line)
		{
			BTAsset asset = EditorUtility.InstanceIDToObject(instanceID) as BTAsset;
			if(asset != null)
			{
				Open(asset);
				return true;
			}

			return false;
		}
	}
}