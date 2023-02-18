using System;
using System.Collections;
using System.Collections.Generic;
using Ecs;
using Ecs.Systems;
using ECS.Systems;
using Game;
using Leopotam.EcsLite;
using MonoBehaivours;
using UnityEngine;

public class ECSStartup : MonoBehaviour
{
    [SerializeField] private GridCards  gridCards;
    [SerializeField] private GameObject modalCanvas;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private InfoPanel infoPanel;
    public IEcsSystems _systems;
#if UNITY_EDITOR
    IEcsSystems _editorSystems;
#endif
    void Awake ()
    {
        var world = new EcsWorld();
        var sharedData = new ECSSharedData();
        sharedData.Game = new MemoryGame(5);
        sharedData.GridCards = gridCards;
        sharedData.ModalCanvas = modalCanvas;
        sharedData.GameManager = gameManager;
        sharedData.InfoPanel = infoPanel;
        _systems = new EcsSystems (world, sharedData);
#if UNITY_EDITOR
        // Создаем отдельную группу для отладочных систем.
        _editorSystems = new EcsSystems (_systems.GetWorld ());
        _editorSystems
            .Add (new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem ())
            .Init ();
#endif
        _systems
            .Add (new InitEntityTypeStorage())
            .Add (new NewGameSystem())
            .Add (new TimerSystem())
            .Add (new CalculationPointSystem())
            .Add (new RotateCardSystem()) 
            .Add (new CheckOpenedCardSystem()) 
            .Add (new CheckEndGameSystem()) 
            .Add (new RemoveComponentsSystem())
            .Init ();
        
    }

    public void Start()
    {
        
    }

    void Update () {
        _systems?.Run ();
#if UNITY_EDITOR
        // Выполняем обновление состояния отладочных систем. 
        _editorSystems?.Run ();
#endif
    }
    
    void OnDestroy () {
#if UNITY_EDITOR
        // Выполняем очистку отладочных систем.
        if (_editorSystems != null) {
            _editorSystems.Destroy ();
            _editorSystems = null;
        }
#endif
        if (_systems != null) {
            _systems.Destroy ();
            _systems.GetWorld ().Destroy ();
            _systems = null;
        }
    }
}
