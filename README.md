# Unity-XcodeResourceUpdater

Add resource file automatically to Xcode at build

## Requirements

* Ruby 2.0.0+
* Unity 5+

## Setup

Install [CocoaPods/Xcodeproj](https://github.com/CocoaPods/Xcodeproj)

```
$ sudo gem install xcodeproj
```

Note: Install the system ruby If you are using a rbenv

## Install

Download package:
[XcodeResourceUpdater.unitypackage](https://github.com/STAR-ZERO/Unity-XcodeResourceUpdater/releases/download/v0.0.1/XcodeResourceUpdater.unitypackage)

Import package to Unity.

## Usage

Create `NativeResources/iOS` directory, and save resource files.

```
<project root>
├── Assets
├── Library
├── NativeResources
│   └── iOS   <- here
├── ProjectSettings
├── README.md
└── Temp
```

Resource file located in the `NativeResources/iOS` directory will be added automatically when you build to Xcode.

Support sub directory.

### Support file

* image file (png, jpg, jpeg, gif, tiff)
* json
* plist
* txt
* xib
* storyboard
* localize file (xx.lproj/xx.string)
* AssetCatalog (.xcassets)



