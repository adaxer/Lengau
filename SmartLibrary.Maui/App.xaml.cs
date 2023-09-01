using SmartLibrary.Common.Interfaces;
using SmartLibrary.Common.Services;
using SmartLibrary.Data;

namespace SmartLibrary.Maui;

public partial class App : Application
{
    private readonly List<IRequireInitializeAsync> asyncInits;
    private readonly List<IRequireInitialize> syncInits;

    public App(IEnumerable<IRequireInitializeAsync> asyncs, IEnumerable<IRequireInitialize> syncs)
	{
		InitializeComponent();
		UserAppTheme = AppTheme.Dark;

		MainPage = new AppShell();
        asyncInits = asyncs.ToList();
        syncInits = syncs.ToList();
    }

    protected override void OnStart()
    {
        base.OnStart();
        syncInits.ForEach(s=>s.Initialize());
        asyncInits.ForEach(a=>a.InitializeAsync());
    }
}
