# Html2Pdf.PlaywrightDotnet.API
Evaluating Playwright for .NET to do HTML to PDF conversion over RESTful web service

## Installation
Need to install the ```playwright``` dotnet tool globally. Only needs to be done once.
```
dotnet tool install --global Microsoft.Playwright.CLI
```

Run the tool.
```
playwright install
```

## Benchmarks
``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19042.1110 (20H2/October2020Update)
Intel Core i7-8750H CPU 2.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.100-preview.5.21302.13
  [Host]     : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT


```
|                   Method |       Mean |    Error |   StdDev |
|------------------------- |-----------:|---------:|---------:|
| Convert12SmallConcurrent |   516.5 ms | 12.88 ms | 37.96 ms |
|       ConvertSmallSingle |   132.8 ms |  2.65 ms |  6.34 ms |
|       ConvertLargeSingle |   684.5 ms | 13.46 ms | 26.25 ms |
| Convert12LargeConcurrent | 2,002.1 ms | 28.76 ms | 25.50 ms |