# Heap Installation Issue on MAUI

On .net MAUI 8, we experienced a few issues getting Heap running smoothly. This repository documents those issues.

1. First error after installing the three libraries for Heap
```
Microsoft.Common.CurrentVersion.targets(2292,5):
 Error MSB4803 : The task "ResolveNativeReference" is not supported on the .NET Core version of MSBuild.
 Please use the .NET Framework version of MSBuild. See https://aka.ms/msbuild/MSB4803 for further details.
```

The solution is to ensure that both ios and android libraries are only set to compile if they match the target framework.

```xaml
<ItemGroup Condition="'$(TargetFramework)' == 'net8.0-android'">
    <PackageReference Include="HeapInc.Xamarin.Android" Version="0.4.0" />
</ItemGroup>
<ItemGroup Condition="'$(TargetFramework)' == 'net8.0-ios'">
    <PackageReference Include="HeapInc.Xamarin.iOS" Version="0.4.0" />
</ItemGroup>
```

Now, Android builds and runs without a problem.

2. Error accessing the iOS implementation

Although the first error was easily resolved, the next problem is that I am unable to start tracking for the iOS tracker.

```xaml
AppDelegate.cs(14,9): Error CS0234 :
 The type or namespace name 'iOS' does not exist in the namespace 'HeapInc.Xamarin' (are you missing an assembly reference?)
```

I have tried cleaning, rebuilding, and restarting my mac.

These [lines from the documentation](https://developers.heap.io/docs/xamarin-quick-start) are especially confusing:

> If your application uses .NET MAUI, the Heap Xamarin Bridge will work for your app as well. 
> To enable building with .NET MAUI, raise your project's target framework to .NET Standard 2.1, clean, and rebuild.

MAUI apps target .net core not .net standard. We cannot change the project's target framework from .net 8 to .net standard 2.1.
