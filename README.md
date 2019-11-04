<h1 align="center">
  <img width="480" height="240" src="doc/Logo.png">
</h1>

This library intends to use at small Unity project that needs to be localized to multiple languages.

[**Download From Here**](https://github.com/yutokun/Localizer/releases)

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

Add **String Injector** next to the text component and enter String ID.

Localized strings will be injected when the component starts.

![String Injector](doc/StringInjector.gif)

Supported component:

- TextMesh
- Text (UI)
- TextMeshPro
- TextMeshProUGUI

### Automatic Image Injection

Add **Image Injector** next to the game object and set images.

Localized images will be injected when the component starts.

![Image Injector](doc/ImageInjector.png)

Supported component:

- Renderer
- Image
- RawImage

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

## Roadmap

- AudioClip Injection

## License

[MIT License](LICENSE)