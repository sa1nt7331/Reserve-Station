using Content.Shared.StatusIcon;
using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;

namespace Content.Shared._Goobstation.Wizard;

[RegisterComponent, NetworkedComponent]
public sealed partial class WizardComponent : Component
{
    [DataField]
    public ProtoId<FactionIconPrototype> StatusIcon = "WizardFaction";
}
