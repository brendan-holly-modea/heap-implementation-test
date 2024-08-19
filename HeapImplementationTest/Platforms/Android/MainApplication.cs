using Android.App;
using Android.Runtime;

namespace HeapImplementationTest;

[Application]
public class MainApplication : MauiApplication
{
    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
        : base(handle, ownership)
    {
        HeapInc.Xamarin.Android.Implementation.StartRecording(this, "YOUR_ENVIRONMENT_ID");
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}