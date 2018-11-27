dotnet コマンドでクラスライブラリとテストプロジェクトを作る

# ソリューションフォルダの作成

```bash
mkdir sample
cd sample
```

## git のリポジトリの初期化

```bash
git init
```

```.gitignore
obj/
bin/
```

# ソリューションファイルの作成

```bash
dotnet new sln
```

# Sample ライブラリプロジェクトの作成

```bash
dotnet new classlib -o Sample
dotnet sln add ./Sample/Sample.csproj
```

# クラスの作成

ファイル名は`.cs`ならなんでも。

```cs
using System;

namespace Sample
{
    public class SampleClass
    {
        public bool IsEven(int num)
        {
            return num % 2 == 0;
        }
    }
}
```

# Sample ライブラリのテストプロジェクトの作成(xUnit)

```bash
dotnet new xunit -o Sample.Tests
dotnet sln add ./Sample.Tests/Sample.Tests.csproj
# 参照の追加
dotnet add ./Sample.Tests/Sample.Tests.csproj reference ./Sample/Sample.csproj
```

# テストクラスの作成

ファイル名は`.cs`ならなんでも。

```cs
using System;
using Xunit;

namespace Sample.Tests
{
    public class SampleClass_IsEven
    {
        [Fact]
        public void ReturnFalseGivenValueOf1()
        {
            var _sample = new SampleClass();
            var result = _sample.IsEven(1);

            Assert.False(result, "1 should not be even");
        }
    }
}
```

# テストの実行

```bash
dotnet test ./Sample.Tests/Sample.Tests.csproj
```

# （おまけ）nuget パッケージの追加

パッケージのページの.NET CLI の方のコマンドを追加したいプロジェクトあるディレクトリでコピペ実行すれば OK。
コマンドは以下の通り。

```
dotnet add <PROJECT> package [options] <PACKAGE_NAME>
```
