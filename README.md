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
