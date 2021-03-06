<h1 align="center">
  <img width="480" src="doc/Logo.png">
</h1>

[![Create GitHub Releases](https://github.com/yutokun/Localizer/workflows/Create%20GitHub%20Releases/badge.svg)](https://github.com/yutokun/Localizer/actions?query=workflow%3A"Create+GitHub+Releases")

This library intends to use at small Unity project that needs to be localized to multiple languages.

[**Download From Here**](https://github.com/yutokun/Localizer/releases) or if you would like, buy it at Asset Store! (currently in review)

## Features

- Automatically inject strings to text-type component.
- Automatically inject images to image-type component.
- Simple API
- Load multi-language definition file. (TSV)
- Editor preview and useful warnings.

## How to Use

### Preparation

1. Make UTF-8 TSV.

   ![String Injector](doc/TSV.png)

2. Place it to StreamingAssets folder with the name "**LocalizedStrings.tsv**".

### Automatic String Injection

Add **String Localizer** next to the supported component and enter String ID. It suggest candidate IDs as you type.

Localized strings will be injected when the component starts.

![String Injector](doc/StringInjector.gif)

Supported component:

- TextMesh
- Text (UI)
- TextMeshPro
- TextMeshProUGUI

### Automatic Image Injection

Add **Image Localizer** next to the supported component and set images.

Localized images will be injected when the component starts.

![Image Injector](doc/ImageInjector.png)

Supported component:

- Renderer
- Image
- RawImage

### Automatic Audio Injection

Add **Audio Localizer** next to the supported component and set AudioClips.

Localized audio will be injected when the components starts.

![Audio Localizer](doc/AudioLocalizer.png)

Supported component:

- AudioSource

### Get String from Code

```csharp
var text = Localizer.GetStringFromId("helloworld"); // ex. Hello, World!
var jpText = Localizer.GetStringFromId("helloworld", "Japanese"); // ex. ハローワールド
```

### Change Language

```csharp
Localizer.ActivateNextLanguage(); // easiest way
Localizer.ActivatePreviousLanguage();
Localizer.ChangeLanguage("Japanese");
```

### Get Available Language List

```csharp
Localizer.LanguageList; // returns List<string>
```

### Get Current Language Name

```csharp
Localizer.CurrentLanguageName; // returns string
```

### Reload Strings from Disk

```csharp
Localizer.Load();
```

### Force Inject to All IInjectors

```csharp
Localizer.InjectAll();
```

## Use TextMesh Pro

if you want to use this asset with TextMesh Pro, you need to enable TMP Integration. It's easy, just check a box.

![Enable TMP](doc/EnableTMP.png)

## Licenses

### create-unitypackage

Copyright (c) 2020 pCYSl5EDgo

[MIT license](https://github.com/pCYSl5EDgo/create-unitypackage/blob/master/LICENSE)

### action-gh-release

Copyright (c) 2019 Doug Tangren

[MIT license](https://github.com/softprops/action-gh-release/blob/master/LICENSE)

### This Repo

[MIT License](LICENSE)
