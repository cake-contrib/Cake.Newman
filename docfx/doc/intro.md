# Getting Started

## Installing `newman`

You will need to have `newman` installed

```bash
npm install newman -g
```

Alternatively to install `newman` from a Cake script, you can use [philo](https://github.com/philo)'s [cake-npm](https://github.com/philo/cake-npm):

```csharp
#addin "Cake.Npm"
// in a Task/Setup block
Npm.Install(settings => settings.Package("newman").Globally());
```

## Including the addin

At the top of your script, just add the following to install the addin:

```csharp
#addin nuget:?package=Cake.Newman
```

## Usage

The addin exposes a single `RunCollection` alias, with three overloads:

- `RunCollection(FilePath collectionFile)` : Runs `newman` on the specified collection using the default settings
- `RunCollection(FilePath collectionFile, NewmanSettings settings)` : Runs `newman` on the specified collection using the specified settings (not recommended)
- `RunCollection(FilePath collectionFile, Action<NewmanSettings> configure)` : Runs `newman` on the specified collection using the specified configuration action (**recommended method**)

## Settings

See the [settings documentation](settings.md) for more information.