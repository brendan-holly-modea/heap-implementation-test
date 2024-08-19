using Foundation;
using HeapInc.Xamarin;
using UIKit;

namespace HeapImplementationTest;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    
    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        HeapInc.Xamarin.iOS.Implementation.StartRecording("YOUR_ENVIRONMENT_ID");
        return base.FinishedLaunching(application, launchOptions);
    }
}