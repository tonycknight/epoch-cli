# epoch-cli


[![Build & Release](https://github.com/tonycknight/epoch-cli/actions/workflows/build.yml/badge.svg)](https://github.com/tonycknight/epoch-cli/actions/workflows/build.yml)

![Nuget](https://img.shields.io/nuget/v/epoch-cli)

A `dotnet tool` for epoch times.


# Getting Started

## Dependenices

You'll need the [.Net 6 runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) installed.

## Installation

``epoch-cli`` is available from [Nuget](https://www.nuget.org/packages/epoch-cli/):

```
dotnet tool install epoch-cli -g
```

---


# How to use

## Help:

```
epoch -?
```


## Epoch

Convert integer or date time values to their Unix epoch equivalents, or `now` for the curent time.

```
epoch <value>
```

Where `<value>` is an integer, local date time or `now`

E.g.

`epoch 0`

`epoch 2020-01-01T01:30:00`

`epoch now`


---



## Copyright and notices

(c) Tony Knight 2023.

