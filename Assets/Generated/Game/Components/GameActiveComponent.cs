//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity activeEntity { get { return GetGroup(GameMatcher.Active).GetSingleEntity(); } }
    public ActiveComponent active { get { return activeEntity.active; } }
    public bool hasActive { get { return activeEntity != null; } }

    public GameEntity SetActive(bool newValue) {
        if (hasActive) {
            throw new Entitas.EntitasException("Could not set Active!\n" + this + " already has an entity with ActiveComponent!",
                "You should check if the context already has a activeEntity before setting it or use context.ReplaceActive().");
        }
        var entity = CreateEntity();
        entity.AddActive(newValue);
        return entity;
    }

    public void ReplaceActive(bool newValue) {
        var entity = activeEntity;
        if (entity == null) {
            entity = SetActive(newValue);
        } else {
            entity.ReplaceActive(newValue);
        }
    }

    public void RemoveActive() {
        activeEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ActiveComponent active { get { return (ActiveComponent)GetComponent(GameComponentsLookup.Active); } }
    public bool hasActive { get { return HasComponent(GameComponentsLookup.Active); } }

    public void AddActive(bool newValue) {
        var index = GameComponentsLookup.Active;
        var component = (ActiveComponent)CreateComponent(index, typeof(ActiveComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceActive(bool newValue) {
        var index = GameComponentsLookup.Active;
        var component = (ActiveComponent)CreateComponent(index, typeof(ActiveComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveActive() {
        RemoveComponent(GameComponentsLookup.Active);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherActive;

    public static Entitas.IMatcher<GameEntity> Active {
        get {
            if (_matcherActive == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Active);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherActive = matcher;
            }

            return _matcherActive;
        }
    }
}
