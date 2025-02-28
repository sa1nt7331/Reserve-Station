using Content.Client.Eui;
using Content.Shared._Reserve.Revolutionary;
using Content.Shared.Eui;
using JetBrains.Annotations;
using Robust.Client.Graphics;

namespace Content.Client._Reserve.Revolutionary.UI;

[UsedImplicitly]
public sealed class ConsentRequestedEui : BaseEui
{
    private readonly ConsentRequestedMenu _window;

    public ConsentRequestedEui()
    {
        _window = new ConsentRequestedMenu();

        _window.OnDeny += () =>
        {
            SendMessage(new ConsentRequestedEuiMessage(false));
            _window.Close();
        };

        _window.OnClose += () => SendMessage(new ConsentRequestedEuiMessage(false));

        _window.OnAccept += () =>
        {
            SendMessage(new ConsentRequestedEuiMessage(true));
            _window.Close();
        };
    }
    public override void HandleState(EuiStateBase state)
    {
        if (state is ConsentRequestedState consentState)
        {
            _window.SetConverterName(consentState.ConverterName);
        }
    }

    public override void Opened()
    {
        IoCManager.Resolve<IClyde>().RequestWindowAttention();
        _window.OpenCentered();
    }

    public override void Closed()
    {
        _window.Close();
    }
}

